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
                TOProducto producto = new TOProducto();
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
            int codigo = Convert.ToInt32(gvProductos.DataKeys[e.NewSelectedIndex].Value);
            BLProducto blproducto = new BLProducto();
           TOProducto produc = new TOProducto();
            produc = blproducto.consultatProducto(codigo);
            txtCodigo.Text =  produc.codigo.ToString();
            txtNombre.Text = produc.nombre;
            txtPrecio.Text = produc.precio.ToString();
            txtCantidad.Text = produc.cantidad.ToString();
            dpdEstado.SelectedValue = produc.estado.ToString();
            dpdUnidad.SelectedValue = produc.unidad;
            txtDirImagen.Text = produc.foto.ToString();
            byteToImage(produc.foto);

        }

        protected void cmdLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            imagen.ImageUrl = "imagenes/nodisponible.png";
        }
        //protected void btGuardar_Click(object sender, EventArgs e)
        //{
        //    if (validar())
        //    {
        //        try
        //        {
        //            if (FileUpload.PostedFile.ContentType == "image/jpeg")
        //            {
        //                if (FileUpload.PostedFile.ContentLength < 102400)
        //                {
        //                    HttpPostedFile ImgFile = FileUpload.PostedFile;
        //                    Byte[] image = new Byte[FileUpload.PostedFile.ContentLength];
        //                    ImgFile.InputStream.Read(image, 0, FileUpload.PostedFile.ContentLength);
        //                    Producto p = new Producto();
        //                    p.codigo = 0;
        //                    p.nombre = txNombre.Text;
        //                    p.precioVenta = Convert.ToInt32(txPrecioVenta.Text.Trim());
        //                    p.cantidadInventario = Convert.ToInt32(txCantidadInventario.Text.Trim());

        //                    if (cbActivo.Checked)
        //                    {
        //                        p.activo = true;
        //                    }
        //                    else { p.activo = false; }
        //                    p.imagen = image;
        //                    p.unidad = Convert.ToInt32(drUnidad.SelectedItem.Value);
        //                    manejador.insert(p);
        //                    gvProductos.DataSource = manejador.getAll();
        //                    gvProductos.DataBind();
        //                }
        //                else
        //                    lbEstado.Text = "Estado de la carga: La carga de imagenes no debe superar los 100kb!";
        //            }
        //            else
        //                lbEstado.Text = "Estado de la carga: Sólo imagenes JPG!";
        //        }
        //        catch
        //        {
        //            lbEstado.Text = "El archivo no se pudo cargar.";
        //        }

        //    }
        //}

        protected void cmdGuardar_Click(object sender, EventArgs e)
        {
            try
            {

                TOProducto producto = new TOProducto();
                BLProducto blproducto = new BLProducto();
                producto.codigo = int.Parse(txtCodigo.Text.Trim());
                producto.nombre = txtNombre.Text.Trim();
                producto.precio = int.Parse(txtPrecio.Text.Trim());
                producto.cantidad = int.Parse(txtCantidad.Text.Trim());
                producto.estado = Convert.ToBoolean(dpdEstado.SelectedValue.ToString().Trim());
                producto.foto = FUSubirImagen.FileBytes;
                producto.unidad = dpdUnidad.SelectedValue.ToString().Trim();
                blproducto.insertar(producto);
                llenarDataGrid();
               
            }
            catch (Exception)
            {

                //.Show("Revise los datos ingresados");
            }
        }
        public void byteToImage(byte[] byteArrayIn)
        {
            string base64String = Convert.ToBase64String(byteArrayIn, 0, byteArrayIn.Length);
            imagen.ImageUrl = "data:image/png;base64," + base64String;
            imagen.Visible = true;
        }

        //public byte[] imageToByteArray(System.Web.UI.WebControls.Image imageIn)
        //{
        //    //MemoryStream ms = new MemoryStream();
        //    //(ms, System.Drawing.Imaging.ImageFormat.Gif);
        //    //return ms.ToArray();
        //}

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            try
            {
                BLProducto producto = new BLProducto();
                gvProductos.DataSource = producto.consultarByNombre(txtBuscar.Text.Trim());
                gvProductos.DataBind();

            }
            catch (Exception)
            {


            }
        }

        protected void cmdBuscar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                BLProducto producto = new BLProducto();
                gvProductos.DataSource = producto.consultarByNombre(txtBuscar.Text.Trim());
                gvProductos.DataBind();

            }
            catch (Exception)
            {


            }
        }
        //protected void btModImagen_Click(object sender, EventArgs e)
        //{
        //    if (FileUpload.HasFile)
        //    {
        //        try
        //        {
        //            if (FileUpload.PostedFile.ContentType == "image/jpeg")
        //            {
        //                if (FileUpload.PostedFile.ContentLength < 102400)
        //                {
        //                    HttpPostedFile ImgFile = FileUpload.PostedFile;
        //                    Byte[] imagen = new Byte[FileUpload.PostedFile.ContentLength];
        //                    ImgFile.InputStream.Read(imagen, 0, FileUpload.PostedFile.ContentLength);
        //                    manejador.updateImagen(Convert.ToInt32(ViewState["codigo"]), imagen);
        //                    ImagenProducto.ImageUrl = FileUpload.PostedFile.InputStream.ToString();
        //                }
        //                else { lbEstado.Text = "Estado de la carga: La carga de imagenes no debe superar los 100kb!"; }
        //            }
        //            else { lbEstado.Text = "Estado de la carga: Sólo imagenes JPG!"; }
        //        }
        //        catch { lbEstado.Text = "El archivo no se pudo cargar."; }
        //    }
        //    else { lbEstado.Text = "Ingrese la imagen para continuar"; }
        //}

        protected void cmdModificar_Click(object sender, EventArgs e)
        {
            try
            {

                TOProducto producto = new TOProducto();
                BLProducto blproducto = new BLProducto();
                producto.codigo = int.Parse(txtCodigo.Text.Trim());
                producto.nombre = txtNombre.Text.Trim();
                producto.precio = int.Parse(txtPrecio.Text.Trim());
                producto.cantidad = int.Parse(txtCantidad.Text.Trim());
                producto.estado = Convert.ToBoolean(dpdEstado.SelectedValue.ToString());
                //producto.foto = imageToByteArray(imagen);
                producto.unidad = dpdUnidad.SelectedValue.ToString();
                blproducto.insertar(producto);
                llenarDataGrid();

            }
            catch (Exception)
            {

                //.Show("Revise los datos ingresados");
            }
        }

        protected void gvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}