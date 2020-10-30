using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using DataService;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace WebService.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly DataService.DataService _service = new DataService.DataService();

        [HttpGet]
        [Route("api/categories")]
        public  ActionResult GetCategories()
        {
            var categories = _service.GetCategories().ToArray();
            if (categories.Length == 0)
                return NotFound();
            return Ok(categories);
        }

        [HttpGet]
        [Route("api/categories/{id}")]
        public ActionResult GetCategory(int id)
        {
            var category = _service.GetCategory(id);
            if (category == null)
                return NotFound();
            return Ok(category);
        }

        [HttpPost]
        [Route("api/categories/")]
        public CreatedResult CreateCategory([FromBody]JsonElement post)
        {
            var incomingPost = JObject.Parse((post.ToString()));
            var postDescription = incomingPost["Description"];
            var postName = incomingPost["Name"];

            Categories category = _service.CreateCategory((string)postName, (string)postDescription);
            category = _service.GetCategory(category.Categoryid);
            return new CreatedResult("created", category);

            //Fix this for god's sake
            //Parse the JsonElement with JObject
            /*var stringname = JsonSerializer.Serialize(name);
            var names = stringname.Split(":");
            var name1 = names[1];
            var name2 = names[2];

            var names2 = name1.Split(",");
            var name3 = names2[0];
            name3 = name3.Substring(1, name3.Length-2);
            name2 = name2.Substring(0, name2.Length-1);
            Categories category = _service.CreateCategory(name3, name2);
            category = _service.GetCategory(category.Categoryid);

            //return Ok(category);

            return new CreatedResult("created", category);*/
        }

        [HttpDelete]
        [Route("api/categories/{id}")]
        public ActionResult DeleteCategory(int id = 9)
        {
            var category = _service.GetCategory(id);
            if (category == null)
                return NotFound();
            return Ok(_service.DeleteCategory(id));
        }

        [HttpPut]
        [Route("api/categories/{id}")]
        public ActionResult UpdateCategory(int id, [FromBody] JsonElement element)
        {
            //Clean this up a bit
            var update = JObject.Parse((element.ToString()));
            var updateid = update["Id"];
            var updatedescription = update["Description"];
            var updatename = update["Name"];
            var category = _service.GetCategory(id);

            if (category == null)
                return NotFound();
            return Ok(_service.UpdateCategory((Int16)updateid, (string)updatename, (string)updatedescription));
        }
    }
}
