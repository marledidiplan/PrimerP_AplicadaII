<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rDeposito.aspx.cs" Inherits="AplicadaIIprimerParcial.Registros.rDeposito" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <br />
    <div class="text-center">
        <h1 style="font-size: x-large; font-family: 'Agency FB', Times, serif; font: bold;"><ins>Depositos</ins></h1>

        <asp:Image ID="Image1" runat="server" Height="168px" ImageUrl="~/Resources/pagobancari-png.png" Width="178px" ImageAlign="Left" />

    </div>
    <div class="form-row justify-content-center">
        <aside class="col-sm-8">
            <div class="form-group">
                <div class="form-gruop col-md-12">
                    <div class="col-md-8">
                        <asp:Label ID="Label2" runat="server" Text="Id:"></asp:Label>
                        <asp:TextBox ID="DepositoTextBox" class="form-control col-md-3" Text="0" type="number" runat="server"></asp:TextBox>
                        <asp:Button ID="BuscarButton" class="form-control btn btn-info col-md-2 btn-sm" ValidationGroup="Buscar" runat="server" Text="Buscar" />
                        <asp:RequiredFieldValidator ID="DepoIdRFdValidator" ValidationGroup="Buscar" ControlToValidate="DepositoTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
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
                    <asp:Label ID="Label1" runat="server" Text="Cuenta"></asp:Label>
                    <div class="col-md-8">
                        <asp:DropDownList ID="CuentaDropDownList" runat="server"></asp:DropDownList>
                        <br />
                    </div>
                </div>
                <div class="form-gruop col-md-12">
                    <label for="ConceptoTextbox" class="col-md-3 control-label input-sm">Concepto:</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="ConceptoTextBox" runat="server" class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="ConceptoRFValidator" ValidationGroup="Guardar" ControlToValidate="ConceptoTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="ConceptoREValidator" runat="server" ForeColor="DarkRed" ErrorMessage="Por favor solo letras" ValidationExpression="^[a-zA-Z'.\s]{1,40}$" ValidationGroup="Guardar" ControlToValidate="ConceptoTextBox"></asp:RegularExpressionValidator>
                        <br />
                    </div>
                </div>
                <div class="form-gruop col-md-12">
                    <label for="Monto" class="col-md-3 control-label input-sm">Monto:</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="MontoTextBox" runat="server" class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="MontoRFValidator" ValidationGroup="Guardar" ControlToValidate="MontoTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="MontoREValidator" runat="server" ForeColor="DarkRed" ErrorMessage="Por favor solo numeros" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar" ControlToValidate="MontoTextBox"></asp:RegularExpressionValidator>
                        <br />
                    </div>
                </div>
                <div class="text-center">
                    <asp:Button ID="NuevoBtton" runat="server" Text="Nuevo" class="btn btn-warning btn" />
                    <asp:Button ID="GuardarBtton" ValidationGroup="Guardar" runat="server" Text="Guardar" class="btn btn-success btn" />
                    <asp:Button ID="EliminarBtton" runat="server" ValidationGroup="Eliminar" Text="Eliminar" class="btn btn-danger btn" />
                </div>
            </div>
        </aside>

    </div>


</asp:Content>
