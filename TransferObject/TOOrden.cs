using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransferObject
{
    public class TOOrden
    {
        public int Codigo { get; set; }

        public int CodigoCliente { get; set; }

        public int Estado { get; set; }

        public DateTime Fecha { get; set; }

        public int Total { get; set; }
    }
}
