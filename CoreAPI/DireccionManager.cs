using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class DireccionManager : BaseManager
    {
        private DireccionCrudFactory crudDireccion;
        private ClienteCrudFactory crudCliente;

        public DireccionManager()
        {
            crudDireccion = new DireccionCrudFactory();
            crudCliente = new ClienteCrudFactory();
        }

        public void Create(Direccion direccion)
        {
            try
            {
                Cliente temp = new Cliente();
                temp.Id = direccion.IdCliente;
                var c = crudCliente.Retrieve<Cliente>(temp);

                if (c == null)
                {                    
                    throw new BussinessException(1);
                }
                else {
                    var b = crudDireccion.Retrieve<Direccion>(direccion);
                    if (b != null)
                    {
                        throw new BussinessException(10);
                    }                                
                }
                    crudDireccion.Create(direccion);
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }
        }

        public List<Direccion> RetrieveAll()
        {
            return crudDireccion.RetrieveAll<Direccion>();
        }

        public Direccion RetrieveById(Direccion direccion)
        {
            Direccion c = null;
            try
            {
                c = crudDireccion.Retrieve<Direccion>(direccion);
                if (c == null)
                {
                    throw new BussinessException(11);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GetInstance().Process(ex);
            }

            return c;
        }

        public void Update(Direccion direccion)
        {
            crudDireccion.Update(direccion);
        }

        public void Delete(Direccion direccion)
        {
            crudDireccion.Delete(direccion);
        }

        public List<Direccion> RetrieveAllID(Direccion direccion)
        {
            Cliente c = new Cliente();
            c.Id = direccion.IdCliente;
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
            return crudDireccion.RetrieveAllID<Direccion>(direccion);
        }
    }
}

