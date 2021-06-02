using GroceryStoreAPI;
using GroceryStoreAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace XUnitTestProject
{
    public class EmployeeControllerTest
    {
        [Fact]
        public void Controller_Post_Test()
        {
            string customerString = "{\"id\":\"118\",\"name\":\"John Adams\"}";
            JsonElement element = JsonDocument.Parse(customerString).RootElement;

            EmployeeController employeeController = new EmployeeController();
            employeeController.Post(element);

            var data = employeeController.Get(118);
            Assert.Equal(118, data.Value.id);
        }

        [Theory]
        [InlineData(118)]
        [InlineData(119)]
        public void Controller_Get_Test_Exist(int id)
        {
            EmployeeController employeeController = new EmployeeController();
            var data = employeeController.Get(id);
            Assert.Equal("John Adams", data.Value.name);
        }

        [Theory]
        [InlineData(119)]
        public void Controller_Get_Test_Not_Exist(int id)
        {
            EmployeeController employeeController = new EmployeeController();
            var data = employeeController.Get(id);
            Assert.Null(data.Value);
        }


        [Theory]
        [InlineData(118)]
        public void Controller_Put_Test(int id)
        {
            string newName = "John Abraham";
            EmployeeController employeeController = new EmployeeController();
            employeeController.Put(id, newName);

            var data = employeeController.Get(id);

            Assert.Equal(data.Value.name, newName);
        }

        [Theory]
        [InlineData(118)]
        public void Controller_Delete_Test(int id)
        {
            EmployeeController employeeController = new EmployeeController();
            employeeController.Delete(id);

            var data = employeeController.Get(id);
            Assert.Null(data.Value);
        }

        [Fact]
        public void Controller_GetAll_Test()
        {
            EmployeeController employeeController = new EmployeeController();
            IEnumerable<Customer> data = employeeController.GetAll().Value;
            Assert.True(data.Count() == 1);
        }
    }
}
