using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Canton : BaseEntity
    {
        public string ProvinciaId { get; set; }
        public string CantonId { get; set; }
        public string Nombre { get; set; }

        public Canton() { }

        public Canton(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 3)
            {
                ProvinciaId = infoArray[0];
                CantonId = infoArray[1];
                Nombre = infoArray[2];
            }
            else
            {
                throw new Exception("Se requieren todos los datos [ProvinciaId,CantonId,Nombre]");
            }

        }


    }
}
