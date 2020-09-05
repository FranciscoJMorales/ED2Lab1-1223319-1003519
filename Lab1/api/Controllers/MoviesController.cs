using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Generics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        MultipathTree<Movie> Tree;

        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            if (Tree != null)
                return Tree.Inorden();
            else
                return null;
        }

        [HttpGet]
        [Route("{traversal}")]
        public IEnumerable<Movie> Get(string traversal)
        {

            if (Tree == null)
                return null;
            else if (traversal == "preorden")
                return Tree.Preorden();
            else if (traversal == "inorden")
                return Tree.Inorden();
            else if (traversal == "postorden")
                return Tree.Postorden();
            else
                return null;
        }

        [HttpPost]
        public IActionResult Create([FromForm]IFormFile file)
        {
            try
            {
                using var content = new MemoryStream();
                file.CopyToAsync(content);
                var text = Encoding.ASCII.GetString(content.ToArray());
                var deg = JsonSerializer.Deserialize<int>(text);
                Tree = new MultipathTree<Movie>(deg);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("populate")]
        public IActionResult Add([FromForm] IFormFile file)
        {
            try
            {
                using var content = new MemoryStream();
                file.CopyToAsync(content);
                var text = Encoding.ASCII.GetString(content.ToArray());
                //var list = JsonSerializer.Deserialize<List<Movie>>(text, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                var item = JsonSerializer.Deserialize<Movie>(text, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
                //foreach (Movie item in list)
                //{
                //  Tree.Add(item);
                //}
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
