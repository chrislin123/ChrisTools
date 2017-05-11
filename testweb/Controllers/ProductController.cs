using testweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Runtime.Serialization.Json;
//using System.Web.Mvc;
//using System.Web.Http;

namespace testweb.Controllers
{
    public class ProductController : ApiController
    {
      Product[] products = new Product[]
          {
              new Product { Id = 1, Name = "Tomato Soup1111", Category = "Groceries", Price = 1 },
              new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
              new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
          };

    public IEnumerable<Product> GetAllProducts()
    {


      return products;
    }

    //[RoutePrefix("api/Account")]
    //public IEnumerable<Product> GetAllProductsTest()
    //{

    //  return new List<Product>();
    //}
      //bool isSuccessful = false;
      //if (ModelState.IsValid)
      //{
      //  isSuccessful = SubscribeEmail(newsletter.Email);
      //}



      //  return Json(products);
      //}

      //  public ActionResult GetAllProducts()
      //  {

      //    new JsonResult(
      //    return JsonResult(products);
      //}

    public IHttpActionResult GetProduct(int id)
      {
        var product = products.FirstOrDefault((p) => p.Id == id);
        if (product == null)
        {
          return NotFound();
        }
        return Ok(product);
      }
  }
}
