using CoreAPI;
using Entities_POJO;
using Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ExceptionFilter]
    public class ProvinciaController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/provincia - RetrieveALL todas las provincias existentes
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new ProvinciaManager();
            apiResp.Data = mng.RetrieveAll();
            return Ok(apiResp);
        }
        
    }
}

