using DataAcess.Dao;
using Entities_POJO;
using System.Collections.Generic;

namespace DataAcess.Mapper
{
    public class CuentaMapper : EntityMapper, ISqlStatements, IObjectMapper
    {
        private const string DB_COL_IDCUENTA = "IDCUENTA";
        private const string DB_COL_IDCLIENTE = "IDCLIENTE";
        private const string DB_COL_TIPO = "TIPO";
        private const string DB_COL_MONEDA = "MONEDA";
        private const string DB_COL_SALDO = "SALDO";

        public SqlOperation GetCreateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "CRE_CUENTA_PR" };

            var c = (Cuenta)entity;
            operation.AddVarcharParam(DB_COL_IDCLIENTE, c.IdCliente);
            operation.AddVarcharParam(DB_COL_TIPO, c.Tipo);
            operation.AddVarcharParam(DB_COL_MONEDA, c.Moneda);
            operation.AddDoubleParam(DB_COL_SALDO, c.Saldo);

            return operation;
        }

        public SqlOperation GetRetriveStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_CUENTA_PR" };

            var c = (Cuenta)entity;
            operation.AddIntParam(DB_COL_IDCUENTA, c.IdCuenta);

            return operation;
        }

        public SqlOperation GetRetriveAllStatement()
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CUENTAS_PR" };
            return operation;
        }

        public SqlOperation GetRetriveAllIDStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "RET_ALL_CUENTAS_ID_PR" };
            var c = (Cuenta)entity;
            operation.AddVarcharParam(DB_COL_IDCLIENTE, c.IdCliente);
            return operation;
        }

        public SqlOperation GetUpdateStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "UPD_CUENTA_PR" };

            var c = (Cuenta)entity;
            operation.AddIntParam(DB_COL_IDCUENTA, c.IdCuenta);
            operation.AddVarcharParam(DB_COL_IDCLIENTE, c.IdCliente);
            operation.AddVarcharParam(DB_COL_TIPO, c.Tipo);
            operation.AddVarcharParam(DB_COL_MONEDA, c.Moneda);
            operation.AddDoubleParam(DB_COL_SALDO, c.Saldo);

            return operation;
        }

        public SqlOperation GetDeleteStatement(BaseEntity entity)
        {
            var operation = new SqlOperation { ProcedureName = "DEL_CUENTA_PR" };

            var c = (Cuenta)entity;
            operation.AddIntParam(DB_COL_IDCUENTA, c.IdCuenta);
            return operation;
        }

        public List<BaseEntity> BuildObjects(List<Dictionary<string, object>> lstRows)
        {
            var lstResults = new List<BaseEntity>();

            foreach (var row in lstRows)
            {
                var cuenta = BuildObject(row);
                lstResults.Add(cuenta);
            }

            return lstResults;
        }

        public BaseEntity BuildObject(Dictionary<string, object> row)
        {
            var cuenta = new Cuenta
            {
                IdCliente = GetStringValue(row, DB_COL_IDCLIENTE),
                IdCuenta = GetIntValue(row, DB_COL_IDCUENTA),
                Tipo = GetStringValue(row, DB_COL_TIPO),
                Moneda = GetStringValue(row, DB_COL_MONEDA),
                Saldo = GetDoubleValue(row, DB_COL_SALDO)
            };

            return cuenta;
        }

    }
}

