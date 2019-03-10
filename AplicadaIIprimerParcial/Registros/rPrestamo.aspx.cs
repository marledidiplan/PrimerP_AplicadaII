using AplicadaIIprimerParcial.Utilidades;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            //CuentasBancarias bancarias = new CuentasBancarias();
            LlenarCombo();

        }

        private Prestamos LlenaClase(Prestamos prestamo)
        {
           
            prestamo = (Prestamos)ViewState["Prestamos"];
            prestamo.PrestamoId = Util.ToInt(IdPrestamoTextBox.Text);
            DateTime date;
            bool resul = DateTime.TryParse(FechaTextBox.Text, out date);
            if (resul == true)
                prestamo.Fecha = date;
            prestamo.CuentaId = Util.ToInt(CuentDropDownList.Text);           
            prestamo.Capital = Util.ToDecimal(CapitalTextBox.Text);
            prestamo.InteresAnual = Util.ToDecimal(InteresTextBox.Text);
            prestamo.TiempoMeses = Util.ToInt(TiempoTextBox.Text);
            prestamo.Detalle = (List<Cuotas>)ViewState["Cuotas"];
            return prestamo;

        }
        private void LlenarCombo()
        {
            RepositorioBase<CuentasBancarias> repositorio = new RepositorioBase<CuentasBancarias>();
            CuentDropDownList.DataSource = repositorio.GetList(m => true);
            CuentDropDownList.DataValueField = "CuentaId";
            CuentDropDownList.DataValueField = "Nombre";
            CuentDropDownList.DataBind();
            ViewState["Prestamos"] = new Prestamos();
            this.BindGrid();
        }

        private void Clean()
        {
            IdPrestamoTextBox.Text = "0";
            CapitalTextBox.Text = string.Empty;
            InteresTextBox.Text = string.Empty;
            TiempoTextBox.Text = string.Empty;
            ViewState["Prestamos"] = new Prestamos();
           
        }
        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Clean();
        }

        protected void LlenarCampos(Prestamos prestamo)
        {
            Clean();
            IdPrestamoTextBox.Text = prestamo.PrestamoId.ToString();
            CuentDropDownList.Text = prestamo.CuentaId.ToString();
            CapitalTextBox.Text = prestamo.Capital.ToString();
            InteresTextBox.Text = prestamo.InteresAnual.ToString();
            TiempoTextBox.Text = prestamo.TiempoMeses.ToString();

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
                Clean();
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
            Cuotas ctas = new Cuotas();
            List<Cuotas> ListCuotas = new List<Cuotas>();
            decimal capital = Util.ToDecimal(CapitalTextBox.Text);
            decimal interes = Util.ToDecimal(InteresTextBox.Text) /100;
            int tiempoMeses = Util.ToInt(TiempoTextBox.Text);
            decimal pagar;

            for (int i = 0; i < tiempoMeses; i++)
            {
                ctas.Interes = interes * capital / tiempoMeses;
                ctas.Capital = capital / tiempoMeses;
                pagar = ctas.Interes * tiempoMeses + capital;
                ctas.Monto = ctas.Interes + ctas.Capital;

                if (i == 0)
                {
                    ctas.Bce = pagar - (ctas.Interes + ctas.Capital);
                }
                else
                    ctas.Bce = ctas.Bce - (ctas.Interes + ctas.Capital);

                if (i == 0)
                {
                    ListCuotas.Add(new Cuotas( 0, Util.ToInt(IdPrestamoTextBox.Text), ctas.Fecha, ctas.Interes, ctas.Capital, ctas.Bce, ctas.Monto));
                }
                else
                {
                    ListCuotas.Add(new Cuotas( 0, Util.ToInt(IdPrestamoTextBox.Text), ctas.Fecha.AddMonths(i), ctas.Interes, ctas.Capital, ctas.Bce, ctas.Monto));
                }



            }
            ViewState["Cuotas"] = ListCuotas;
            DetalleGridView.DataSource = ViewState["Cuotas"];
            DetalleGridView.DataBind();

        }

        //public List<Cuotas> CalcularValores()
        //{
          
        //    return ListCuotas;

        //}
    }
}