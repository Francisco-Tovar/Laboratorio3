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
    public class DistritoController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/distrito/ - Retrieve by IdCanton
        public IHttpActionResult Get(string provincia, string canton)
        {
            try
            {
                var mng = new DistritoManager();
                apiResp = new ApiResponse();
                Distrito distrito = new Distrito();
                distrito.CantonId = canton;
                distrito.ProvinciaId = provincia;
                apiResp.Data = mng.RetrieveAllID(distrito);
                return Ok(apiResp);


            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }

    }
}

