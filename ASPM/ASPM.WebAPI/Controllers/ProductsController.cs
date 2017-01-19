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

        public IEnumerable<Product> Get(string search)
        {
            return repo.Retrieve().Where(p=>p.ProductCode.Contains(search));
        }

        // GET: api/Products/5
        public Product Get(int id)
        {
            Product product;
            if (id > 0)
            {
                product = repo.Retrieve().FirstOrDefault(p => p.ProductId == id);
            }

            else
            {
                product = repo.Create();
            }
            return product;
        }

        // POST: api/Products
        public void Post([FromBody]Product product )
        {
            var newProduct = repo.Save(product);
        }

        // PUT: api/Products/5
        public void Put(int id, [FromBody]Product product)
        {
            var updateProduct = repo.Save(id,product);

        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
