using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class DireccionMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_IDDIRECCION = "IDDIRECCION";
        private const string DB_COL_IDCLIENTE = "IDCLIENTE";
        private const string DB_COL_PROVINCIA = "PROVINCIA";
        private const string DB_COL_CANTON = "CANTON";
        private const string DB_COL_DISTRITO = "DISTRITO";
        private const string DB_COL_DETALLES = "DETALLES";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_DIRECCION_PR" };

            var c = (Direccion)entity;
            operation.AddVarcharParam(DB_COL_IDCLIENTE, c.IdCliente);
            operation.AddVarcharParam(DB_COL_PROVINCIA, c.Provincia);
            operation.AddVarcharParam(DB_COL_CANTON, c.Canton);
            operation.AddVarcharParam(DB_COL_DISTRITO, c.Distrito);
            operation.AddVarcharParam(DB_COL_DETALLES, c.Detalles);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_DIRECCION_PR" };

            var c = (Direccion)entity;
            operation.AddIntParam(DB_COL_IDDIRECCION, c.IdDireccion);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_DIRECCIONES_PR" };
            return operation;
        }

        public SqlOperation GetRetriveAllIDStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_DIRECCIONES_ID_PR" };
            var c = (Direccion)entity;
            operation.AddVarcharParam(DB_COL_IDCLIENTE, c.IdCliente);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_DIRECCION_PR" };

            var c = (Direccion)entity;
            operation.AddIntParam(DB_COL_IDDIRECCION, c.IdDireccion);
            operation.AddVarcharParam(DB_COL_IDCLIENTE, c.IdCliente);
            operation.AddVarcharParam(DB_COL_PROVINCIA, c.Provincia);
            operation.AddVarcharParam(DB_COL_CANTON, c.Canton);
            operation.AddVarcharParam(DB_COL_DISTRITO, c.Distrito);
            operation.AddVarcharParam(DB_COL_DETALLES, c.Detalles);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_DIRECCION_PR" };

            var c = (Direccion)entity;
            operation.AddIntParam(DB_COL_IDDIRECCION, c.IdDireccion);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var direccion = BuildObject(row);
                lstResults.Add(direccion);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var direccion = new Direccion
            {
                IdDireccion = GetIntValue(row, DB_COL_IDDIRECCION),
                IdCliente = GetStringValue(row, DB_COL_IDCLIENTE),
                Provincia = GetStringValue(row, DB_COL_PROVINCIA),
                Canton = GetStringValue(row, DB_COL_CANTON),
                Distrito = GetStringValue(row, DB_COL_DISTRITO),
                Detalles = GetStringValue(row, DB_COL_DETALLES)
            };

            return direccion;
        }

    }
}

