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
                        retorno.Add(new Producto((int)lector[0], (string)lector[1], Convert.ToDouble(lector[2]), (Int32)lector[3], (bool)lector[4], (Byte[])lector[5],(string)lector[6]));
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

       public void insertar(Producto cont)
       {
           try
           {
               if (conex.State != ConnectionState.Open)
               {
                   conex.Open();

                   SqlCommand ins = new SqlCommand("Insert into Producto(Codigo,Nombre,PrecioVenta,CantidadInventario,Estado,Foto,UnidadMedida) values(@Codigo,@Nombre,@PrecioVenta,@CantidadInventario,@Estado,@Foto,@UnidadMedida)", conex);

                   ins.Parameters.AddWithValue("@Codigo", cont.codigo);
                   ins.Parameters.AddWithValue("@Nombre", cont.nombre);
                   ins.Parameters.AddWithValue("@PrecioVenta", cont.precio);
                   ins.Parameters.AddWithValue("@CantidadInventario", cont.cantidad);
                   ins.Parameters.AddWithValue("@Estado", cont.estado);
                   ins.Parameters.AddWithValue("@Foto", cont.foto);
                   ins.Parameters.AddWithValue("@UnidadMedida", cont.unidad);
                   ins.ExecuteNonQuery();
                 

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

       }

       public void Eliminar(int codigo)
       {
           try
           {
               if (conex.State != ConnectionState.Open)
               {
                   conex.Open();
               }
               SqlCommand del = new SqlCommand("Delete from Producto where Codigo = @Codigo", conex);

               del.Parameters.AddWithValue("@Codigo", codigo);
                   del.ExecuteNonQuery();

            

               

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

       }

    }
}
