using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using TransferObject;

namespace DataAccess
{
    class DAOrden
    {
        private SqlConnection conex = new SqlConnection(DataAccess.Properties.Settings.Default.coneSetting);

        public List<TOOrden> consultatOrdenes()
        {
            List<TOOrden> retorno = new List<TOOrden>();
            try
            {
                if (conex.State != ConnectionState.Open)
                {
                    conex.Open();
                }
                SqlCommand sel = new SqlCommand("SELECT * from Orden", conex);
                SqlDataReader lector;
                lector = sel.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        retorno.Add(new TOOrden((int)lector[0], (int)lector[1], string(lector[2]), (Int32)lector[3], (int)lector[4]));
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

        public void insertar(TOOrden ord)
        {
            try
            {
                if (conex.State != ConnectionState.Open)
                {
                    conex.Open();

                    SqlCommand ins = new SqlCommand("Insert into Orden(Codigo ,CodigoCliente,Estado,Fecha,Total) values(@Codigo,@CodigoCliente,@Estado,@Estado,@Total)", conex);

                    ins.Parameters.AddWithValue("@Codigo", ord.Codigo);
                    ins.Parameters.AddWithValue("@CodigoCliente", ord.CodigoCliente);
                    ins.Parameters.AddWithValue("@Estado", ord.Estado);
                    ins.Parameters.AddWithValue("@Fecha", ord.Fecha);
                    ins.Parameters.AddWithValue("@Total", ord.Total);
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
        public void modificar(TOOrden ord)
        {
            try
            {
                if (conex.State != ConnectionState.Open)
                {
                    conex.Open();

                    SqlCommand upd = new SqlCommand("UPDATE Orden SET Codigo=@Codigo ,CodigoCliente=@CodigoCliente,Estado=@Estado,Fecha=@Fecha,Total=@Total", conex);

                    upd.Parameters.AddWithValue("@Codigo", ord.Codigo);
                    upd.Parameters.AddWithValue("@CodigoCliente", ord.CodigoCliente);
                    upd.Parameters.AddWithValue("@Estado", ord.Estado);
                    upd.Parameters.AddWithValue("@Fecha", ord.Fecha);
                    upd.Parameters.AddWithValue("@Total", ord.Total);
                    upd.ExecuteNonQuery();


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
        public void Eliminar(int codigo,)
        {
            try
            {
                if (conex.State != ConnectionState.Open)
                {
                    conex.Open();
                }
                SqlCommand del = new SqlCommand("Delete from Orden where Codigo = @codigo", conex);

                del.Parameters.AddWithValue("@codigo", codigo);                
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
