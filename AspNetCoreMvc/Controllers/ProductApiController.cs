using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ITB.Shared;
using System.Net.Http;
using System.Net;

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
        public async Task<IEnumerable<string>> Get([FromQuery] int id)
        {
            if (id == 0)
            {
                var products = await _prodRepo.GetProducts();
                string[] s = new string[products.LongCount()];
                var i = 0;
                foreach (var item in products)
                {
                    s[i++] = $"ProductId:{item.Id.ToString()},Name:{item.Name}";
                }
                return s;
            }
            else
            {
                var product = _prodRepo.GetProduct(id);
                return (product == null) ? new string[0] { } : new string[] { $"ProductId:{product.Id.ToString()},Name:{product.Name}" };
            }
        }
        /* 
                // GET api/<controller>/5
                [HttpGet("{id}")]
                public string Get([FromQuery] int id)
                {
                    var prod = _prodRepo.GetProduct(id);
                    return $"{prod.Id.ToString()},{prod.Name}";
                }
        */
        // POST api/<controller>
        [HttpPost]
        public HttpResponseMessage Post([FromBody] string name)
        {
            var responseError = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            var responseOk = new HttpResponseMessage(HttpStatusCode.OK);

            if (name == null)
            {
                responseError.ReasonPhrase = $"Name is Null";
                return responseError;
            }
            var prod = new Product { Name = name };
            var result = _prodRepo.AddProduct(prod);
            if (result > 0)
            {
                responseOk.ReasonPhrase = $"Product:'{name}' Was Added";
                return responseOk;
            }
            else
            {
                responseOk.ReasonPhrase = $"Product:{name} Was Not Added";
                return responseError;
            }
        }

        // PUT api/<controller>/
        [HttpPut]
        public HttpResponseMessage Put([FromQuery] int id, [FromBody] string name)
        {
            var responseError = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            var responseOk = new HttpResponseMessage(HttpStatusCode.OK);

            if (id == 0 || name == null)
            {
                responseError.ReasonPhrase = $"ProductId:{id} is Zero or Name is Null";
                return responseError;
            }
            var prod = new Product { Id = id, Name = name };
            var result = _prodRepo.UpdateProduct(prod);
            if (result > 0)
            {
                responseOk.ReasonPhrase = $"ProductId:{id} Was Updated";
                return responseOk; ;
            }
            else
            {
                responseError.ReasonPhrase = $"ProductId:{id} Not Found in Database";
                return responseError;
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public HttpResponseMessage Delete([FromQuery]int id)
        {
            var responseError = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            var responseOk = new HttpResponseMessage(HttpStatusCode.OK);

            if (id == 0)
            {
                responseOk.ReasonPhrase = $"ProductId:{id} is Zero";
                return responseError;
            }
            var result = _prodRepo.DeleteProduct(id);
            if (result > 0)
            {
                responseOk.ReasonPhrase = $"ProductId:{id} Was Deleted";
                return responseOk;
            }
            else
            {
                responseError.ReasonPhrase = $"ProductId:{id} Not Found in Database";
                return responseError;
            }
        }
    }
}
