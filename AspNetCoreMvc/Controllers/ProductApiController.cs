using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ITB.Shared;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreMvc.Controllers
{
    [Route("api/[controller]")]
    public class ProductApiController : Controller
    {
        private readonly IProductRepository _prodRepo;
        public ProductApiController(IProductRepository prodRepo)
        {
            _prodRepo = prodRepo;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            var products = await _prodRepo.GetProducts();
            string[] s = new string[products.LongCount() + 2];
            var i = 0;
            s[i]="[";
            i++;
            foreach (var item in products)
            {
                s[i++] = $"{{ProductId:{item.Id.ToString()},Name:{item.Name}}},";
            }
            s[i]="]";
            return s;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
