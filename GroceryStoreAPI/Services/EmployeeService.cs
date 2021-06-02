using GroceryStoreAPI.Models;
using Newtonsoft.Json;
using System.IO;

namespace GroceryStoreAPI
{
    public class EmployeeService
    {
        private string FilePath { get; set; }
        internal EmployeeService()
        {
            FilePath = Directory.GetCurrentDirectory() + "\\" + "database.json";
        }

        internal GStore GetGStrore()
        {
            var jsonData = System.IO.File.ReadAllText(FilePath);
            GStore grocessoryStore = JsonConvert.DeserializeObject<GStore>(jsonData);
            if (grocessoryStore == null)
                grocessoryStore = new GStore();


            return grocessoryStore;
        }

        internal void SaveGStoreData(GStore jsonData)
        {
            string jsonGStoreData = System.Text.Json.JsonSerializer.Serialize(jsonData);
            File.WriteAllText(FilePath, jsonGStoreData);
        }
    }
}
