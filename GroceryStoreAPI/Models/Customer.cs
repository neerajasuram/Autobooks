using System.Collections.Generic;

namespace GroceryStoreAPI.Models
{
    public class Customer
    {
    
        public Customer(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int id { get; set; }
        public string name { get; set; }
    }

    public class GStore
    {
        public List<Customer> customers { get; set; }
        public GStore()
        {
            customers = new List<Customer>();
        }
    }
}
