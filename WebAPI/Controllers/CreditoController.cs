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
    public class CreditoController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/credito - RetrieveALL todas las creditos existentes
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new CreditoManager();
            apiResp.Data = mng.RetrieveAll();
            return Ok(apiResp);
        }
        // GET api/credito/ - Retrieve by IdCredito / RetrieveALL by IdCliente
        public IHttpActionResult Get(int id, string cliente)
        {
            try
            {
                var mng = new CreditoManager();

                if (cliente == null)
                {
                    var credito = new Credito
                    {
                        IdCredito = id
                    };

                    credito = mng.RetrieveById(credito);
                    apiResp = new ApiResponse();
                    apiResp.Data = credito;
                    return Ok(apiResp);
                }
                else
                {
                    var credito = new Credito
                    {
                        IdCliente = cliente
                    };

                    apiResp = new ApiResponse();
                    apiResp.Data = mng.RetrieveAllID(credito);
                    return Ok(apiResp);
                }
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        // POST - CREATE
        public IHttpActionResult Post(Credito credito)
        {
            try
            {
                var mng = new CreditoManager();
                mng.Create(credito);

                apiResp = new ApiResponse();
                apiResp.Message = "Credito creado con éxito.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }
        // PUT - UPDATE
        public IHttpActionResult Put(Credito credito)
        {
            try
            {
                var mng = new CreditoManager();
                mng.Update(credito);

                apiResp = new ApiResponse();
                apiResp.Message = "Credito modificado con éxito.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        // DELETE 
        public IHttpActionResult Delete(Credito credito)
        {
            try
            {
                var mng = new CreditoManager();
                mng.Delete(credito);

                apiResp = new ApiResponse();
                apiResp.Message = "Credito eliminado con éxito.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}

