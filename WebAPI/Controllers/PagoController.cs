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
    public class PagoController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/pago - RetrieveALL todos los pagos existentes
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new PagoManager();
            apiResp.Data = mng.RetrieveAll();
            return Ok(apiResp);
        }
        // GET api/pago/ - Retrieve by IdPago / RetrieveALL by idCredito
        public IHttpActionResult Get(int id, int credito)
        {
            try
            {
                var mng = new PagoManager();
                // si no trae numero de credito extrae el pago id
                if (credito == 0)
                {
                    var pago = new Pago
                    {
                        IdPago = id
                    };

                    pago = mng.RetrieveById(pago);
                    apiResp = new ApiResponse();
                    apiResp.Data = pago;
                    return Ok(apiResp);
                }
                else // si trae numero de credito pide todos los pagos de la credito
                {
                    var pago = new Pago
                    {
                        IdCredito = credito
                    };

                    apiResp = new ApiResponse();
                    apiResp.Data = mng.RetrieveAllID(pago);
                    return Ok(apiResp);
                }
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        // POST - CREATE
        public IHttpActionResult Post(Pago pago)
        {
            try
            {
                var mng = new PagoManager();
                mng.Create(pago);

                apiResp = new ApiResponse();
                apiResp.Message = "Pago creado con éxito.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }
        // PUT - UPDATE
        public IHttpActionResult Put(Pago pago)
        {
            try
            {
                var mng = new PagoManager();
                mng.Update(pago);

                apiResp = new ApiResponse();
                apiResp.Message = "Pago modificada con éxito.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        // DELETE 
        public IHttpActionResult Delete(Pago pago)
        {
            try
            {
                var mng = new PagoManager();
                mng.Delete(pago);

                apiResp = new ApiResponse();
                apiResp.Message = "Pago eliminada con éxito.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}

