using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EntityAbstractions.Entities;
using Microsoft.AspNetCore.Mvc;
using EntityManagerAbstractions.EntityManagers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        IEntityManager<AbstractCustomer> _customerManager;

        public CustomerController(IEntityManager<AbstractCustomer> customerManager)
        {
            _customerManager = customerManager;
        }

        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<string> Post([FromBody] AbstractCustomer customer)
        {
            return await _customerManager.InsertAsync(customer);            
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
