using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_POJO
{
    public class Cliente : BaseEntity
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime DOB { get; set; }
        public int Edad { get; set; }
        public string ECivil { get; set; }
        public string Sexo { get; set; }

        public Cliente() { }

        public Cliente(string[] infoArray)
        {
            if (infoArray != null && infoArray.Length >= 7)
            {
                Id = infoArray[0];
                Nombre = infoArray[1];
                Apellido = infoArray[2];

                var fecha = DateTime.Now;
                if (DateTime.TryParse(infoArray[3], out fecha))
                    DOB = fecha;
                else
                    throw new Exception("Fecha no válida.");

                var age = 0;
                if (Int32.TryParse(infoArray[4], out age))
                    Edad = age;
                else
                    throw new Exception("La edad debe ser un número.");

                ECivil = infoArray[5];
                Sexo = infoArray[6];
            }
            else
            {
                throw new Exception("Se requieren todos los datos [id,nombre,apellido,fecha de nacimiento,edad,estado civil,sexo]");
            }

        }

    }
}

