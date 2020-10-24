using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAcess.Mapper;
using DataAcess.Dao;

namespace DataAcess.Crud
{
    public class ProvinciaCrudFactory 
    {
        ProvinciaMapper mapper;
        SqlDao dao;
        public ProvinciaCrudFactory() : base()
        {
            mapper = new ProvinciaMapper();
            dao = SqlDao.GetInstance();
        }
        public List<T> RetrieveAll<T>()
        {
            var lstCustomers = new List<T>();

            var lstResult = dao.ExecuteQueryProcedure(mapper.GetRetriveAllStatement());
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                var objs = mapper.BuildObjects(lstResult);
                foreach (var c in objs)
                {
                    lstCustomers.Add((T)Convert.ChangeType(c, typeof(T)));
                }
            }

            return lstCustomers;
        }

    }
}



