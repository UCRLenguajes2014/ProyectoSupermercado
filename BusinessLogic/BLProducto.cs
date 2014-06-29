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
       public List<TOProducto> consultatProductos()
       {
           DAProducto producto = new DAProducto();
           return producto.consultatProductos();

       }
       public TOProducto consultatProducto(int codigo)
       {
           DAProducto producto = new DAProducto();
           return producto.consultatUnPro(codigo);

       }


       public List<TOProducto> consultarByNombre(string nombre)
       {
           DAProducto producto = new DAProducto();
           return producto.consultarByNombre(nombre);

       }

       public void insertar(TOProducto cli)
       {
           DAProducto producto = new DAProducto();
           producto.insertar(cli);

       }

       public void Eliminar(int codigoe)
       {
           DAProducto daoPro = new DAProducto();
           daoPro.Eliminar(codigoe);
       }


    }
}
