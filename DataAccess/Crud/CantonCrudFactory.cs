﻿using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAcess.Mapper;
using DataAcess.Dao;

namespace DataAcess.Crud
{
    public class CantonCrudFactory
    {
        CantonMapper mapper;
        SqlDao dao;
        public CantonCrudFactory() : base()
        {
            mapper = new CantonMapper();
            dao = SqlDao.GetInstance();
        }
        public List<T> RetrieveAll<T>(BaseEntity entity)
        {
            var sqlOperation = mapper.GetRetriveAllStatement(entity);
            var lstCustomers = new List<T>();
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
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
