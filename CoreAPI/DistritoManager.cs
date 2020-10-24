using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class DistritoManager : BaseManager
    {
        private DistritoCrudFactory crudDistrito;

        public DistritoManager()
        {
            crudDistrito = new DistritoCrudFactory();
        }

        public List<Distrito> RetrieveAllID(Distrito distrito)
        {
            return crudDistrito.RetrieveAll<Distrito>(distrito);
        }
    }
}
