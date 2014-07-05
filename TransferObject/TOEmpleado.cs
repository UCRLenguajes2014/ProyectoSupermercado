using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransferObject
{
    public class TOEmpleado
    {
        public int id { get; set; }

        public string nombre { get; set; }

        public string pApellido { get; set; }

        public string sApellido { get; set; }

        public string correo { get; set; }

        public int rol { get; set; }

        public string usuario { get; set; }

        public string clave { get; set; }
    }
}
