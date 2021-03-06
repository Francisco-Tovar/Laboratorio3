﻿using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class CantonMapper : EntityMapper, IObjectMapper
    {
        private const string DB_COL_PROVINCIA = "PROVINCIA";
        private const string DB_COL_CANTON = "CANTON";
        private const string DB_COL_NOMBRE = "Nombre";

        public SqlOperation GetRetriveAllStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CANTONES_PR" };
            var c = (Canton)entity;
            operation.AddVarcharParam(DB_COL_PROVINCIA, c.ProvinciaId);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var canton = BuildObject(row);
                lstResults.Add(canton);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var canton = new Canton
            {
                ProvinciaId = GetStringValue(row, DB_COL_PROVINCIA),
                CantonId = GetStringValue(row, DB_COL_CANTON),
                Nombre = GetStringValue(row, DB_COL_NOMBRE)
            };

            return canton;
        }

    }
}
