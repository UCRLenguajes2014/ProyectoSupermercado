<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Administrador.aspx.cs" Inherits="UISupermercado.Administrador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        <br />
        <asp:FileUpload ID="FUSubirImagen" runat="server" />
        <asp:ImageMap ID="imagen" runat="server" BorderStyle="Dotted" Height="102px" 
            Width="89px">
        </asp:ImageMap>
    </p>
    <p>
        <asp:Label ID="lblCodigo" runat="server" Text="Código:" Width="100px"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lbNombre" runat="server" Text="Nombre:" Width="100px"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblPrecio" runat="server" Text="Precio deventa:" Width="100px"></asp:Label>
        nbbvnvbn</p>
    <p>
        <asp:Label ID="lblEstado" runat="server" Text="Estado:" Width="100px"></asp:Label>
    </p>
    <p>
        <asp:Label ID="lblUnidad" runat="server" Text="Unidad:" Width="100px"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>kg</asp:ListItem>
            <asp:ListItem>L</asp:ListItem>
            <asp:ListItem>unid</asp:ListItem>
            <asp:ListItem>paq</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        <asp:Label ID="Label1" runat="server" Text="fiiiertt"></asp:Label>
    </p>
</asp:Content>
