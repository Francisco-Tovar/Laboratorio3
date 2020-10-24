using DataAcess.Crud;
using Entities_POJO;
using Exceptions;
using System;
using System.Collections.Generic;

namespace CoreAPI
{
    public class ProvinciaManager : BaseManager
    {
        private ProvinciaCrudFactory crudProvincia;

        public ProvinciaManager()
        {
            crudProvincia = new ProvinciaCrudFactory();
        }
                
        public List<Provincia> RetrieveAll()
        {
            return crudProvincia.RetrieveAll<Provincia>();
        }

    }
}




