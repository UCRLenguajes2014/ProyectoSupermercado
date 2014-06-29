using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TransferObject
{
   public  class TOProducto
    {

        public int codigo { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public double cantidad { get; set; }
        public bool estado { get; set; }
        public String unidad { get; set; }
        public Byte[] foto { get; set; }

        public TOProducto()
        {
        }
       public TOProducto(int p, string p_2, double p_3, int p_4, bool p_5, byte[] p_6, string p_7)
       {
           // TODO: Complete member initialization
           this.codigo = p;
           this.nombre = p_2;
           this.precio = p_3;
           this.cantidad = p_4;
           this.estado = p_5;
           this.foto = p_6;
           this.unidad = p_7;
       }
       
       
        
    }
}
