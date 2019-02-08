using System;
using System.Text;
using Xunit;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Hosting.Server;
using System.Net;
using System.Net.Http;
using AnotherOne;
using AnotherOne.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace AppvaProjectTest
{
    public class Testing : IClassFixture<WebApplicationFactory<Startup>> 
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public Testing(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetTodoItems()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/todo");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        //Should be pass if there exists one item otherwise fail
        [Fact]
        public async Task GetTodoItem()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/todo/1");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public async Task PostTodoItems()
        {
            var client = _factory.CreateClient();
            var response = await client.PostAsync("/api/todo", 
            new StringContent(
             JsonConvert.SerializeObject(new TodoItem() {Name="Test", IsDone=false }), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
