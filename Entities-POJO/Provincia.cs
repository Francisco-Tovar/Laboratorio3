using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Provincia : BaseEntity
    {
        public string Cod { get; set; }
        public string Nombre { get; set; }

        public Provincia() { }

        public Provincia(string[] infoArray) 
        {
            if (infoArray != null && infoArray.Length >= 2)
            {
                Cod = infoArray[0];
                Nombre = infoArray[1];
            }
            else
            {
                throw new Exception("Se requieren todos los datos [Cod,Nombre]");
            }

        }


    }
}
