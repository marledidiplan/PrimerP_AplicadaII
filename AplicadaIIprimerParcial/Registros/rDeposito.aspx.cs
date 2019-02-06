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
    public partial class rDeposito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CuentasBancarias bancarias = new CuentasBancarias();

            if (!Page.IsPostBack)
            {

                DepositoIdTextBox.Text = "0";
                LLenarComboBox();
               
            }
        }
        public Depositos LlenaClase()
        {
            Depositos depo = new Depositos();
            depo.DepositoId = Util.ToInt(DepositoIdTextBox.Text);
            DateTime date;
            bool resul = DateTime.TryParse(FechaTextBox.Text, out date);
            if (resul == true)
                depo.Fecha = date;
            depo.Concepto = ConceptoTextBox.Text;
            depo.CuentaId = Util.ToInt(CuentaDropDownList.SelectedValue);
            depo.Monto = Convert.ToDecimal(MontoTextBox.Text);

            return depo;
        }
        private void LLenarComboBox()
        {
            RepositorioBase<CuentasBancarias> repo = new RepositorioBase<CuentasBancarias>();

            CuentaDropDownList.DataSource = repo.GetList(t => true);
            CuentaDropDownList.DataValueField = "CuentaId";
            CuentaDropDownList.DataTextField = "Nombre";
            CuentaDropDownList.DataBind();
        }


        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Clean();
        }

        private void Clean()
        {
            DepositoIdTextBox.Text = "0";
            FechaTextBox.Text = DateTime.Now.ToString("yyyy-MM-dd");
            ConceptoTextBox.Text = "";
            MontoTextBox.Text = "0";
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Depositos depo = new Depositos();
            DepositoRepositorio repo = new DepositoRepositorio();

            if(IsValid ==false)
            {
                Util.ShowToastr(this.Page, " Campos Vacios", "Error", "Error");
            }

            depo = LlenaClase();
            if (Convert.ToInt32(DepositoIdTextBox.Text) == 0)
            {
                paso = repo.Guardar(depo);
                Util.ShowToastr(this.Page, "Guardado con EXITO", "Guardado", "Success");
            }
            else
            {
                paso = repo.Modificar(depo);
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
            int id = Util.ToInt(DepositoIdTextBox.Text);
            DepositoRepositorio repo = new DepositoRepositorio();

            if (repo.Eliminar(id))
            {
                Util.ShowToastr(this.Page, " Eliminado con EXITO", "Eliminado", "Success");
                Clean();
            }
            else

                Util.ShowToastr(this.Page, " No se pudo eliminar", "Error", "Error");
        }

        protected void BuscarButton_Clik(object sender, EventArgs e)
        {
            RepositorioBase<Depositos> repo = new RepositorioBase<Depositos>();
            Depositos depo = new Depositos();
            depo = repo.Buscar(Util.ToInt(DepositoIdTextBox.Text));

            if (depo != null)
            {
                FechaTextBox.Text = depo.Fecha.ToString();
                ConceptoTextBox.Text = depo.Concepto;
                MontoTextBox.Text = depo.Monto.ToString();

                Util.ShowToastr(this.Page, "Su busqueda fue exitosa", "EXITO", "Info");

            }
            else
            {
                Util.ShowToastr(this.Page, " No existe", "Error", "Error");
            }
        }
    }
    
}