using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    public class OrderController : Controller
    {
        private readonly DataService.DataService _service = new DataService.DataService();

        //http://localhost:5001/api/products/1
        [Route("api/products/{id}")]
        public DataService.Products GetProduct(int id) => _service.GetProduct(id);

        //http://localhost:5001/api/products/category/1
        [Route("api/products/category/{id}")]
        public IEnumerable<DataService.Products> GetProductByCategory(int id) => _service.GetProductByCategory(id);

        //http://localhost:5001/api/products/name/em
        [Route("api/products/name/{name}")]
        public IEnumerable<DataService.Products> GetProductByName(string name) => _service.GetProductByName(name);
    }
}
