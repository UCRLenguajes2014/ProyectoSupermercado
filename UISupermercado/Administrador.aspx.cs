using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using BusinessLogic;
using TransferObject;

namespace UISupermercado
{
    public partial class Administrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imagen.ImageUrl = "imagenes/nodisponible.png";
            llenarDataGrid();
        }
        private void llenarDataGrid()
        {
            try
            {
                BLProducto producto = new BLProducto();
                gvProductos.DataSource = producto.consultatProductos();
                gvProductos.DataBind();

            }
            catch (Exception)
            {


            }

        }

        protected void gvcontacto_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            

            
            try
            {
                Producto producto = new Producto();
                BLProducto blproducto = new BLProducto();
             

                    //if (MessageBox.Show("Está seguro de eliminar el estudiante: " + dtGProductos.CurrentRow.Cells[1].Value, "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    
                    
                        producto.codigo =  int.Parse(gvProductos.DataKeys[e.RowIndex].Value.ToString());
                        blproducto.Eliminar(producto.codigo);
                        llenarDataGrid();
                      
                       

                    
                
            }
            catch (Exception)
            {

                //MessageBox.Show("Error al eliminar");
            }

        }

        protected void gvcontacto_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //int idcontacto = Convert.ToInt32(gvContacto.DataKeys[e.NewSelectedIndex].Value);

            //Response.Redirect(string.Format("EditarContacto.aspx?id={0}", idcontacto));

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (FUSubirImagen.HasFile)
                try
                {
                    
                    imagen.ImageUrl = obteneUrlImagen();

                    imagen.DataBind();


                }
                catch (Exception ex)
                {
                    throw new Exception("ERROR: " + ex.Message.ToString());
                }
        }

        public String obteneUrlImagen() 
        {
            try
            {
                String sName = FUSubirImagen.FileName;
                String sExt = Path.GetExtension(sName);
                string fullPath = Path.Combine(Server.MapPath("~/Imagenes"), FUSubirImagen.FileName);

                FUSubirImagen.SaveAs(fullPath);
                String url = "/Imagenes/" + sName;

                return url;
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR: " + ex.Message.ToString());
            }
        }

        protected void gvProductos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int idcontacto = Convert.ToInt32(gvProductos.DataKeys[e.NewSelectedIndex].Value);
        }

        protected void cmdLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            imagen.ImageUrl = "imagenes/nodisponible.png";
        }

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                Producto producto = new Producto();
                BLProducto blproducto = new BLProducto();
                producto.codigo = int.Parse(txtCodigo.Text.Trim());
                producto.nombre = txtNombre.Text.Trim();
                producto.precio = int.Parse(txtPrecio.Text.Trim());
                producto.cantidad = int.Parse(txtCantidad.Text.Trim());
                producto.estado = Convert.ToBoolean(dpdEstado.SelectedValue.ToString());
                producto.foto = FUSubirImagen.FileBytes;
                producto.unidad = dpdUnidad.SelectedValue.ToString();
                blproducto.insertar(producto);
                llenarDataGrid();
                //txtCodigoProducto.Enabled = false;
            }
            catch (Exception)
            {

                //.Show("Revise los datos ingresados");
            }
        }
        public void byteArrayToImage(byte[] byteArrayIn)
        {
            string base64String = Convert.ToBase64String(byteArrayIn, 0, byteArrayIn.Length);
            imagen.ImageUrl = "data:image/png;base64," + base64String;
            imagen.Visible = true;
        }

        
    }
}