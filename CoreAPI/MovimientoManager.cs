using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class MovimientoManager : BaseManager
    {
        private MovimientoCrudFactory crudMovimiento;
        private CuentaCrudFactory crudCuenta;

        public MovimientoManager()
        {
            crudMovimiento = new MovimientoCrudFactory();
            crudCuenta = new CuentaCrudFactory();
        }

        public void Create(Movimiento movimiento)
        {
            try
            {
                var c = crudMovimiento.Retrieve<Movimiento>(movimiento);

                if (c != null)
                {
                    //Movimiento already exist
                    throw new BussinessException(12);
                }
                else
                {
                    Cuenta cuenta = new Cuenta();
                    cuenta.IdCuenta = movimiento.IdCuenta;
                    cuenta = crudCuenta.Retrieve<Cuenta>(cuenta);

                    if (cuenta.Saldo >= Math.Abs(movimiento.Monto) || movimiento.Tipo.Equals("1"))
                    {
                        movimiento.Fecha = DateTime.Now;
                        crudMovimiento.Create(movimiento);
                        if (movimiento.Tipo.Equals("1"))
                        {
                            cuenta.Saldo += movimiento.Monto;
                        } else if (movimiento.Tipo.Equals("2")) 
                        {
                            cuenta.Saldo -= movimiento.Monto;
                        }


                        crudCuenta.Update(cuenta);
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

        public List<Movimiento> RetrieveAll()
        {
            return crudMovimiento.RetrieveAll<Movimiento>();
        }

        public Movimiento RetrieveById(Movimiento movimiento)
        {
            Movimiento c = null;
            try
            {
                c = crudMovimiento.Retrieve<Movimiento>(movimiento);
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

        public void Update(Movimiento movimiento)
        {
            crudMovimiento.Update(movimiento);
        }

        public void Delete(Movimiento movimiento)
        {
            crudMovimiento.Delete(movimiento);
        }

        public List<Movimiento> RetrieveAllID(Movimiento movimiento)
        {
            Cuenta c = new Cuenta();
            c.IdCuenta = movimiento.IdCuenta;
            try
            {
                c = crudCuenta.Retrieve<Cuenta>(c);
                if (c == null)
                {
                    throw new BussinessException(13);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return crudMovimiento.RetrieveAllID<Movimiento>(movimiento);
        }
    }
}



