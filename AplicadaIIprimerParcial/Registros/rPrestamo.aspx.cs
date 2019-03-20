﻿using AplicadaIIprimerParcial.Utilidades;
using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicadaIIprimerParcial.Registros
{
    public partial class rPrestamo : System.Web.UI.Page
    {
        List<Cuotas> listDetalle = new List<Cuotas>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarCombo();
            }
        }

        public List<Cuotas> GetCuotas()
        {
            List<Cuotas> listDetalle = new List<Cuotas>();
            listDetalle.Add(new Cuotas());
            return listDetalle;
        }

        private Prestamos LlenaClase(Prestamos prestamo)
        {
            prestamo = (Prestamos)ViewState["Prestamos"];
            prestamo.PrestamoId = Util.ToInt(IdPrestamoTextBox.Text);
            DateTime date;
            bool resul = DateTime.TryParse(FechaTextBox.Text, out date);
            if (resul == true)
                prestamo.Fecha = date;
            prestamo.CuentaId = Util.ToIntObject(CuentaDropDownList.SelectedValue);
            prestamo.Capital = Util.ToDecimal(CapitalTextBox.Text);
            prestamo.InteresAnual = Util.ToDecimal(InteresTextBox.Text);
            prestamo.TiempoMeses = Util.ToInt(TiempoTextBox.Text);
            prestamo.MontoPrestamo = Util.ToInt(MontoTextBox.Text);
            prestamo.Detalle = GetCuotas();
            return prestamo;

        }
        private void LlenarCombo()
        {
            RepositorioBase<CuentasBancarias> repositorio = new RepositorioBase<CuentasBancarias>();
            CuentaDropDownList.DataSource = repositorio.GetList(m => true);
            CuentaDropDownList.DataValueField = "CuentaId";
            CuentaDropDownList.DataTextField = "Nombre";
            CuentaDropDownList.DataBind();

            ViewState["Prestamos"] = new Prestamos();
        }

        private void Clean()
        {
            IdPrestamoTextBox.Text = "0";
            CapitalTextBox.Text = string.Empty;
            InteresTextBox.Text = string.Empty;
            TiempoTextBox.Text = string.Empty;
            ViewState["Prestamos"] = new Prestamos();
            //DetalleGridView.DataSource = null;
           
        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Clean();
        }

        protected void LlenarCampos(Prestamos prestamo)
        {
            Clean();
            IdPrestamoTextBox.Text = prestamo.PrestamoId.ToString();
            CuentaDropDownList.Text = prestamo.CuentaId.ToString();
            CapitalTextBox.Text = prestamo.Capital.ToString();
            InteresTextBox.Text = prestamo.InteresAnual.ToString();
            TiempoTextBox.Text = prestamo.TiempoMeses.ToString();
            MontoTextBox.Text = prestamo.MontoPrestamo.ToString();
            CuentaDropDownList.DataSource = prestamo.Detalle;

            //this.BindGrid();
        }
        protected void BindGrid()
        {
            DetalleGridView.DataSource = ((Prestamos)ViewState["Prestamos"]).Detalle;
            DetalleGridView.DataBind();
        }


        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Prestamos prestamo = new Prestamos();
            RepositorioPrestamo repo = new RepositorioPrestamo();

            if (IsValid == false)
            {
                Util.ShowToastr(this.Page, " Campos Vacios", "Error", "Error");
            }

            prestamo = LlenaClase(prestamo);
            if (prestamo.PrestamoId == 0)
            {
                paso = repo.Guardar(prestamo);
                Util.ShowToastr(this.Page, "Guardado con EXITO", "Guardado", "Success");
            }
            else
            {
                paso = repo.Modificar(prestamo);
                Util.ShowToastr(this.Page, "Modificado con EXITO", "Guardado", "Success");
            }

            if (paso)
            {
                Clean();
            }
            else
            {
                Util.ShowToastr(this.Page, "No se pudo Guardar", "Error", "Error");
            }

        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Util.ToInt(IdPrestamoTextBox.Text);
            RepositorioPrestamo repo = new RepositorioPrestamo();

            if (repo.Eliminar(id))
            {
                Util.ShowToastr(this.Page, " Eliminado con EXITO", "Eliminado", "Success");
                Clean();
            }
            else

                Util.ShowToastr(this.Page, " No se pudo eliminar", "Error", "Error");
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioPrestamo repo = new RepositorioPrestamo();
            var prest = repo.Buscar(Util.ToInt(IdPrestamoTextBox.Text));

            if (prest != null)
            {
                //Clean();
                LlenarCampos(prest);
                  Util.ShowToastr(this.Page, "Su busqueda fue exitosa", "EXITO", "Info");
            }
            else
            {
                Util.ShowToastr(this.Page, " No existe", "Error", "Error");
                Clean();
            }
        }

        protected void CacularButton_Click(object sender, EventArgs e)
        {
            Prestamos prestamo = new Prestamos();
            decimal capital = Util.ToDecimal(CapitalTextBox.Text);
            decimal interes = Util.ToDecimal(InteresTextBox.Text) /100;
            int tiempoMeses = Util.ToInt(TiempoTextBox.Text);
            DateTime fecha = Util.ToDate(FechaTextBox.Text).Date;
            decimal pagar;
            decimal capitalmen = 0;
            decimal interesmen = 0;
            decimal montomen = 0;
            decimal balancemen = 0;
            decimal montopres = 0;
            montopres = capital + (interes * capital);
            for (int i = 0; i < tiempoMeses; i++)
            {
                interesmen = interes * capital / tiempoMeses;
                capitalmen = capital / tiempoMeses;
                pagar = interesmen * tiempoMeses + capital;
                montomen = interesmen + capitalmen;

                if (i == 0)
                {
                    balancemen = pagar - (interesmen + capitalmen);
                }
                else
                    balancemen = balancemen - (interesmen + capitalmen);

                if (i == 0)
                {
                    prestamo.AgregarDetalle(0, prestamo.PrestamoId, fecha, interesmen, capitalmen, balancemen, montomen);
                }
                else
                {
                    prestamo.AgregarDetalle(0,  prestamo.PrestamoId, fecha.AddMonths(i), interesmen, capitalmen, balancemen, montomen);
                }

            }
            ViewState["Prestamos"] = prestamo;
            BindGrid();
            MontoTextBox.Text = montopres.ToString();
        }

    }
}