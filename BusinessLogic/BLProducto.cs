﻿using System;
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

       public void insertar(Producto cli)
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
