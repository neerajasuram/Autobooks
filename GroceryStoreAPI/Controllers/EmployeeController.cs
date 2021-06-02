using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using GroceryStoreAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroceryStoreAPI
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeService employeeService = null;
        public EmployeeController()
        {
            employeeService = new EmployeeService();
        }

        // GET: api/<employeeController>
        //[HttpGet("all")]
        public ActionResult<IEnumerable<Customer>> GetAll()
        {
              return employeeService.GetGStrore().customers;
        }

        // GET api/<employeeController>/5
        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            Customer foundCustomer = HelperClass.FindCustomerById(id, employeeService.GetGStrore());
            if (foundCustomer == null)
                return NotFound();

            return foundCustomer;
        }

        // POST api/<ValuesController>
        [HttpPost]
        //[Route("api/employee/post")]
        public void Post([FromBody] JsonElement jsonNewCustomer)
        {
            Customer newCustomer = HelperClass.CovertToCustomer(jsonNewCustomer);

            GStore grocessoryStore = employeeService.GetGStrore();
            Customer foundCustomer = HelperClass.FindCustomerById(newCustomer.id, grocessoryStore);

            if (foundCustomer == null)
            {
                grocessoryStore.customers.Add(newCustomer);
                employeeService.SaveGStoreData(grocessoryStore);
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string newCustomerName)
        {
            GStore grocessoryStore = employeeService.GetGStrore();
            Customer foundCustomer = HelperClass.FindCustomerById(id, grocessoryStore);

            if (foundCustomer != null)
            {
                foundCustomer.name = newCustomerName;
                employeeService.SaveGStoreData(grocessoryStore);
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            GStore grocessoryStore = employeeService.GetGStrore();
            Customer foundCustomer = HelperClass.FindCustomerById(id, grocessoryStore);

            if (foundCustomer != null)
            {
                grocessoryStore.customers.Remove(foundCustomer);
                employeeService.SaveGStoreData(grocessoryStore);
            }
        }
    }
}
