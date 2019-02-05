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
    public partial class cCuentasBancarias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarBotton_Click(object sender, EventArgs e)
        {
            Expression<Func<CuentasBancarias, bool>> filtro = m => true;
            RepositorioBase<CuentasBancarias> repositorio = new RepositorioBase<CuentasBancarias>();

            int id;
            decimal n;
            switch(FiltroDropDownList.SelectedIndex)
            {
                case 0:

                    repositorio.GetList(c => true);
                    break;
                case 1:
                    id = Utilidades.Util.ToInt(CriterioTextBox.Text);
                    filtro = c => c.CuentaId == id;
                    break;
                case 2:
                    filtro = c => c.Nombre.Contains(CriterioTextBox.Text);
                    break;
                case 3:
                    n = Utilidades.Util.ToDecimal(CriterioTextBox.Text);
                    filtro = c => c.Balance == n;
                    break;
            }

            CuentasGridView.DataSource = repositorio.GetList(filtro);
            CuentasGridView.DataBind();
        }
    }
}