<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="UISupermercado.Administrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        height: 75px;
    }
    .style2
    {
        height: 75px;
        width: 401px;
    }
    .style3
    {
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
    </p>
    <p>
        &nbsp;</p>
    <div style="height: 251px; margin-left: 41px; width: 713px;">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td class="style2">
                        <div style="width: 382px; height: 227px" title="Producto">
        <asp:Label ID="lblCodigo" runat="server" Text="Código:" Width="100px"></asp:Label>
                            <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
                            <br />
                            <br />
        <asp:Label ID="lbNombre" runat="server" Text="Nombre:" Width="100px"></asp:Label>
                            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                            <br />
                            <br />
        <asp:Label ID="lblPrecio" runat="server" Text="Precio deventa:" Width="100px"></asp:Label>
                            <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
                            <br />
                            <br />
        <asp:Label ID="lblEstado" runat="server" Text="Estado:" Width="100px"></asp:Label>
                            <asp:DropDownList ID="DropDownList2" runat="server" Height="17px" Width="127px">
                                <asp:ListItem>Activo</asp:ListItem>
                                <asp:ListItem>Inactivo</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <br />
        <asp:Label ID="lblUnidad" runat="server" Text="Unidad:" Width="100px"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" Height="16px" Width="127px">
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
                        <div style="height: 217px; width: 235px; margin-left: 52px">
        <asp:ImageMap ID="imagen" runat="server" BorderStyle="Dotted" Height="102px" 
            Width="89px">
        </asp:ImageMap>
        <asp:FileUpload ID="FUSubirImagen" runat="server" style="margin-top: 28px" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button1" runat="server" Text="Cargar  Foto" Width="88px" />
                        </div>
                    </td>
                    <td class="style1">
                    </td>
                </tr>
                <tr>
                    <td class="style3" colspan="2" rowspan="2">
                        <br />
                        <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" DataKeyNames="codigo" ForeColor="#333333" GridLines="None" 
                            onrowdeleting="gvcontacto_RowDeleting" 
                            onselectedindexchanged="gvProductos_SelectedIndexChanged" 
                            onselectedindexchanging="gvcontacto_SelectedIndexChanging" Width="690px">
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
                                <asp:BoundField HeaderText="Cantidad" />
                                <asp:BoundField HeaderText="Estado" />
                                <asp:BoundField HeaderText="Unidad" />
                                <asp:TemplateField HeaderText="Imágen">
                                    <ItemTemplate>
                                        <asp:Image ID="fotogradia" runat="server" Height="100px" ImageUrl="" 
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
</asp:Content>
