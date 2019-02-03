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

                LLenarComboBox();
                ViewState["Depositos"] = new Depositos();
            }
        }
        public Depositos LLenaClase()
        {
            Depositos depo = new Depositos();
            depo = ((Depositos)ViewState["Depositos"]);
            depo.DepositoId = Util.ToInt(DepositoTextBox.Text);
            DateTime date;
            bool resul = DateTime.TryParse(FechaTextBox.Text, out date);
            if (resul == true)
                depo.Fecha = date;
            depo.Concepto = ConceptoTextBox.Text;
            depo.CuentaId = Util.ToInt(CuentaDropDownList.SelectedValue);
            depo.Monto = Convert.ToInt32(MontoTextBox.Text);

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
        protected void Grid()
        {
            DepositoGridView.DataSource = ((Depositos)ViewState["Deposito"]).CuentasB.Detalle;
            DepositoGridView.DataBind();
        }


    }
}