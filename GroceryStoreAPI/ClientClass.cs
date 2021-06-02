using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using GroceryStoreAPI.Models;


namespace GroceryStoreAPI
{
    public class ClientClass
    {
        public ClientClass()
        {

        }

        public void InvokeAPI()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:58196/api/employee");
                var responseTask = client.GetAsync("http://localhost:58196/api/employee");

                //client.GetAsync
            }
        }
       

    }
  }
