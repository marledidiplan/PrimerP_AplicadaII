<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cPrestamo.aspx.cs" Inherits="AplicadaIIprimerParcial.Consulta.cPrestamo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div
        class="text-center">
        <h1 style="font-size: x-large; font-family: 'Agency FB', Times, serif; font: bold;">Consulta de Prestamo</h1>
    </div>
    <div class=" form-row justify-content-centerW">
        <div class="form-group col-md-2 <%--col-sm-1 col-lg-2--%>" role="form">
            <asp:Label ID="Filtro" runat="server" Text="Filtro"></asp:Label>
            <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control" runat="server">
                <asp:ListItem>TODO</asp:ListItem>
                <asp:ListItem>Id</asp:ListItem>
                <asp:ListItem> Ncuotas</asp:ListItem>
                <asp:ListItem>Fecha</asp:ListItem>
                <asp:ListItem>Ineteres</asp:ListItem>
                <asp:ListItem>Capital</asp:ListItem>
                <asp:ListItem>Bce</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="form-group col-md-2 <%--<%--col-sm-1--%> col-lg-1">
            <asp:Label for="CriterioTextBox" runat="server" Text="Criterio"></asp:Label>
            <asp:TextBox ID="CriterioTextBox" runat="server"></asp:TextBox>
        </div>

        <div class=" form-group col-md-12 ">
            <asp:Button ID="BuscarBotton" runat="server" Text="Buscar" class="btn btn-success btn" OnClick="BuscarBotton_Click" />
        </div>

        <div>
            <asp:GridView ID="PrestamoGridView" runat="server" class="table table-condensed table-bordered table-responsive" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="Gray" />
                <Columns>
                    <asp:HyperLinkField ControlStyle-ForeColor="GrayText"
                        DataNavigateUrlFields="CuentaId"
                        DataNavigateUrlFormatString="\Registros\rPrestamo.aspx?Id={0}"
                        Text="Editar">
                        <ControlStyle ForeColor="Brown"></ControlStyle>
                    </asp:HyperLinkField>

                </Columns>
                <HeaderStyle BackColor="Window" Font-Bold="true" ForeColor="blue" />
                <RowStyle BackColor="PaleGreen" />
            </asp:GridView>
        </div>
    </div>


</asp:Content>
