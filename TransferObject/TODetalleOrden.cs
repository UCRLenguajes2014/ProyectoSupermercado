using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TransferObject
{
    public class TODetalleOrden
    {
        public int CodigoOrden { get; set; }

        public int CodigoProducto { get; set; }

        public int Cantidad { get; set; }

        public int Subtotal { get; set; }
    }
}
