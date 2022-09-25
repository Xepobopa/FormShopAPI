using WebAPI.Controllers.Connection;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using System.Linq;

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

        public List<Product> _products { private set; get; }
    }
}
