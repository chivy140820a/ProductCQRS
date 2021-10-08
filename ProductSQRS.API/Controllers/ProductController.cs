using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductSQRS.API.Data;
using ProductSQRS.API.SQRS.ProductSQRS;
using System.Threading.Tasks;
using System.Collections.Generic;
using static ProductSQRS.API.EventRequest.Event;
using Microsoft.EntityFrameworkCore;
using ProductSQRS.API.EventVMRequest;
using ProductSQRS.API.EventVm;

namespace ProductSQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IMediator _mediator;
        public ProductController(IMediator mediator, ApplicationDbContext context)
        {
            _context = context;
            _mediator = mediator;
        }    
        [HttpGet("GetAllProduct")]
        public async Task<IActionResult> GetAll()
        {
            var getall = await _mediator.Send(new GetAllProductSQRS.Query());
            return Ok(getall);
        }
        [HttpPost("AddEventRecive")]
        public async Task<IActionResult> AddEventRecive([FromBody]CreateRecive request)
        {
            var recive = new Recive(request.ProductId, request.Quantity, request.Common);
            var products = await _context.Products.ToListAsync();
            Dictionary<int, IList<IEvent>> list = new Dictionary<int, IList<IEvent>>();
            var product = new Repository(_context);
            await product.AddEvent(request.ProductId,recive);
            return Ok();
        }
        [HttpPost("AddEventSend")]
        public async Task<IActionResult> AddEventSend([FromBody] CreateSend request)
        {
            var sended = new Send(request.ProductId, request.Quantity, request.Common);
            var products = await _context.Products.ToListAsync();    
            var product = new Repository(_context);
            await product.AddEvent(request.ProductId, sended);
            return Ok();
        }
        [HttpPost("AddEventAdjusted")]
        public async Task<IActionResult> AddEventAdjusted([FromBody] CreateRecive request)
        {
            var ad = new Adjusted(request.ProductId, request.Quantity,"", request.Common);
            var products = await _context.Products.ToListAsync();
          
            var product = new Repository(_context);
            await product.AddEvent(request.ProductId, ad);
            return Ok();
        }
        [HttpPost("GetById")]
        public async Task<IActionResult> GetById(IEvent request, int Id)
        {
            var products = await _context.Products.ToListAsync();
            var product = new Repository(_context);
            var lists =  await product.GetDicById(Id);
            return Ok(lists);
        }


    }
}
