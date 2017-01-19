using ASPM.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ASPM.WebAPI.Controllers
{
    [EnableCors("http://localhost:60852", "*","*")]
    public class ProductsController : ApiController
    {

        private ProductRepository repo = new ProductRepository();
        // GET: api/Products
        public IEnumerable<Product> Get()
        {
            return repo.Retrieve();
        }

        // GET: api/Products/5
        public string Get(int id)
        {

            return "Value";
        }

        // POST: api/Products
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
