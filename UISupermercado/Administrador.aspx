<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="UISupermercado.Administrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
            height: 161px;
        }
    .style2
    {
        height: 161px;
        width: 401px;
    }
    .style3
    {
    }
        .style4
        {
            height: 45px;
            width: 401px;
        }
        .style5
        {
            height: 45px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; INFORMACIÓN DE PRODUCTO:&nbsp;</p>
    <div style="height: 251px; margin-left: 41px; width: 713px;">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td class="style2">
                        <div style="width: 382px; height: 246px" title="Producto">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblCodigo" runat="server" Text="Código:" Width="100px"></asp:Label>
                            <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
                            <br />
                            <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lbNombre" runat="server" Text="Nombre:" Width="100px"></asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                            <br />
                            <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblPrecio" runat="server" Text="Precio deventa:" Width="100px"></asp:Label>
                            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
                            <br />
                            <br />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblCantidad" runat="server" Text="Cantidad:" Width="100px"></asp:Label>
                            <asp:TextBox ID="txtCantidad" runat="server"></asp:TextBox>
                            <br />
                            <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblEstado" runat="server" Text="Estado:" Width="100px"></asp:Label>
                            <asp:DropDownList ID="dpdEstado" runat="server" Height="17px" Width="127px">
                                <asp:ListItem Value="true">Activo</asp:ListItem>
                                <asp:ListItem Value="false">Inactivo</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblUnidad" runat="server" Text="Unidad:" Width="100px"></asp:Label>
        <asp:DropDownList ID="dpdUnidad" runat="server" Height="16px" Width="127px">
            <asp:ListItem>kg</asp:ListItem>
            <asp:ListItem>L</asp:ListItem>
            <asp:ListItem>unid</asp:ListItem>
            <asp:ListItem>paq</asp:ListItem>
        </asp:DropDownList>
                            <br />
                            <br />
                        </div>
                    </td>
                    <td class="style1">
                        <div style="height: 217px; width: 269px; margin-left: 52px">
        <asp:ImageMap ID="imagen" runat="server" BorderStyle="Dotted" Height="123px" 
            Width="127px">
        </asp:ImageMap>
                            <asp:TextBox ID="txtDirImagen" runat="server" Visible="False"></asp:TextBox>
        <asp:FileUpload ID="FUSubirImagen" runat="server" style="margin-top: 28px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button1" runat="server" Text="Cargar  Foto" Width="88px" 
                                onclick="Button1_Click" />
                        </div>
                    </td>
                    <td class="style1">
                    </td>
                </tr>
                <tr>
                    <td class="style4">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="cmdGuardar" runat="server" onclick="cmdGuardar_Click" 
                            Text="Guardar" />
&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="cmdModificar" runat="server" onclick="cmdModificar_Click" 
                            Text="Modificar" />
&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                        <asp:Button ID="cmdLimpiar" runat="server" onclick="cmdLimpiar_Click" 
                            Text="Limpiar" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                    <td class="style5">
                    </td>
                    <td class="style5">
                    </td>
                </tr>
                <tr>
                    <td class="style3" colspan="2" rowspan="2">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="txtBuscar" runat="server" 
                            ontextchanged="txtBuscar_TextChanged" Width="246px"></asp:TextBox>
                        <asp:ImageButton ID="cmdBuscar" runat="server" Height="22px" 
                            ImageUrl="~/imagenes/consultar.png" onclick="cmdBuscar_Click" Width="31px" />
                        <br />
                        <br />
                        <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" DataKeyNames="codigo" ForeColor="#333333" GridLines="None" 
                            onrowdeleting="gvcontacto_RowDeleting" 
                            onselectedindexchanging="gvProductos_SelectedIndexChanging" Width="678px" 
                            Height="27px" PageSize="6">
                            <RowStyle BackColor="#E3EAEB" />
                            <Columns>
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/imagenes/eliminar.png" 
                                    FooterText="Editar" HeaderText="Edicion" InsertVisible="False" 
                                    SelectImageUrl="~/imagenes/consultar.png" ShowCancelButton="False" 
                                    ShowDeleteButton="True" ShowSelectButton="True">
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:CommandField>
                                <asp:BoundField DataField="codigo" HeaderText="Codigo" />
                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                <asp:BoundField DataField="Precio" HeaderText="Precio de venta" />
                                <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
                                <asp:BoundField HeaderText="Estado" DataField="Estado" />
                                <asp:BoundField HeaderText="Unidad" DataField="Unidad" />
                                <asp:TemplateField HeaderText="Foto" Visible="False">
                                    <ItemTemplate>
                                        <asp:Image ID="foto" runat="server" Height="100px" ImageUrl="" 
                                            Width="100px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <AlternatingRowStyle BackColor="White" />
                            <SortedAscendingCellStyle BackColor="#F8FAFA" />
                            <SortedAscendingHeaderStyle BackColor="#246B61" />
                            <SortedDescendingCellStyle BackColor="#D4DFE1" />
                            <SortedDescendingHeaderStyle BackColor="#15524A" />
                        </asp:GridView>
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </div>
</div>
    <p>
        &nbsp;</p>
    <div>
</div>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
<p>
        &nbsp;</p>
</asp:Content>
