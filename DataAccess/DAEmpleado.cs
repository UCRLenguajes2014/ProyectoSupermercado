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
        public TOEmpleado consultatUno(int codigo)
        {
            TOEmpleado retorno = new TOEmpleado();
            try
            {
                if (conex.State != ConnectionState.Open)
                {
                    conex.Open();
                }
                SqlCommand sel = new SqlCommand("Select * from Empleado  where ID = @ID", conex);
                sel.Parameters.AddWithValue("@ID", codigo);
                SqlDataReader lector;
                lector = sel.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        retorno = (new TOEmpleado((int)lector[0], (string)lector[1], string(lector[2]), (string)lector[3], (string)lector[4],(int)lector[5],(string)lector[6],(string)lector[7]));
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

        public void insertar(TOEmpleado empleado)
        {
            try
            {
                if (conex.State != ConnectionState.Open)
                {
                    conex.Open();

                    SqlCommand ins = new SqlCommand("Insert into Empleado(ID,Nombre,PrimerApellido,SegundoApellido,Correo,rol,usuario,clave) values(@ID,@Nombre,@pApelido,@sApelido,@Correo,@Rol,@usuario,@clave)", conex);

                    ins.Parameters.AddWithValue("@ID", empleado.id);
                    ins.Parameters.AddWithValue("@Nombre", empleado.nombre);
                    ins.Parameters.AddWithValue("@pApellido", empleado.pApellido);
                    ins.Parameters.AddWithValue("@sApellido", empleado.sApellido);
                    ins.Parameters.AddWithValue("@Correo", empleado.correo);
                    ins.Parameters.AddWithValue("@Rol", empleado.rol);
                    ins.Parameters.AddWithValue("@usuario", empleado.usuario);
                    ins.Parameters.AddWithValue("@clave", empleado.clave);
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

        public void Eliminar(int ID)
        {
            try
            {
                if (conex.State != ConnectionState.Open)
                {
                    conex.Open();
                }
                SqlCommand del = new SqlCommand("Delete from Empleado where ID = @ID", conex);

                del.Parameters.AddWithValue("@ID", ID);
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
        public void modificar(TOEmpleado empleado)
        {
            try
            {
                if (conex.State != ConnectionState.Open)
                {
                    conex.Open();

                    SqlCommand upd = new SqlCommand("UPDATE Empleado SET ID=@ID, Nombre=@Nombre, PrimerApellido=@pApelido, SegundoApellido=@sApelido, Correo=@Correo, rol=@Rol, usuario=@usuario, clave=@clave", conex);

                    upd.Parameters.AddWithValue("@ID", empleado.id);
                    upd.Parameters.AddWithValue("@Nombre", empleado.nombre);
                    upd.Parameters.AddWithValue("@pApellido", empleado.pApellido);
                    upd.Parameters.AddWithValue("@sApellido", empleado.sApellido);
                    upd.Parameters.AddWithValue("@Correo", empleado.correo);
                    upd.Parameters.AddWithValue("@Rol", empleado.rol);
                    upd.Parameters.AddWithValue("@usuario", empleado.usuario);
                    upd.Parameters.AddWithValue("@clave", empleado.clave);
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
    }
}
