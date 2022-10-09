using WebAPI.Controllers.Connection;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using System.Linq;
using System.Net;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {
            var connection = new DatabaseConnection(new ControllerJson().jsonModel).connection;

            _products = connection.GetAll<Product>() as List<Product>;
        }

        [HttpGet("{Id}")]
        public Product Get(int Id)
        {
            if (_products.Exists(x => x.Id.Equals(Id)) == false) return null;

            return _products.FirstOrDefault(x => x.Id.Equals(Id));
        }

        [HttpPost("{Product}")]
        public void Add(Product obj)
        {
            var connection = new DatabaseConnection(new ControllerJson().jsonModel).connection;
            _products.Add(obj);
            connection.Insert<Product>(obj);
        }

        [HttpDelete("{Id}")]
        public HttpStatusCode Delete(int Id)
        {
            if (_products.Exists(x => x.Id.Equals(Id)) == false) return HttpStatusCode.NotFound;

            var connection = new DatabaseConnection(new ControllerJson().jsonModel).connection;
            connection.Delete<Product>(_products.First(x => x.Id.Equals(Id)));
            _products.Remove(_products.First(x => x.Id.Equals(Id)));

            return HttpStatusCode.OK;
        }

        /// <summary>
        /// Id - needed product. Other fields - what you need to change to
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost("{Id}/{newProduct}", Name = "Change")]
        public HttpStatusCode ChangeProduct(int Id, Product newProduct)
        {
            Console.WriteLine($"{Id.GetType()} : {Id}");
            Console.WriteLine($"{newProduct.GetType()} : {newProduct.Name}");
            if (_products.Exists(x => x.Id.Equals(Id)) == false) 
                return HttpStatusCode.NotFound;

            Delete(Id);
            Thread.Sleep(1000);
            Add(newProduct);

            return HttpStatusCode.OK;   
        }

        public List<Product> _products { private set; get; }
    }
}
