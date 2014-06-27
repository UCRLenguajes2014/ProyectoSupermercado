using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;
using TransferObject;
namespace BusinessLogic
{
   public class BLProducto
    {
       public List<Producto> consultatProductos()
       {
           DAProducto producto = new DAProducto();
           return producto.consultatProductos();

       }

    }
}
