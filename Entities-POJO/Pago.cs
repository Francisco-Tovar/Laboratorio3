using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Pago : BaseEntity
    {
        public int IdPago { get; set; }
        public int IdCredito { get; set; }
        public DateTime Fecha { get; set; }
        public string Operacion { get; set; }
        public double Monto { get; set; }

        public Pago() { }

        public Pago(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 5)
            {
                int temp = 0;
                if (int.TryParse(infoArray[0], out temp))
                    IdPago = temp;
                else
                    throw new Exception("Número de pago no válido");

                temp = 0;
                if (int.TryParse(infoArray[1], out temp))
                    IdCredito = temp;
                else
                    throw new Exception("Número de crédito no válido");

                var tempdate = DateTime.Now;
                if (DateTime.TryParse(infoArray[2], out tempdate))
                    Fecha = tempdate;
                else
                    throw new Exception("Fecha inválida");

                Operacion = infoArray[3];

                double tempd = 0;
                if (double.TryParse(infoArray[0], out tempd))
                    Monto = tempd;
                else
                    throw new Exception("Monto no válido");


            }
            else
            {
                throw new Exception("Se requieren todos los datos [IdPago,IdCredito,Fecha,Operación,Monto]");
            }

        }


    }
}


