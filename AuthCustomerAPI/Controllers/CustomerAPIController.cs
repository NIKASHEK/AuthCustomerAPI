using AuthCustomerAPI.Models;
using AuthCustomerAPI.Models.CustomerDto;
using AuthCustomerAPI.Service.Customer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthCustomerAPI.Controllers
{
    [Route("api/CustomerAPI")]
    [Authorize]
    [ApiController]
    public class CustomerAPIController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomerAPIController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet("getCustomers")]
        [Authorize(Roles = Role.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<IEnumerable<CustomerReadDto>> GetCustomers()
        {
            return Ok(_service.GetAllCustomers());
        }

        [HttpGet("getCustomerById/{id:int}", Name = "GetCustomerById")]
        [Authorize(Roles = Role.Admin + "," + Role.User)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<CustomerReadDto> GetCustomerById(int id)
        {
            var customer = _service.GetCustomer(id);
            if (customer == null)
                return NotFound();
            
            if (User.IsInRole(Role.User))
            {
                var username = User.Identity?.Name;
                if (customer.UserName != username)
                    return Forbid();
            }

            return Ok(customer);
        }

        [HttpPost("createCustomer")]
        [Authorize(Roles = Role.Admin)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<CustomerReadDto> CreateCustomer([FromBody] CustomerCreateDto customerCreateDto)
        {
            var readDto = _service.CreateCustomer(customerCreateDto);

            return CreatedAtAction("GetCustomerById", new { id = readDto.Id }, readDto);
        }

        [HttpPut("updateCustomer/{id:int}")]
        [Authorize(Roles = Role.Admin+ "," + Role.User)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerUpdateDto updateDto)
        {
            var customer = _service.GetCustomer(id);
            if (customer == null)
                return NotFound();

            if (User.IsInRole("User") && customer.UserName != User.Identity?.Name)
                return Forbid();

            _service.UpdateCustomer(id, updateDto);
            return NoContent();
        }

        [HttpDelete("deleteCustomer/{id:int}")]
        [Authorize(Roles = Role.Admin)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _service.GetCustomer(id);
            if (customer == null)
                return NotFound();

            _service.DeleteCustomer(id);
            return NoContent();
        }

        [HttpGet("filterCustomers")]
        [Authorize(Roles = Role.Admin)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<IEnumerable<CustomerReadDto>> FilterCusomers([FromQuery] CustomerQueryDto queryDto)
        {
            var customers = _service.FilterCustomer(queryDto).ToList();
            if (customers.Count == 0)
                return NotFound();

            return Ok(customers);
        }
        [HttpPatch("updatePartialCustomer/{id:int}")]
        [Authorize(Roles = Role.Admin + "," + Role.User)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public IActionResult UpdatePartialCustomer(int id, [FromBody] CustomerPatchDto patchDto)
        {
            var customer = _service.GetCustomer(id);
            if (customer == null)
                return NotFound();

            if (User.IsInRole(Role.User) && customer.UserName != User.Identity?.Name)
                return Forbid();

            var success = _service.PatchCustomer(id, patchDto);
            if (!success)
                return BadRequest();

            return NoContent();
        }
    }
}
