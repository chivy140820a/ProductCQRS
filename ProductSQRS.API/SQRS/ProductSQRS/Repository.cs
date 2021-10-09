using Microsoft.EntityFrameworkCore;
using ProductSQRS.API.Constant;
using ProductSQRS.API.Data;
using ProductSQRS.API.EventVMRequest;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ProductSQRS.API.EventRequest.Event;

namespace ProductSQRS.API.SQRS.ProductSQRS
{
    public class Repository
    {
        
        private readonly ApplicationDbContext _context;
        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddEvent(int id,IEvent request)
        {
            var product = await _context.Products.FindAsync(id);
            Dictionary<int, IList<IEvent>> list = new Dictionary<int, IList<IEvent>>();
            list = await GetAll();
            var productSv = new CreateEventProduct(_context, product.Id, list);
            await productSv.AddEvent(request);
        }
        public async Task<Dictionary<int,IList<IEvent>>> GetDicById(int Id)
        {
            Dictionary<int, IList<IEvent>> listEvents = new Dictionary<int, IList<IEvent>>();
            var product = await _context.Products.FindAsync(Id);
            var productmanagers = await _context.ProductManagers.Where(x => x.ProductId == product.Id).ToListAsync();
            IList<IEvent> list = new List<IEvent>();
            foreach (var item in productmanagers)
            {
                if (item.Common == Common.Recived)
                {
                    list.Add(new Recive(item.ProductId, item.Quantity, item.Common));
                }
                if (item.Common == Common.Sended)
                {
                    list.Add(new Send(item.ProductId, item.Quantity, item.Common));
                }
                if (item.Common == Common.Ajuseded)
                {
                    list.Add(new Adjusted(item.ProductId, item.Quantity, "", item.Common));
                }
            }
            listEvents.Add(Id, list);
            return listEvents;
        }
        public async Task<List<EventViewModel>> GetByIdViewModel(int Id)
        {
            var list = await _context.ProductManagers.Where(x => x.ProductId == Id).ToListAsync();
            var listVm = new List<EventViewModel>();
            foreach(var item in list)
            {
                listVm.Add(new EventViewModel()
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Common = item.Common
                });
            }
            return listVm;
        }
        public async Task<Dictionary<int,IList<IEvent>>> GetAll()
        {
            Dictionary<int, IList<IEvent>> listEvents = new Dictionary<int, IList<IEvent>>();
            var products = await _context.Products.ToListAsync();
            var productmanagers = await _context.ProductManagers.ToListAsync();
            foreach(var product in products)
            {
                IList<IEvent> list = new List<IEvent>();
                foreach(var item in productmanagers)
                {
                    if(item.ProductId == product.Id)
                    {
                        if (item.Common == Common.Recived)
                        {
                            list.Add(new Recive(item.ProductId, item.Quantity, item.Common));
                        }
                        if (item.Common == Common.Sended)
                        {
                            list.Add(new Send(item.ProductId, item.Quantity, item.Common));
                        }
                        if (item.Common == Common.Ajuseded)
                        {
                            list.Add(new Adjusted(item.ProductId, item.Quantity, "", item.Common));
                        }
                    }    
                   
                }
                listEvents.Add(product.Id, list);
            }
            return listEvents;
        }
    }
}
