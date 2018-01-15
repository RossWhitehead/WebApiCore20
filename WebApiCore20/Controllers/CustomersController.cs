using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GetAll = WebApiCore20.Queries.Customer.GetAll;
using Get = WebApiCore20.Queries.Customer.Get;
using Microsoft.AspNetCore.Authorization;

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
            var model = await mediator.Send(new Get.Query(id));

            if (model == null)
            {
                return NotFound();
            }

            return Ok(model);
        }

        //// PUT: api/Customers/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCustomer([FromRoute] int id, [FromBody] Customer customer)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != customer.CustomerId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(customer).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CustomerExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: apiv1//Customers
        //[HttpPost]
        //[Produces(typeof(Customer))]
        //public async Task<IActionResult> PostCustomer([FromBody] Customer customer)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    _context.Customers.Add(customer);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        //}

        //    // DELETE: api/Customers/5
        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }

        //        var customer = await _context.Customers.SingleOrDefaultAsync(m => m.CustomerId == id);
        //        if (customer == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Customers.Remove(customer);
        //        await _context.SaveChangesAsync();

        //        return Ok(customer);
        //    }

        //    private bool CustomerExists(int id)
        //    {
        //        return _context.Customers.Any(e => e.CustomerId == id);
        //    }
    }
}