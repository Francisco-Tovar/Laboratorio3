using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Cuenta : BaseEntity
    {
        public int IdCuenta { get; set; }
        public string IdCliente { get; set; }
        public string Tipo { get; set; }
        public string Moneda { get; set; }
        public double Saldo { get; set; }

        public Cuenta() { }

        public Cuenta(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 5)
            {
                int tempCuenta = 0;
                if (int.TryParse(infoArray[0], out tempCuenta))
                    IdCuenta = tempCuenta;
                else
                    throw new Exception("Número de cuenta no válido");
                
                IdCliente = infoArray[1];
                Tipo = infoArray[2];
                Moneda = infoArray[3];
                
                double tempSaldo = 0;
                if (double.TryParse(infoArray[4], out tempSaldo))
                    Saldo = tempSaldo;
                else
                    throw new Exception("Saldo debe ser un número.");

            }
            else
            {
                throw new Exception("Se requieren todos los datos [IdCuenta,IdCliente,nombre,moneda,saldo]");
            }

        }

    }
}


