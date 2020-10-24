using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Direccion : BaseEntity
    {
        public int IdDireccion { get; set; }
        public string IdCliente { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Detalles { get; set; }

        public Direccion() { }

        public Direccion(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 6)
            {
                int temp1 = 0;
                if (int.TryParse(infoArray[0], out temp1))
                    IdDireccion = temp1;
                else
                    throw new Exception("Identificador de dirección no válido");

                IdCliente = infoArray[1];
                Provincia = infoArray[2];
                Canton = infoArray[3];
                Distrito = infoArray[4];
                Detalles = infoArray[5];
            }
            else
            {
                throw new Exception("Se requieren todos los datos [IdDireccion,idCliente,provincia,canton,distrito,detalles]");
            }

        }

    }
}

