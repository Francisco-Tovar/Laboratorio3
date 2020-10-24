using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class ClienteMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_ID = "ID";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_APELLIDO = "APELLIDO";
        private const string DB_COL_DOB = "DOB";
        private const string DB_COL_EDAD = "EDAD";
        private const string DB_COL_ECIVIL = "ECIVIL";
        private const string DB_COL_SEXO = "SEXO";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CLIENTE_PR" };

            var c = (Cliente)entity;
            operation.AddVarcharParam(DB_COL_ID, c.Id);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddVarcharParam(DB_COL_APELLIDO, c.Apellido);
            operation.AddDatetimeParam(DB_COL_DOB, c.DOB);
            operation.AddIntParam(DB_COL_EDAD, c.Edad);
            operation.AddVarcharParam(DB_COL_ECIVIL, c.ECivil);
            operation.AddVarcharParam(DB_COL_SEXO, c.Sexo);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CLIENTE_PR" };

            var c = (Cliente)entity;
            operation.AddVarcharParam(DB_COL_ID, c.Id);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CLIENTES_PR" };
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CLIENTE_PR" };

            var c = (Cliente)entity;
            operation.AddVarcharParam(DB_COL_ID, c.Id);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddVarcharParam(DB_COL_APELLIDO, c.Apellido);
            operation.AddDatetimeParam(DB_COL_DOB, c.DOB);
            operation.AddIntParam(DB_COL_EDAD, c.Edad);
            operation.AddVarcharParam(DB_COL_ECIVIL, c.ECivil);
            operation.AddVarcharParam(DB_COL_SEXO, c.Sexo);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CLIENTE_PR" };

            var c = (Cliente)entity;
            operation.AddVarcharParam(DB_COL_ID, c.Id);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var cliente = BuildObject(row);
                lstResults.Add(cliente);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var customer = new Cliente
            {
                Id = GetStringValue(row, DB_COL_ID),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Apellido = GetStringValue(row, DB_COL_APELLIDO),
                DOB = GetDateValue(row, DB_COL_DOB),
                Edad = GetIntValue(row, DB_COL_EDAD),
                ECivil = GetStringValue(row, DB_COL_ECIVIL),
                Sexo = GetStringValue(row, DB_COL_SEXO)
            };

            return customer;
        }

        SqlOperation ISqlStatements.GetRetriveAllIDStatement(BaseEntity entity)
        {
            throw new System.NotImplementedException();
        }
    }
}

