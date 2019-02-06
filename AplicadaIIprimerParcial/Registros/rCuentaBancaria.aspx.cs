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
    public partial class rCuentaBancaria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void Clean()
        {
            CuentaIdTextBox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            NombreTextbox.Text = "";
            BalanceTextBox.Text = "0";
        }

        private CuentasBancarias LlenaClase()
        {
            CuentasBancarias bancarias = new CuentasBancarias();
            bancarias.CuentaId = Util.ToInt(CuentaIdTextBox.Text);
            DateTime date;
            bool resul = DateTime.TryParse(FechaTextBox.Text, out date);
            if (resul == true)
                bancarias.Fecha = date;
            bancarias.Nombre = NombreTextbox.Text;
            bancarias.Balance =Convert.ToInt32(BalanceTextBox.Text);
            return bancarias;
        }

        protected void NuevoBtton_Click(object sender, EventArgs e)
        {
            Clean();
        }

        protected void GuardarBtton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            CuentasBancarias bancarias = new CuentasBancarias();
            RepositorioBase<CuentasBancarias> repo = new RepositorioBase<CuentasBancarias>();

            if (IsValid == false)
            {
                Util.ShowToastr(this.Page, " Campos Vacios", "Error", "Error");
            }
            bancarias = LlenaClase();
            if (CuentaIdTextBox != null)
                paso = repo.Guardar(bancarias);
            else
                paso = repo.Modificar(bancarias);
            if (paso)
            {
                Util.ShowToastr(this.Page, " No se pudo Guardar", "Error", "Error");

                Clean();


            }
            else
            {
                Util.ShowToastr(this.Page, " Guardado con EXITO", "Guardado", "Success");
            }
        }

        protected void EliminarBtton_Click(object sender, EventArgs e)
        {
            int id = Util.ToInt(CuentaIdTextBox.Text);
            RepositorioBase<CuentasBancarias> repo = new RepositorioBase<CuentasBancarias>();

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
            RepositorioBase<CuentasBancarias> repo = new RepositorioBase<CuentasBancarias>();
            CuentasBancarias bancarias = new CuentasBancarias();
            bancarias = repo.Buscar(Util.ToInt(CuentaIdTextBox.Text));

            if (bancarias != null)
            {
                FechaTextBox.Text = bancarias.Fecha.ToString();
                NombreTextbox.Text = bancarias.Nombre;
               BalanceTextBox.Text = bancarias.Balance.ToString();

                Util.ShowToastr(this.Page, "Su busqueda fue exitosa", "EXITO", "Info");
            }
            else
            {
                Util.ShowToastr(this.Page, " No existe", "Error", "Error");
                Clean();
            }
        }
    }
}