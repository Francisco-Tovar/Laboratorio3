using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class CreditoMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_IDCREDITO = "IDCREDITO";
        private const string DB_COL_IDCLIENTE = "IDCLIENTE";
        private const string DB_COL_MONTO = "MONTO";
        private const string DB_COL_TASA = "TASA";
        private const string DB_COL_NOMBRE = "NOMBRE";
        private const string DB_COL_CUOTA = "CUOTA";
        private const string DB_COL_FECHA = "FECHA";
        private const string DB_COL_ESTADO = "ESTADO";
        private const string DB_COL_SALDO = "SALDO";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CREDITO_PR" };

            var c = (Credito)entity;
            operation.AddVarcharParam(DB_COL_IDCLIENTE, c.IdCliente);
            operation.AddDoubleParam(DB_COL_MONTO, c.Monto);
            operation.AddDoubleParam(DB_COL_TASA, c.Tasa);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddDoubleParam(DB_COL_CUOTA, c.Cuota);
            operation.AddDatetimeParam(DB_COL_FECHA, c.Fecha);
            operation.AddVarcharParam(DB_COL_ESTADO, c.Estado);
            operation.AddDoubleParam(DB_COL_SALDO, c.Saldo);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CREDITO_PR" };

            var c = (Credito)entity;
            operation.AddIntParam(DB_COL_IDCREDITO, c.IdCredito);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CREDITOS_PR" };
            return operation;
        }

        public SqlOperation GetRetriveAllIDStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CREDITOS_ID_PR" };
            var c = (Credito)entity;
            operation.AddVarcharParam(DB_COL_IDCLIENTE, c.IdCliente);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CREDITO_PR" };

            var c = (Credito)entity;
            operation.AddIntParam(DB_COL_IDCREDITO, c.IdCredito);
            operation.AddVarcharParam(DB_COL_IDCLIENTE, c.IdCliente);
            operation.AddDoubleParam(DB_COL_MONTO, c.Monto);
            operation.AddDoubleParam(DB_COL_TASA, c.Tasa);
            operation.AddVarcharParam(DB_COL_NOMBRE, c.Nombre);
            operation.AddDoubleParam(DB_COL_CUOTA, c.Cuota);
            operation.AddDatetimeParam(DB_COL_FECHA, c.Fecha);
            operation.AddVarcharParam(DB_COL_ESTADO, c.Estado);
            operation.AddDoubleParam(DB_COL_SALDO, c.Saldo);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CREDITO_PR" };

            var c = (Credito)entity;
            operation.AddIntParam(DB_COL_IDCREDITO, c.IdCredito);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var credito = BuildObject(row);
                lstResults.Add(credito);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var customer = new Credito
            {
                IdCredito = GetIntValue(row, DB_COL_IDCREDITO),
                IdCliente = GetStringValue(row, DB_COL_IDCLIENTE),
                Monto = GetDoubleValue(row, DB_COL_MONTO),
                Tasa = GetDoubleValue(row, DB_COL_TASA),
                Nombre = GetStringValue(row, DB_COL_NOMBRE),
                Cuota = GetDoubleValue(row, DB_COL_CUOTA),
                Fecha = GetDateValue(row, DB_COL_FECHA),
                Estado = GetStringValue(row, DB_COL_ESTADO),
                Saldo = GetDoubleValue(row, DB_COL_SALDO)
            };

            return customer;
        }

        
    }
}


