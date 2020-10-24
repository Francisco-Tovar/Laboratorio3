using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class CreditoManager : BaseManager
    {
        private CreditoCrudFactory crudCredito;
        private ClienteCrudFactory crudCliente;

        public CreditoManager()
        {
            crudCredito = new CreditoCrudFactory();
            crudCliente = new ClienteCrudFactory();
        }

        public void Create(Credito credito)
        {
            try
            {
                var c = crudCredito.Retrieve<Credito>(credito);

                if (c != null)
                {
                    //Credito already exist
                    throw new BussinessException(8);
                }else
                    crudCredito.Create(credito);


            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Credito> RetrieveAll()
        {
            return crudCredito.RetrieveAll<Credito>();
        }

        public Credito RetrieveById(Credito credito)
        {
            Credito c = null;
            try
            {
                c = crudCredito.Retrieve<Credito>(credito);
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

        public void Update(Credito credito)
        {
            crudCredito.Update(credito);
        }

        public void Delete(Credito credito)
        {
            crudCredito.Delete(credito);
        }

        public List<Credito> RetrieveAllID(Credito credito)
        {
            Cliente c = new Cliente();
            c.Id = credito.IdCliente;
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
            return crudCredito.RetrieveAllID<Credito>(credito);
        }
    }
}
