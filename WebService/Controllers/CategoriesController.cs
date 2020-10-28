using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace WebService.Controllers
{
    public class CategoriesController : Controller
    {
        DataService.DataService service = new DataService.DataService();

        [HttpGet]
        //http://localhost:5001/api/categories
        [Route("api/categories")]
        public IEnumerable<DataService.Categories> GetCategories()
        {
            return service.GetCategories().ToArray();
        }

        //http://localhost:5001/api/categories/1
        [Route("api/categories/{id}")]
        public DataService.Categories GetCategory(int id)
        {
            return service.GetCategory(id);
        }

        //http://localhost:5001/api/categories/create/smed+smed
        [Route("api/categories/create/{name}+{description}")]
        public DataService.Categories Details(string name,  string description)
        {
            return service.CreateCategory(name, description);
        }

        //http://localhost:5001/api/categories/delete/10
        [Route("api/categories/delete/{id}")]
        public bool DeleteCategory(int id)
        {
            return service.DeleteCategory(id);
        }

        [Route("api/categories/update/{id}+{name}+{description}")]
        //http://localhost:5001/api/categories/update/9+smed2+smed2
        public bool UpdateCategory(int id, string name, string description)
        {
            return service.UpdateCategory(id, name, description);
        }
    }
}
