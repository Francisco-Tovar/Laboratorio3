using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Distrito : BaseEntity
    {
        public string ProvinciaId { get; set; }
        public string CantonId { get; set; }
        public string DistritoId { get; set; }
        public string Nombre { get; set; }

        public Distrito() { }

        public Distrito(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 4)
            {
                ProvinciaId = infoArray[0];
                CantonId = infoArray[1];
                DistritoId = infoArray[2];
                Nombre = infoArray[3];
            }
            else
            {
                throw new Exception("Se requieren todos los datos [ProvinciaId,CantonId,DistritoId,Nombre]");
            }

        }


    }
}

