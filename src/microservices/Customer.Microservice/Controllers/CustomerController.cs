using System.Threading.Tasks;
using Customer.Microservice.Features.CustomerFeatures.Commands.CreateProduct;
using Customer.Microservice.Features.CustomerFeatures.Commands.DeleteProductById;
using Customer.Microservice.Features.CustomerFeatures.Commands.UpdateProduct;
using Customer.Microservice.Features.CustomerFeatures.Queries.GetAllProducts;
using Customer.Microservice.Features.CustomerFeatures.Queries.GetProduct;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ApiController
    {
        /// <summary>
        /// Creates a New Customer
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(new GetAllCustomersQuery()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetCustomerByIdQuery { Id = id }));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteCustomerByIdCommand { Id = id }));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateCustomerCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }
    }
}
