using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class CuentaManager : BaseManager
    {
        private CuentaCrudFactory crudCuenta;
        private ClienteCrudFactory crudCliente;

        public CuentaManager()
        {
            crudCuenta = new CuentaCrudFactory();
            crudCliente = new ClienteCrudFactory();
        }

        public void Create(Cuenta cuenta)
        {
            try
            {
                var c = crudCuenta.Retrieve<Cuenta>(cuenta);

                if (c != null)
                {
                    //Cuenta already exist
                    throw new BussinessException(4);
                }

                if (cuenta.Saldo < 0)
                    throw new BussinessException(5);
                else
                    if (cuenta.Tipo == "A" || cuenta.Tipo == "C")
                    crudCuenta.Create(cuenta);
                else
                    throw new BussinessException(6);

            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Cuenta> RetrieveAll()
        {
            return crudCuenta.RetrieveAll<Cuenta>();
        }

        public Cuenta RetrieveById(Cuenta cuenta)
        {
            Cuenta c = null;
            try
            {
                c = crudCuenta.Retrieve<Cuenta>(cuenta);
                if (c == null)
                {
                    throw new BussinessException(7);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public void Update(Cuenta cuenta)
        {
            crudCuenta.Update(cuenta);
        }

        public void Delete(Cuenta cuenta)
        {
            crudCuenta.Delete(cuenta);
        }

        public List<Cuenta> RetrieveAllID(Cuenta cuenta)
        {
            Cliente c = new Cliente();
            c.Id = cuenta.IdCliente;
            try
            {
                c = crudCliente.Retrieve<Cliente>(c);
                if (c == null)
                {
                    throw new BussinessException(7);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
            return crudCuenta.RetrieveAllID<Cuenta>(cuenta);
        }
    }
}


