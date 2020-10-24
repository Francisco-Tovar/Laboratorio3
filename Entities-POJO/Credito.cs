using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Credito : BaseEntity
    {
        public int IdCredito { get; set; }
        public string IdCliente { get; set; }
        public double Monto { get; set; }
        public double Tasa { get; set; }
        public string Nombre { get; set; }
        public double Cuota { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public double Saldo { get; set; }

        public Credito() { }

        public Credito(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 9)
            {
                int temp1 = 0;
                if (int.TryParse(infoArray[0], out temp1))
                    IdCredito = temp1;
                else
                    throw new Exception("Número de crédito no válido");

                IdCliente = infoArray[1];

                double temp = 0;
                if (double.TryParse(infoArray[2], out temp))
                    Monto = temp;
                else
                    throw new Exception("Monto debe ser un número.");
                

                if (double.TryParse(infoArray[3], out temp))
                    Tasa = temp;
                else
                    throw new Exception("Tasa debe ser un número.");
                

                Nombre = infoArray[4];

                if (double.TryParse(infoArray[5], out temp))
                    Cuota = temp;
                else
                    throw new Exception("Cuota debe ser un número.");

                var tempDate = DateTime.Now;
                if (DateTime.TryParse(infoArray[6], out tempDate))
                    Fecha = tempDate;
                else
                    throw new Exception("Fecha no válida.");

                Estado = infoArray[7];

                if (double.TryParse(infoArray[8], out temp))
                    Saldo = temp;
                else
                    throw new Exception("Saldo debe ser un número.");
                

            }
            else
            {
                throw new Exception("Se requieren todos los datos [idCredito,idCliente,monto,tasa,nombre,cuota,fecha,estado,saldo]");
            }

        }

    }
}

