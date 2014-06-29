using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using TransferObject;

namespace DataAccess
{
    public class Autentificacion
    {
        public  bool Autenticar(string usuario, string password)
       {
           //consulta a la base de datos
           string sql = @"SELECT COUNT(*)
                          FROM Empleado
                          WHERE Usuario = @user AND Contrasena = @pass";
           //cadena conexion
           using (SqlConnection conn = new SqlConnection(DataAccess.Properties.Settings.Default.coneSetting))
           {
               conn.Open();

               SqlCommand cmd = new SqlCommand(sql, conn); 
               cmd.Parameters.AddWithValue("@user", usuario); 
               cmd.Parameters.AddWithValue("@pass", password);

               int count = Convert.ToInt32(cmd.ExecuteScalar());

               if (count == 0)
                   return false;
               else
                   return true;
       }
       }
    }
}
