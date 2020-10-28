using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    public class OrderController : Controller
    {
        DataService.DataService service = new DataService.DataService();

        //http://localhost:5001/api/products/1
        [Route("api/products/{id}")]
        public DataService.Products GetProduct(int id)
        {
            return service.GetProduct(id);
        }

        //http://localhost:5001/api/products/category/1
        [Route("api/products/category/{id}")]
        public IEnumerable<DataService.Products> GetProductByCategory(int id)
        {
            return service.GetProductByCategory(id);
        }

        //http://localhost:5001/api/products/name/em
        [Route("api/products/name/{name}")]
        public IEnumerable<DataService.Products> GetProductByName(string name)
        {
            return service.GetProductByName(name);
        }
    }
}
