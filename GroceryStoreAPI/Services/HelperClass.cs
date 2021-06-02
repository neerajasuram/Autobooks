using GroceryStoreAPI.Models;
using Newtonsoft.Json;
using System.Text.Json;
//using System.Text.Json;

namespace GroceryStoreAPI
{
    public class HelperClass
    {
        internal static Customer FindCustomerById(int id, GStore grocessoryStore)
        {
            Customer foundCustomer = null;
            if (grocessoryStore != null && grocessoryStore.customers != null && grocessoryStore.customers.Count > 0)
                foundCustomer = grocessoryStore.customers.Find(c => c.id == id);
            return foundCustomer;
        }

        internal static Customer CovertToCustomer(JsonElement newCustomer)
        {
            string jsonCustomer = newCustomer.ToString();
            return JsonConvert.DeserializeObject<Customer>(jsonCustomer);

        }
    }
}
