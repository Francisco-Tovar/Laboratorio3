using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class MovimientoMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_IDMOVIMIENTO = "IDMOVIMIENTO";
        private const string DB_COL_IDCUENTA = "IDCUENTA";
        private const string DB_COL_FECHA = "FECHA";
        private const string DB_COL_TIPO = "TIPO";
        private const string DB_COL_MONTO = "MONTO";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_MOVIMIENTO_PR" };

            var c = (Movimiento)entity;
            operation.AddIntParam(DB_COL_IDCUENTA, c.IdCuenta);
            operation.AddDatetimeParam(DB_COL_FECHA, c.Fecha);
            operation.AddVarcharParam(DB_COL_TIPO, c.Tipo);
            operation.AddDoubleParam(DB_COL_MONTO, c.Monto);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_MOVIMIENTO_PR" };

            var c = (Movimiento)entity;
            operation.AddIntParam(DB_COL_IDMOVIMIENTO, c.IdMovimiento);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_MOVIMIENTOS_PR" };
            return operation;
        }

        public SqlOperation GetRetriveAllIDStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_MOVIMIENTOS_ID_PR" };
            var c = (Movimiento)entity;
            operation.AddIntParam(DB_COL_IDCUENTA, c.IdCuenta);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_MOVIMIENTO_PR" };

            var c = (Movimiento)entity;
            operation.AddIntParam(DB_COL_IDMOVIMIENTO, c.IdMovimiento);
            operation.AddIntParam(DB_COL_IDCUENTA, c.IdCuenta);
            operation.AddDatetimeParam(DB_COL_FECHA, c.Fecha);
            operation.AddVarcharParam(DB_COL_TIPO, c.Tipo);
            operation.AddDoubleParam(DB_COL_MONTO, c.Monto);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_MOVIMIENTO_PR" };

            var c = (Movimiento)entity;
            operation.AddIntParam(DB_COL_IDMOVIMIENTO, c.IdMovimiento);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var movimiento = BuildObject(row);
                lstResults.Add(movimiento);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var movimiento = new Movimiento
            {
                IdMovimiento = GetIntValue(row, DB_COL_IDMOVIMIENTO),
                IdCuenta = GetIntValue(row, DB_COL_IDCUENTA),
                Fecha = GetDateValue(row, DB_COL_FECHA),
                Tipo = GetStringValue(row, DB_COL_TIPO),
                Monto = GetDoubleValue(row, DB_COL_MONTO)
            };

            return movimiento;
        }

    }
}


