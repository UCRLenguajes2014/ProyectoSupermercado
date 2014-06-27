using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
namespace BusinessLogic
{
   public class BLAutenticar
    {
       

       public bool Autenticar(string p, string p_2)
       {
           Autentificacion auten = new Autentificacion();
           
           return auten.Autenticar( p,  p_2);
       }
    }
}
