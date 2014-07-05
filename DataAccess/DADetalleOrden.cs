using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using TransferObject;
using System.Data;

namespace DataAccess
{
    class DADetalleOrden
    {
        private SqlConnection conex = new SqlConnection(DataAccess.Properties.Settings.Default.coneSetting);

        public List<TODetalleOrden> consultarDetallesOrden(string OrdenID)
        {
            List<TODetalleOrden> retorno = new List<TODetalleOrden>();
            try
            {
                if (conex.State != ConnectionState.Open)
                {
                    conex.Open();
                }
                SqlCommand sel = new SqlCommand("SELECT * from DetalleOrden where CodigoOrden = @IdOrden", conex);

                sel.Parameters.AddWithValue("@IdOrden", OrdenID);

                SqlDataReader lector;
                lector = sel.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        retorno.Add(new TODetalleOrden((int)lector[0], (int)lector[1], int(lector[2]), (Int32)lector[3]));
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

        public void insertar(TODetalleOrden detOrd)
        {
            try
            {
                if (conex.State != ConnectionState.Open)
                {
                    conex.Open();

                    SqlCommand ins = new SqlCommand("Insert into DetalleOrden(CodigoOrden ,CodigoProducto,Cantidad,Subtotal) values(@CodigoOrden,@CodigoProducto,@Cantidad,@Subtotal)", conex);

                    ins.Parameters.AddWithValue("@CodigoOrden", detOrd.CodigoOrden);
                    ins.Parameters.AddWithValue("@CodigoProducto", detOrd.CodigoProducto);
                    ins.Parameters.AddWithValue("@Cantidad", detOrd.Cantidad);
                    ins.Parameters.AddWithValue("@Subtotal", detOrd.Subtotal);                
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
        public void modificar(TODetalleOrden detOrd)
        {
            try
            {
                if (conex.State != ConnectionState.Open)
                {
                    conex.Open();

                    SqlCommand upd = new SqlCommand("UPDATE DetalleOrden SET CodigoOrden=@CodigoOrden ,CodigoProducto=@CodigoProducto,Cantidad=@Cantidad,Subtotal=@Subtotal", conex);

                    upd.Parameters.AddWithValue("@CodigoOrden", detOrd.CodigoOrden);
                    upd.Parameters.AddWithValue("@CodigoProducto", detOrd.CodigoProducto);
                    upd.Parameters.AddWithValue("@Cantidad", detOrd.Cantidad);
                    upd.Parameters.AddWithValue("@Subtotal", detOrd.Subtotal);
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
        public void Eliminar(int codigoOrden,int codigoProducto)
        {
            try
            {
                if (conex.State != ConnectionState.Open)
                {
                    conex.Open();
                }
                SqlCommand del = new SqlCommand("Delete from DetalleOrden where CodigoOrden = @codigoOrden and CodigoProducto=@codigoProducto", conex);

                del.Parameters.AddWithValue("@codigoOrden", codigoOrden);
                del.Parameters.AddWithValue("@codigoProducto", codigoProducto);
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
