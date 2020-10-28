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
    public class CantonController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/canton/ - Retrieve by IdProvincia
        public IHttpActionResult Get(string provincia)
        {
            try
            {
                var mng = new CantonManager();
                apiResp = new ApiResponse();
                Canton canton = new Canton();
                canton.ProvinciaId = provincia;
                apiResp.Data = mng.RetrieveAllID(canton);
                return Ok(apiResp);


            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

    }
}

