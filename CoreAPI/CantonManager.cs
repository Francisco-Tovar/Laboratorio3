using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class CantonManager : BaseManager
    {
        private CantonCrudFactory crudCanton;

        public CantonManager()
        {
            crudCanton = new CantonCrudFactory();
        }

        public List<Canton> RetrieveAllID(Canton canton)
        {
            return crudCanton.RetrieveAll<Canton>(canton);
        }
    }
}



