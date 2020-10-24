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
    public class CuentaController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/cuenta - RetrieveALL todas las cuentas existentes
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new CuentaManager();
            apiResp.Data = mng.RetrieveAll();
            return Ok(apiResp);
        }
        // GET api/cuenta/ - Retrieve by IdCuenta / RetrieveALL by IdCliente
        public IHttpActionResult Get(int id, string cliente)
        {
            try
            {
                var mng = new CuentaManager();

                if (cliente == null)
                {
                    var cuenta = new Cuenta
                    {
                        IdCuenta = id
                    };

                    cuenta = mng.RetrieveById(cuenta);
                    apiResp = new ApiResponse();
                    apiResp.Data = cuenta;
                    return Ok(apiResp);
                }
                else 
                {
                    var cuenta = new Cuenta
                    {
                        IdCliente = cliente
                    };

                    apiResp = new ApiResponse();
                    apiResp.Data = mng.RetrieveAllID(cuenta);
                    return Ok(apiResp);
                }                
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        // POST - CREATE
        public IHttpActionResult Post(Cuenta cuenta)
        {
            try
            {
                var mng = new CuentaManager();
                mng.Create(cuenta);

                apiResp = new ApiResponse();
                apiResp.Message = "Cuenta creada con éxito.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }
        // PUT - UPDATE
        public IHttpActionResult Put(Cuenta cuenta)
        {
            try
            {
                var mng = new CuentaManager();
                mng.Update(cuenta);

                apiResp = new ApiResponse();
                apiResp.Message = "Cuenta modificada con éxito.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        // DELETE 
        public IHttpActionResult Delete(Cuenta cuenta)
        {
            try
            {
                var mng = new CuentaManager();
                mng.Delete(cuenta);

                apiResp = new ApiResponse();
                apiResp.Message = "Cuenta eliminada con éxito.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}

