using BLL;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicadaIIprimerParcial.Consulta
{
    public partial class cDepositos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void BuscarBotton_Click(object sender, EventArgs e)
        {
            Expression<Func<Depositos, bool>> filtro = m => true;
            RepositorioBase<Depositos> repositorio = new RepositorioBase<Depositos>();

            int id;
            decimal n;
            switch (FiltroDropDownList.SelectedIndex)
            {
                case 0:

                    repositorio.GetList(c => true);
                    break;
                case 1:
                    id = Utilidades.Util.ToInt(CriterioTextBox.Text);
                    filtro = c => c.DepositoId == id;
                    break;
                case 2:
                    filtro = c => c.CuentaId.Equals(CriterioTextBox.Text);
                    break;
                case 3:
                    filtro = c => c.Concepto.Contains(CriterioTextBox.Text);
                    break;
                case 4:
                    n = Utilidades.Util.ToDecimal(CriterioTextBox.Text);
                    filtro = c => c.Monto == n;
                    break;
            }
            DepositoGridView.DataSource = repositorio.GetList(filtro);
            DepositoGridView.DataBind();
        }
    }
}
