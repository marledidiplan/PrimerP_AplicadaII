<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cCuentasBancarias.aspx.cs" Inherits="AplicadaIIprimerParcial.Consulta.cCuentasBancarias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div
        class="text-center">
        <h1 style="font-size: x-large; font-family: 'Agency FB', Times, serif; font: bold;">Consulta de Cuentas Bancarias</h1>
    </div>
    <div class=" form-row justify-content-centerW">
        <div class="form-group col-md-2 <%--col-sm-1 col-lg-2--%>" role="form">
            <asp:Label ID="Filtro" runat="server" Text="Filtro"></asp:Label>
            <asp:DropDownList ID="FiltroDropDownList" CssClass="form-control" runat="server">
                <asp:ListItem>TODO</asp:ListItem>
                <asp:ListItem>CuentaId</asp:ListItem>
                <asp:ListItem> Nombre</asp:ListItem>
                <asp:ListItem>Balance</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div class="form-group col-md-2 <%--<%--col-sm-1--%> col-lg-1">
            <asp:Label ID="Criterio" runat="server" Text="Criterio"></asp:Label>
            <asp:TextBox ID="CriterioTextBox" runat="server"></asp:TextBox>
        </div>

        <div class=" form-group col-md-12 ">
            <asp:Button ID="BuscarBotton" runat="server" Text="Buscar" class="btn btn-danger btn" />
        </div>

        <div>
            <asp:GridView ID="CuentasGridView" runat="server" class="table table-condensed table-bordered table-responsive" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="Gray" />
                <Columns>
                    <asp:HyperLinkField ControlStyle-ForeColor="GrayText"
                        DataNavigateUrlFields="CuentaId" 
                        DataNavigateUrlFormatString="\Registros\rCuentaBancaria.aspx?Id={0}"
                        Text="Editar">
                        <ControlStyle ForeColor="GrayText"></ControlStyle>
                    </asp:HyperLinkField>

                    <asp:BoundField HeaderText="CuentaId" />
                    <asp:BoundField HeaderText="Nombre" />

                </Columns>
                <HeaderStyle BackColor="Window" Font-Bold="true" ForeColor="Blue" />
                <RowStyle BackColor="PaleGreen" />
            </asp:GridView>
        </div>
    </div>


</asp:Content>
