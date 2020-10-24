
using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class ClienteManager : BaseManager
    {
        private ClienteCrudFactory crudCliente;

        public ClienteManager()
        {
            crudCliente = new ClienteCrudFactory();
        }

        public void Create(Cliente customer)
        {
            try
            {
                var c = crudCliente.Retrieve<Cliente>(customer);

                if (c != null)
                {
                    //Cliente already exist
                    throw new BussinessException(3);
                }
                var fecha = DateTime.Compare(DateTime.Now, customer.DOB);
                if (fecha <= 0 ) 
                {
                    throw new BussinessException(15);
                }

                if (customer.Edad >= 18)
                    crudCliente.Create(customer);
                else
                    throw new BussinessException(2);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Cliente> RetrieveAll()
        {
            return crudCliente.RetrieveAll<Cliente>();
        }

        public Cliente RetrieveById(Cliente customer)
        {
            Cliente c = null;
            try
            {
                c = crudCliente.Retrieve<Cliente>(customer);
                if (c == null)
                {
                    throw new BussinessException(4);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public void Update(Cliente customer)
        {
            crudCliente.Update(customer);
        }

        public void Delete(Cliente customer)
        {
            crudCliente.Delete(customer);
        }
    }
}

