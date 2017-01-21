using ASPM.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace ASPM.WebAPI.Controllers
{
    [EnableCors("http://localhost:60852", "*","*")]
    public class ProductsController : ApiController
    {

        private ProductRepository repo = new ProductRepository();

       
        [ResponseType(typeof(Product))]
        public IHttpActionResult Get()
        {
            try
            {
               
                return Ok(repo.Retrieve().AsQueryable());

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        public IEnumerable<Product> Get(string search)
        {
            return repo.Retrieve().Where(p=>p.ProductCode.Contains(search));
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Product product;
                if (id > 0)
                {
                    var products = repo.Retrieve();
                    product = products.FirstOrDefault(p => p.ProductId == id);
                    if (product == null)
                    {
                        return NotFound();
                    }
                }
                else
                {
                    product = repo.Create();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult Post([FromBody]Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product cannot be null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var newProduct = repo.Save(product);
                if (newProduct == null)
                {
                    return Conflict();
                }
                return Created<Product>(Request.RequestUri + newProduct.ProductId.ToString(),
                    newProduct);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Products/5
        public IHttpActionResult Put(int id, [FromBody]Product product)
        {
            try
            {
                if (product == null)
                {
                    return BadRequest("Product cannot be null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var updatedProduct = repo.Save(id, product);
                if (updatedProduct == null)
                {
                    return NotFound();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE: api/Products/5
        public void Delete(int id)
        {
        }
    }
}
