using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Movimiento : BaseEntity
    {
        public int IdMovimiento { get; set; }
        public int IdCuenta { get; set; }
        public DateTime Fecha { get; set; }
        public string Tipo { get; set; }
        public double Monto { get; set; }

        public Movimiento() { }

        public Movimiento(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 5)
            {
                int temp = 0;
                if (int.TryParse(infoArray[0], out temp))
                    IdMovimiento = temp;
                else
                    throw new Exception("Número de movimiento no válido");

                temp = 0;
                if (int.TryParse(infoArray[1], out temp))
                    IdCuenta = temp;
                else
                    throw new Exception("Número de cuenta no válido");

                var tempdate = DateTime.Now;
                if (DateTime.TryParse(infoArray[2], out tempdate))
                    Fecha = tempdate;
                else
                    throw new Exception("Fecha inválida");

                Tipo = infoArray[3];

                double tempd = 0;
                if (double.TryParse(infoArray[0], out tempd))
                    Monto = tempd;
                else
                    throw new Exception("Monto no válido");


            }
            else
            {
                throw new Exception("Se requieren todos los datos [IdMovimiento,IdCuenta,Fecha,Tipo,Monto]");
            }

        }


    }
}


