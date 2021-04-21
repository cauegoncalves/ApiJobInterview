using cgds.manufacture.api.Extensions;
using cgds.manufacture.api.Models.Order;
using cgds.manufacture.application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cgds.manufacture.api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderService _orderService;

        public OrderController(IOrderRepository orderRepository, IOrderService orderService)
        {
            this._orderRepository = orderRepository;
            this._orderService = orderService;
        }

        [HttpGet("{orderId}")]
        public IActionResult Get(int orderId)
        {
            var order = _orderRepository.GetById(orderId);

            if (order == null)
                return NotFound();

            return Ok(new OrderResponse(order));
        }

        [HttpPost]
        public IActionResult Post([FromBody]OrderRequest orderRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var order = orderRequest.ToOrder();
            var requiredBinWidth = _orderService.Save(order);
            return Ok(requiredBinWidth);
        }

    }
}