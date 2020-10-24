using System;
using System.Collections.Generic;
using Entities_POJO;
using DataAcess.Mapper;
using DataAcess.Dao;

namespace DataAcess.Crud
{
    public class MovimientoCrudFactory : CrudFactory
    {
        MovimientoMapper mapper;

        public MovimientoCrudFactory() : base()
        {
            mapper = new MovimientoMapper();
            dao = SqlDao.GetInstance();
        }

        public override void Create(BaseEntity entity)
        {
            var movimiento = (Movimiento)entity;
            var sqlOperation = mapper.GetCreateStatement(movimiento);
            dao.ExecuteProcedure(sqlOperation);
        }



        public override T Retrieve<T>(BaseEntity entity)
        {
            var sqlOperation = mapper.GetRetriveStatement(entity);
            var lstResult = dao.ExecuteQueryProcedure(sqlOperation);
            var dic = new Dictionary<string, object>();
            if (lstResult.Count > 0)
            {
                dic = lstResult[0];
                var objs = mapper.BuildObject(dic);
                return (T)Convert.ChangeType(objs, typeof(T));
            }

            return default(T);
        }

        public override List<T> RetrieveAll<T>()
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

        public override void Update(BaseEntity entity)
        {
            var movimiento = (Movimiento)entity;
            dao.ExecuteProcedure(mapper.GetUpdateStatement(movimiento));
        }

        public override void Delete(BaseEntity entity)
        {
            var movimiento = (Movimiento)entity;
            dao.ExecuteProcedure(mapper.GetDeleteStatement(movimiento));
        }

        public override List<T> RetrieveAllID<T>(BaseEntity entity)
        {
            var sqlOperation = mapper.GetRetriveAllIDStatement(entity);
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


