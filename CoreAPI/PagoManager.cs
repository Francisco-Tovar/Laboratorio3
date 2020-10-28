using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class PagoManager : BaseManager
    {
        private PagoCrudFactory crudPago;
        private CreditoCrudFactory crudCredito;
        
        public PagoManager()
        {
            crudPago = new PagoCrudFactory();
            crudCredito = new CreditoCrudFactory();
        }

        public void Create(Pago pago)
        {
            try
            {
                var c = crudPago.Retrieve<Pago>(pago);

                if (c != null)
                {
                    //Pago already exist
                    throw new BussinessException(12);
                }
                else 
                {
                    Credito cred = new Credito();
                    cred.IdCredito = pago.IdCredito;
                    cred = crudCredito.Retrieve<Credito>(cred);

                    if (cred.Saldo >= pago.Monto || pago.Operacion.Equals("Cargo"))
                    {
                        pago.Fecha = DateTime.Now;
                        crudPago.Create(pago);
                        if (pago.Operacion.Equals("Cargo"))
                        {
                            cred.Saldo += pago.Monto;
                        } else if (pago.Operacion.Equals("Pago"))
                        {
                            cred.Saldo -= pago.Monto;
                        }
                        crudCredito.Update(cred);
                    }
                    else
                        throw new BussinessException(14);


                }
                    

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Pago> RetrieveAll()
        {
            return crudPago.RetrieveAll<Pago>();
        }

        public Pago RetrieveById(Pago pago)
        {
            Pago c = null;
            try
            {
                c = crudPago.Retrieve<Pago>(pago);
                if (c == null)
                {
                    throw new BussinessException(13);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public void Update(Pago pago)
        {
            crudPago.Update(pago);
        }

        public void Delete(Pago pago)
        {
            crudPago.Delete(pago);
        }

        public List<Pago> RetrieveAllID(Pago pago)
        {
            Credito c = null;
            c.IdCredito = pago.IdCredito;
            try
            {
                c = crudCredito.Retrieve<Credito>(c);
                if (c == null)
                {
                    throw new BussinessException(13);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return crudPago.RetrieveAllID<Pago>(pago);
        }
    }
}


