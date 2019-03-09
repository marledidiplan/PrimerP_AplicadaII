<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rCuentaBancaria.aspx.cs" Inherits="AplicadaIIprimerParcial.Registros.rCuentaBancaria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="text-center">
        <h1 style="font-size: x-large; font-family: 'Agency FB', Times, serif; font: bold;"><ins>Cuentas Bancarias</ins></h1>
        <asp:Image ID="Imagen" runat="server" Height="150px" ImageAlign="Baseline" ImageUrl="~/Resources/cuenta-png.png" Width="227px" />
    </div>
        <div class="form-group">
            <div class="form-gruop col-md-12">
                <div class="col-md-8">
                    <asp:Label ID="Label2" runat="server" Text="Id:"></asp:Label>
                    <asp:TextBox ID="CuentaIdTextBox" class="form-control col-md-3" Text="0" type="number" runat="server"></asp:TextBox>
                    <asp:Button ID="BuscarButton" ValidationGroup="Buscar" class="form-control btn btn-info col-md-2 btn-sm" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                    <asp:RequiredFieldValidator ID="IdRFdValidator" ValidationGroup="Buscar" ControlToValidate="CuentaIdTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-gruop col-md-12">
                <label for="FechaTextbox" class="col-md-3 control-label input-sm">Fecha:</label>
                <div class="col-md-8">
                    <asp:TextBox ID="FechaTextBox" type="date" runat="server" class="form-control input-sm" ReadOnly="True"></asp:TextBox>
                    <br />
                </div>
            </div>
            <div class="form-gruop col-md-12">
                <label for="NombreTextbox" class="col-md-3 control-label input-sm">Nombre:</label>
                <div class="col-md-8">
                    <asp:TextBox ID="NombreTextbox" runat="server" class="form-control input-sm"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="NombreRFValidator" ValidationGroup="Guardar" ControlToValidate="NombreTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="NombreREValidator" runat="server" ForeColor="DarkRed" ErrorMessage="Por favor solo letras" ValidationExpression="^[a-zA-Z'.\s]{1,40}$" ValidationGroup="Guardar" ControlToValidate="NombreTextBox"></asp:RegularExpressionValidator>
                    <br />
                </div>
            </div>
            <div class="form-gruop col-md-12">
                <label for="BalanceTextbox" class="col-md-3 control-label input-sm">Balance:</label>
                <div class="col-md-8">
                    <asp:TextBox ID="BalanceTextBox" runat="server" class="form-control input-sm"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="BalanceRFValidator" ValidationGroup="Guardar" ControlToValidate="BalanceTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="BalanceREValidator" runat="server" ForeColor="DarkRed" ErrorMessage="Por favor solo numeros" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar" ControlToValidate="BalanceTextBox"></asp:RegularExpressionValidator>
                    <br />
                </div>
            </div>

            <div class="panel">
                <div class="text-center">
                    <div class="form-group">
                        <asp:Button ID="NuevoBtton" runat="server" Text="Nuevo" class="btn btn-warning btn" OnClick="NuevoBtton_Click" />
                        <asp:Button ID="GuardarBtton" ValidationGroup="Guardar" runat="server" Text="Guardar" class="btn btn-success btn" OnClick="GuardarBtton_Click" />
                        <asp:Button ID="EliminarBtton" ValidationGroup="Eliminar" runat="server" Text="Eliminar" class="btn btn-danger btn" OnClick="EliminarBtton_Click" />
                    </div>
                </div>
            </div>

        </div>


</asp:Content>
