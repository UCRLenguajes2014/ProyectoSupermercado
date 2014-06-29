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
    }
}
