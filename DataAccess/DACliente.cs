using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using TransferObject;
using System.Data;

namespace DataAccess
{
    class DACliente
    {
        private SqlConnection conex = new SqlConnection(DataAccess.Properties.Settings.Default.coneSetting);

        public List<TOCliente> consultarTodosClientes()
        {
            List<TOCliente> retorno = new List<TOCliente>();
            try
            {
                if (conex.State != ConnectionState.Open)
                {
                    conex.Open();
                }
                SqlCommand sel = new SqlCommand("SELECT * from Cliente", conex);
                SqlDataReader lector;
                lector = sel.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        retorno.Add(new TOCliente((int)lector[0], string(lector[1]), string(lector[2]), (string)lector[3], (int)lector[4],(string)lector[5],(string)lector[6],(string)lector[7]));
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

        public TOCliente consultatUnCliente(int codigo)
        {
            TOCliente retorno = new TOCliente();
            try
            {
                if (conex.State != ConnectionState.Open)
                {
                    conex.Open();
                }
                SqlCommand sel = new SqlCommand("Select * from Cliente  where ID = @ID", conex);
                sel.Parameters.AddWithValue("@ID", codigo);
                SqlDataReader lector;
                lector = sel.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        retorno = (new TOCliente((int)lector[0], string(lector[1]), string(lector[2]), (string)lector[3], (int)lector[4],(string)lector[5],(string)lector[6],(string)lector[7]));
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
        public List<TOCliente> consultarByNombre(string nombre)
        {
            List<TOCliente> retorno = new List<TOCliente>();
            try
            {
                if (conex.State != ConnectionState.Open)
                {
                    conex.Open();
                }
                SqlCommand sel = new SqlCommand("SELECT * FROM Producto WHERE Nombre LIKE '%'  @buscar  '%' ORDER BY Nombre ASC", conex);
                sel.Parameters.AddWithValue("@buscar", nombre);
                SqlDataReader lector;
                lector = sel.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        retorno.Add(new TOCliente((int)lector[0], string(lector[1]), string(lector[2]), (string)lector[3], (int)lector[4],(string)lector[5],(string)lector[6],(string)lector[7]));
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

        public void insertar(TOCliente client)
        {
            try
            {
                if (conex.State != ConnectionState.Open)
                {
                    conex.Open();

                    SqlCommand ins = new SqlCommand("Insert into Cliente(ID,Nombre,Apellido,Correo,Telefono,Direccion,Usuario) values(@ID,@Nombre,@Apelido,@Correo,@Telefono,@Direccion,@Usuario)", conex);

                    ins.Parameters.AddWithValue("@ID", client.id);
                    ins.Parameters.AddWithValue("@Nombre", client.nombre);
                    ins.Parameters.AddWithValue("@Apellido", client.apellido);
                    ins.Parameters.AddWithValue("@Correo", client.correo);
                    ins.Parameters.AddWithValue("@Telefono", client.telefono);
                    ins.Parameters.AddWithValue("@Direccion", client.direccion);
                    ins.Parameters.AddWithValue("@Usuario", client.usuario);
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
                SqlCommand del = new SqlCommand("Delete from Cliente where ID = @ID", conex);

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
        public void modificar(TOCliente client)
        {
            try
            {
                if (conex.State != ConnectionState.Open)
                {
                    conex.Open();

                    SqlCommand ins = new SqlCommand("UPDATE Cliente SET ID=@ID,Nombre=@Nombre,Apellido=@Apelido,Correo=@Correo,Telefono=@Telefono,Direccion=@Direccion,Usuario=@Usuario", conex);

                    ins.Parameters.AddWithValue("@ID", client.id);
                    ins.Parameters.AddWithValue("@Nombre", client.nombre);
                    ins.Parameters.AddWithValue("@Apellido", client.apellido);
                    ins.Parameters.AddWithValue("@Correo", client.correo);
                    ins.Parameters.AddWithValue("@Telefono", client.telefono);
                    ins.Parameters.AddWithValue("@Direccion", client.direccion);
                    ins.Parameters.AddWithValue("@Usuario", client.usuario);
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

    }
}
