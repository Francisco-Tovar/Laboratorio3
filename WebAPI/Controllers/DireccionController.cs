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
    public class DireccionController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/direccion - RetrieveALL todas las direccions existentes
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new DireccionManager();
            apiResp.Data = mng.RetrieveAll();
            return Ok(apiResp);
        }
        // GET api/direccion/ - Retrieve by IdDireccion / RetrieveALL by IdCliente
        public IHttpActionResult Get(int id, string cliente)
        {
            try
            {
                var mng = new DireccionManager();

                if (cliente == null)
                {
                    var direccion = new Direccion
                    {
                        IdDireccion = id
                    };

                    direccion = mng.RetrieveById(direccion);
                    apiResp = new ApiResponse();
                    apiResp.Data = direccion;
                    return Ok(apiResp);
                }
                else
                {
                    var direccion = new Direccion
                    {
                        IdCliente = cliente
                    };

                    apiResp = new ApiResponse();
                    apiResp.Data = mng.RetrieveAllID(direccion);
                    return Ok(apiResp);
                }
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        // POST - CREATE
        public IHttpActionResult Post(Direccion direccion)
        {
            try
            {
                var mng = new DireccionManager();
                mng.Create(direccion);

                apiResp = new ApiResponse();
                apiResp.Message = "Direccion creada con éxito.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }
        // PUT - UPDATE
        public IHttpActionResult Put(Direccion direccion)
        {
            try
            {
                var mng = new DireccionManager();
                mng.Update(direccion);

                apiResp = new ApiResponse();
                apiResp.Message = "Direccion modificada con éxito.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        // DELETE 
        public IHttpActionResult Delete(Direccion direccion)
        {
            try
            {
                var mng = new DireccionManager();
                mng.Delete(direccion);

                apiResp = new ApiResponse();
                apiResp.Message = "Direccion eliminada con éxito.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}

