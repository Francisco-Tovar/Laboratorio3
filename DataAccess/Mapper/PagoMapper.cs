using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class PagoMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_IDPAGO = "IDPAGO";
        private const string DB_COL_IDCREDITO = "IDCREDITO";
        private const string DB_COL_FECHA = "FECHA";
        private const string DB_COL_OPERACION = "OPERACION";
        private const string DB_COL_MONTO = "MONTO";
        
        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_PAGO_PR" };

            var c = (Pago)entity;
            operation.AddIntParam(DB_COL_IDCREDITO, c.IdCredito);
            operation.AddDatetimeParam(DB_COL_FECHA, c.Fecha);
            operation.AddVarcharParam(DB_COL_OPERACION, c.Operacion);
            operation.AddDoubleParam(DB_COL_MONTO, c.Monto);
            
            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_PAGO_PR" };

            var c = (Pago)entity;
            operation.AddIntParam(DB_COL_IDPAGO, c.IdPago);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_PAGOS_PR" };
            return operation;
        }

        public SqlOperation GetRetriveAllIDStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_PAGOS_ID_PR" };
            var c = (Pago)entity;
            operation.AddIntParam(DB_COL_IDCREDITO, c.IdCredito);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_PAGO_PR" };

            var c = (Pago)entity;
            operation.AddIntParam(DB_COL_IDPAGO, c.IdPago);
            operation.AddIntParam(DB_COL_IDCREDITO, c.IdCredito);
            operation.AddDatetimeParam(DB_COL_FECHA, c.Fecha);
            operation.AddVarcharParam(DB_COL_OPERACION, c.Operacion);
            operation.AddDoubleParam(DB_COL_MONTO, c.Monto);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_PAGO_PR" };

            var c = (Pago)entity;
            operation.AddIntParam(DB_COL_IDPAGO, c.IdPago);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var pago = BuildObject(row);
                lstResults.Add(pago);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var pago = new Pago
            {
                IdPago = GetIntValue(row, DB_COL_IDPAGO),
                IdCredito = GetIntValue(row, DB_COL_IDCREDITO),
                Fecha = GetDateValue(row, DB_COL_FECHA),
                Operacion = GetStringValue(row, DB_COL_OPERACION),
                Monto= GetDoubleValue(row, DB_COL_MONTO)                
            };

            return pago;
        }

    }
}

