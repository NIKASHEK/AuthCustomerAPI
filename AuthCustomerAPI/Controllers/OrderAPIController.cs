using AuthCustomerAPI.Models;
using AuthCustomerAPI.Models.OrderDto;
using AuthCustomerAPI.Service.Customer;
using AuthCustomerAPI.Service.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthCustomerAPI.Controllers
{
    [Route("api/OrderAPI")]
    [Authorize]
    [ApiController]
    public class OrderAPIController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;

        public OrderAPIController(IOrderService orderService, ICustomerService customerService)
        {
            _orderService = orderService;
            _customerService = customerService;
        }

        [HttpGet("getOrders")]
        [Authorize(Roles = Role.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<IEnumerable<OrderReadDto>> GetOrders()
        {
            var orders = _orderService.GetAllOrders().ToList();

            return Ok(orders);
        }

        [HttpGet("getMyOrders")]
        [Authorize(Roles = Role.User)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<IEnumerable<OrderReadDto>> GetMyOrders()
        {
            var username = User.Identity?.Name;
            var userCustomer = _customerService.GetAllCustomers()
                .FirstOrDefault(c => c.UserName == username);

            if (userCustomer == null)
                return Forbid();

            var orders = _orderService.GetAllOrders()
                .Where(o => o.CustomerId == userCustomer.Id)
                .ToList();

            return Ok(orders);
        }

        [HttpGet("getOrderById/{id:int}", Name = "GetOrderById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<OrderReadDto> GetOrderById(int id)
        {
            var order = _orderService.GetOrder(id);
            if (order == null)
                return NotFound();

            if (User.IsInRole(Role.User))
            {
                var username = User.Identity?.Name;
                var userCustomer = _customerService.GetAllCustomers()
                    .FirstOrDefault(c => c.UserName == username);

                if (userCustomer == null || order.CustomerId != userCustomer.Id)
                    return Forbid();
            }

            return Ok(order);
        }

        [HttpPost("createOrder")]
        [Authorize(Roles = Role.Admin + "," + Role.User)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<OrderReadDto> CreateOrder(OrderCreateDto dto)
        {
            if (User.IsInRole(Role.User))
            {
                var username = User.Identity?.Name;
                var userCustomer = _customerService.GetAllCustomers()
                    .FirstOrDefault(c => c.UserName == username);

                if (userCustomer == null)
                    return Forbid();

                dto.CustomerId = userCustomer.Id;
            }

            var order = _orderService.CreateOrder(dto);
            return CreatedAtAction("GetOrderById", new { id = order.Id }, order);
        }

        [HttpPut("updateOrder/{id:int}")]
        [Authorize(Roles = Role.Admin + "," + Role.User)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult UpdateOrder(int id, [FromBody] OrderUpdateDto updateDto)
        {
            var order = _orderService.GetOrder(id);
            if (order == null)
                return NotFound();

            if (User.IsInRole(Role.User))
            {
                var username = User.Identity?.Name;
                var userCustomer = _customerService.GetAllCustomers()
                    .FirstOrDefault(c => c.UserName == username);

                if (userCustomer == null || order.CustomerId != userCustomer.Id)
                    return Forbid();
            }

            _orderService.UpdateOrder(id, updateDto);
            return NoContent();
        }

        [HttpDelete("deleteOrder/{id:int}")]
        [Authorize(Roles = Role.Admin + "," + Role.User)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult DeleteOrder(int id)
        {
            var order = _orderService.GetOrder(id);
            if (order == null)
                return NotFound();

            if (User.IsInRole(Role.User))
            {
                var username = User.Identity?.Name;
                var userCustomer = _customerService.GetAllCustomers()
                    .FirstOrDefault(c => c.UserName == username);

                if (userCustomer == null || order.CustomerId != userCustomer.Id)
                    return Forbid();
            }

            _orderService.DeleteOrder(id);
            return NoContent();
        }

        [HttpGet("filterOrders")]
        [Authorize(Roles = Role.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<IEnumerable<OrderReadDto>> FilterOrders([FromQuery] OrderQueryDto queryDto)
        {
            var orders = _orderService.FilterOrder(queryDto.TotalAmount).ToList();

            if (!orders.Any())
                return NotFound();

            return Ok(orders);
        }

        [HttpPatch("updatePartialOrder/{id:int}")]
        [Authorize(Roles = Role.Admin + "," + Role.User)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult UpdatePartialOrder(int id, [FromBody] OrderPatchDto patchDto)
        {
            var order = _orderService.GetOrder(id);
            if (order == null)
                return NotFound();

            if (User.IsInRole(Role.User))
            {
                var username = User.Identity?.Name;
                var userCustomer = _customerService.GetAllCustomers()
                    .FirstOrDefault(c => c.UserName == username);

                if (userCustomer == null || order.CustomerId != userCustomer.Id)
                    return Forbid();
            }

            var success = _orderService.PatchOrder(id, patchDto);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
