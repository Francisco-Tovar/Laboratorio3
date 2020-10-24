using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class ProvinciaMapper : EntityMapper, IObjectMapper
    {
        private const string DB_COL_COD = "Cod";
        private const string DB_COL_NOMBRE = "Nombre";

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_PROVINCIAS_PR" };
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var provincia = BuildObject(row);
                lstResults.Add(provincia);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var provincia = new Provincia
            {
                Cod = GetStringValue(row, DB_COL_COD),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),    
            };

            return provincia;
        }

    }
}


