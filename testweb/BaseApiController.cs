using testweb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Dynamic;

namespace testweb
{
  public class BaseApiController : ApiController
  {
    //protected 

    protected DBContext db = new DBContext();


  }
}