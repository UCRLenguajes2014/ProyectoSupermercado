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
    }
}
