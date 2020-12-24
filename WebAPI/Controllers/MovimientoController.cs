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
    public class MovimientoController : ApiController
    {

        ApiResponse apiResp = new ApiResponse();

        // GET api/movimiento - RetrieveALL todas los movimientos existentes
        public IHttpActionResult Get()
        {
            apiResp = new ApiResponse();
            var mng = new MovimientoManager();
            apiResp.Data = mng.RetrieveAll();
            return Ok(apiResp);
        }
        // GET api/movimiento/ - Retrieve by IdMovimiento / RetrieveALL by IdCliente
        public IHttpActionResult Get(int id, int cuenta)
        {
            try
            {
                var mng = new MovimientoManager();
                // si no trae numero de cuenta extrae el movimiento id
                if (cuenta == 0)
                {
                    var movimiento = new Movimiento
                    {
                        IdMovimiento = id
                    };

                    movimiento = mng.RetrieveById(movimiento);
                    apiResp = new ApiResponse();
                    apiResp.Data = movimiento;
                    return Ok(apiResp);
                }
                else // si trae numero de cuenta pide todos los movimientos de la cuenta
                {
                    var movimiento = new Movimiento
                    {
                        IdCuenta = cuenta
                    };

                    apiResp = new ApiResponse();
                    apiResp.Data = mng.RetrieveAllID(movimiento);
                    return Ok(apiResp);
                }
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        // POST - CREATE
        public IHttpActionResult Post(Movimiento movimiento)
        {
            try
            {
                var mng = new MovimientoManager();
                mng.Create(movimiento);

                apiResp = new ApiResponse();
                apiResp.Message = "Movimiento procesado con éxito.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-"
                    + bex.AppMessage.Message));
            }
        }
        // PUT - UPDATE
        public IHttpActionResult Put(Movimiento movimiento)
        {
            try
            {
                var mng = new MovimientoManager();
                mng.Update(movimiento);

                apiResp = new ApiResponse();
                apiResp.Message = "Movimiento modificado con éxito.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
        // DELETE 
        public IHttpActionResult Delete(Movimiento movimiento)
        {
            try
            {
                var mng = new MovimientoManager();
                mng.Delete(movimiento);

                apiResp = new ApiResponse();
                apiResp.Message = "Movimiento eliminado con éxito.";

                return Ok(apiResp);
            }
            catch (BussinessException bex)
            {
                return InternalServerError(new Exception(bex.ExceptionId + "-" + bex.AppMessage.Message));
            }
        }
    }
}

