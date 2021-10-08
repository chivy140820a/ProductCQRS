using ProductSQRS.API.Constant;
using ProductSQRS.API.Data;
using ProductSQRS.API.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using static ProductSQRS.API.EventRequest.Event;

namespace ProductSQRS.API.SQRS.ProductSQRS
{
    public class CreateEventProduct
    {
        Dictionary<int, IList<IEvent>> ListEvent = new Dictionary<int, IList<IEvent>>();
        public int ProductId { get; set; }
        private readonly ApplicationDbContext _context;
        public CreateEventProduct(ApplicationDbContext context,int productid, Dictionary<int,IList<IEvent>> listEvent)
        {
            ListEvent = listEvent;
            _context = context;
            ProductId = productid;
        }
        public async Task AddEvent(IEvent request)
        {
            switch(request)
            {
                case Recive recive:
                    {
                        await Add(recive);
                        break;
                    }
                case Send send:
                    {
                        await Add(send);
                        break;
                    }
                case Adjusted adjused:
                    {
                        await Add(adjused);
                        break;
                    }
            }    
        }
        
        public async Task Add(Recive request)
        {
            IList<IEvent> list = new List<IEvent>();
            if(ListEvent.ContainsKey(ProductId)==false)
            {
                ListEvent.Add(ProductId, list);
            }
            var listproduct = ListEvent[ProductId];
            
            listproduct.Add(request);
            var productman = new ProductManager()
            {
                ProductId = request.productid,
                Quantity = request.quantity,
                Common = Common.Recived
            };
            _context.ProductManagers.Add(productman);
            await _context.SaveChangesAsync();
            int addquantity = request.quantity;
            var product = await _context.Products.FindAsync(ProductId);
            product.Quantity = product.Quantity + addquantity;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            
        }
        public async Task Add(Send request)
        {
            IList<IEvent> list = new List<IEvent>();
            if (ListEvent.ContainsKey(ProductId) == false)
            {
                ListEvent.Add(ProductId, list);
            }
            var listproduct = ListEvent[ProductId];
           
            listproduct.Add(request);
            var productman = new ProductManager()
            {
                ProductId = request.productid,
                Quantity = request.quantity,
                Common = Common.Sended
            };
            _context.ProductManagers.Add(productman);
            await _context.SaveChangesAsync();
            var product = await _context.Products.FindAsync(ProductId);
            product.Quantity = product.Quantity + request.quantity;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

        }
        public async Task Add(Adjusted request)
        {
            IList<IEvent> list = new List<IEvent>();
            if (ListEvent.ContainsKey(ProductId) == false)
            {
                ListEvent.Add(ProductId, list);
            }
            var listproduct = ListEvent[ProductId];
            var productman = new ProductManager()
            {
                ProductId = request.productid,
                Quantity = request.quantity,
                Common = Common.Ajuseded
            };
            _context.ProductManagers.Add(productman);
            await _context.SaveChangesAsync();
            var product = await _context.Products.FindAsync(ProductId);
            product.Quantity = product.Quantity + request.quantity;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
