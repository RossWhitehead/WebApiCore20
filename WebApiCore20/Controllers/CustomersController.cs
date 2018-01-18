using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Create = WebApiCore20.Commands.Customer.Create;
using Delete = WebApiCore20.Commands.Customer.Delete;
using Get = WebApiCore20.Queries.Customer.Get;
using GetAll = WebApiCore20.Queries.Customer.GetAll;
using Update = WebApiCore20.Commands.Customer.Update;

namespace WebApiCore20.Controllers
{
    [Produces("application/json")]
    [Route("api/v1/Customers")]
    public class CustomersController : Controller
    {
        private IMediator mediator;

        public CustomersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET: api/v1/Customers
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var queryResult = await mediator.Send(new GetAll.Query());
            return Ok(queryResult);
        }

        // GET: api/v1/Customers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {
            var customer = await QueryCustomer(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        // PUT: api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer([FromRoute] int id, [FromBody] Update.Command updateCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != updateCommand.CustomerId)
            {
                return BadRequest();
            }

            var customer = await QueryCustomer(id);

            if (customer == null)
            {
                return NotFound();
            }

            var commandResult = await mediator.Send(updateCommand);

            return NoContent();
        }

        // POST: api/v1/Customers
        [HttpPost]
        [Produces(typeof(Get.QueryResult))]
        public async Task<IActionResult> PostCustomer([FromBody] Create.Command createCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var commandResult = await mediator.Send(createCommand);

            var customer = await QueryCustomer(commandResult.Result);

            return CreatedAtAction("PostCustomer", new { id = commandResult.Result }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = await QueryCustomer(id);

            if (customer == null)
            {
                return NotFound();
            }

            var commandResult = await mediator.Send(new Delete.Command { CustomerId = id });

            return Ok(customer);
        }

        private async Task<Get.QueryResult> QueryCustomer(int id)
        {
            return await mediator.Send(new Get.Query(id));
        }
    }
}