using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using TransferObject;
using System.Data.SqlClient;
namespace DataAccess
{
   public class DAProducto
    {
       private SqlConnection conex = new SqlConnection(DataAccess.Properties.Settings.Default.coneSetting);


       public List<Producto> consultatProductos()
        {
            List<Producto> retorno = new List<Producto>();
            try
            {
                if (conex.State != ConnectionState.Open)
                {
                    conex.Open();
                }
                SqlCommand sel = new SqlCommand("Select * from Producto", conex);
                SqlDataReader lector;
                lector = sel.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        retorno.Add(new Producto((int)lector["Codigo"], (string)lector["Nombre"], (Double)lector["PrecioVenta"], (Int32)lector["CantidadInventario"], (Boolean)lector["Estado"], (Byte[])lector["Foto"],(string)lector["UnidadMedida"]));
                    }
                }


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conex.State != ConnectionState.Closed)
                {
                    conex.Close();
                }
            }
            return retorno;



        }
    }
}
