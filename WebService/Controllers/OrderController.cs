using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    public class OrderController : Controller
    {
        private readonly DataService.DataService _service = new DataService.DataService();

        //http://localhost:5001/api/products/1
        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("api/products/{id}")]
        public ActionResult GetProduct(int id)
        {
            var product = _service.GetProduct(id);
            if (product == null)
                return NotFound();
            return Ok(_service.GetProduct(id));
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        //http://localhost:5001/api/products/category/1
        [Microsoft.AspNetCore.Mvc.Route("api/products/category/{id}")]
        public ActionResult GetProductByCategory(int id)
        {
            var products = _service.GetProductByCategory(id);
            if (products.Count == 0)
                return NotFound(products);
            return Ok(products);
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        //http://localhost:5001/api/products/name/em
        [Microsoft.AspNetCore.Mvc.Route("api/products/name/{name}")]
        public ActionResult GetProductByName(string name)
        {
            var products = _service.GetProductByName(name);
            if (products.Count == 0)
                return NotFound(products);
            return Ok(products);
        }
    }
}
