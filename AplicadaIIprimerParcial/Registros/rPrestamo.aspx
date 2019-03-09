<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rPrestamo.aspx.cs" Inherits="AplicadaIIprimerParcial.Registros.rPrestamo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />

    <div class="panel-body">
        <div class="form-horizontal col-12" role="form">
            <div class="text-center">
                <h1 style="font-size: x-large; font-family: 'Agency FB', Times, serif; font: bold;"><ins>Prestamo</ins></h1>
                <asp:Image ID="Image1" runat="server" Height="168px" ImageUrl="~/Resources/prestamo.png" Width="178px" ImageAlign="Baseline" />
            </div>
            <div class="form-group">
                <div class="form-gruop col-md-12">
                    <div class="col-md-8">
                        <asp:Label ID="Label1" runat="server" Text="Id"></asp:Label>
                        <asp:TextBox ID="IdPrestamoTextBox" class="form-control col-md-3" Text="0" type="number" runat="server"></asp:TextBox>
                        <asp:Button ID="BuscarButton" class="form-control btn btn-info col-md-2 btn-sm" ValidationGroup="Buscar" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                        <asp:RequiredFieldValidator ID="IdPrestamoRFValidator" ControlToValidate="IdPrestamoTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="form-gruop col-md-12">
                    <label for="FechaLabel" class="col-md-3 control-label input-sm">Fecha:</label>
                    <div class="col-md-8">
                        <asp:TextBox ID="FechaTextBox" type="date" runat="server" class="form-control input-sm" ReadOnly="True"></asp:TextBox>
                        <br />
                    </div>
                </div>
                <div class="form-gruop col-md-12">
                    <asp:Label ID="CuentaLabel" runat="server" Text="Cuenta"></asp:Label>
                    <div class="col-md-8">
                        <asp:DropDownList ID="CuentDropDownList" runat="server" class="form-control input-sm"></asp:DropDownList>
                        <br />
                    </div>
                </div>
                <div class="form-gruop col-md-12">
                    <asp:Label ID="CapitalLabel" runat="server" Text="Capital"></asp:Label>
                    <div class="col-md-8">
                        <asp:TextBox ID="CapitalTextBox" runat="server" class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="CapitalRFValidator" ValidationGroup="Guardar" ControlToValidate="CapitalTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="CapitalREValidator" runat="server" ForeColor="DarkRed" ErrorMessage="Por favor solo numeros" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar" ControlToValidate="CapitalTextBox"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-gruop col-md-12">
                    <asp:Label ID="InteresLabel" runat="server" Text="Interes Anual"></asp:Label>
                    <div class="col-md-8">
                        <asp:TextBox ID="InteresTextBox" runat="server" class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="InteresRFValidator" ValidationGroup="Guardar" ControlToValidate="InteresTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="InteresValidator" runat="server" ForeColor="DarkRed" ErrorMessage="Por favor solo numeros" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar" ControlToValidate="InteresTextBox"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-gruop col-md-12">
                     <asp:Label ID="TiempoLabel" runat="server" Text="Tiempo en Meses"></asp:Label>
                     <div class="col-md-8">
                        <asp:TextBox ID="TiempoTextBox" runat="server" class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="TiempoRFValidator1" ValidationGroup="Guardar" ControlToValidate="TiempoTextBox" runat="server" ErrorMessage="*" Display="Dynamic" ForeColor="DarkRed"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="TiempoValidator" runat="server" ForeColor="DarkRed" ErrorMessage="Por favor solo numeros" ValidationExpression="(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" ValidationGroup="Guardar" ControlToValidate="TiempoTextBox"></asp:RegularExpressionValidator>
                     </div>
                 <div class="form-gruop col-sm-4 ">
                       <asp:Button ID="CacularButton" runat="server" Text="Calcular" class="btn btn-success btn" />
                  </div>
                </div>


                <asp:GridView ID="DetalleGridView" class="table table-condensed table-bordered table-responsive" runat="server" CellPadding="4" ForeColor="Teal" GridLines="None">
                    <AlternatingRowStyle BorderColor="White" />
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" />
                        <asp:BoundField DataField="NCuotas" HeaderText="Cuota #" />
                        <asp:BoundField DataField="Fecha" HeaderText="Fecha" />
                        <asp:BoundField DataField="Interes" HeaderText="Interes" />
                        <asp:BoundField DataField="Capital" HeaderText="Balance" />
                    </Columns>
                    <HeaderStyle BackColor="Window" Font-Bold="true" />
                </asp:GridView>

                <br />

                <div class="panel">
                    <div class="text-center">
                        <div class="form-group">
                            <asp:Button ID="NuevoButton" runat="server" Text="Nuevo" class="btn btn-warning btn" OnClick="NuevoButton_Click" />
                            <asp:Button ID="GuardarButton" ValidationGroup="Guardar" runat="server" Text="Guardar" class="btn btn-success btn" OnClick="GuardarButton_Click" />
                            <asp:Button ID="EliminarButton" runat="server" ValidationGroup="Eliminar" Text="Eliminar" class="btn btn-danger btn" OnClick="EliminarButton_Click" />
                        </div>
                    </div>

                </div>
            </div>
        </div>

    </div>

</asp:Content>
