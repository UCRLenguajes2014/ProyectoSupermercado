using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using TransferObject;
using System.Data;

namespace DataAccess
{
    class DAEmpleado
    {
        private SqlConnection conex = new SqlConnection(DataAccess.Properties.Settings.Default.coneSetting);

        public List<TOEmpleado> consultarEmpleados()
        {
            List<TOEmpleado> retorno = new List<TOEmpleado>();
            try
            {
                if (conex.State != ConnectionState.Open)
                {
                    conex.Open();
                }
                SqlCommand sel = new SqlCommand("SELECT * from Empleado", conex);
                SqlDataReader lector;
                lector = sel.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        retorno.Add(new TOEmpleado((int)lector[0], (string)lector[1], string(lector[2]), (string)lector[3], (string)lector[4],(int)lector[5],(string)lector[6],(string)lector[7]));
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
