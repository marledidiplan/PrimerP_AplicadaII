using AplicadaIIprimerParcial.Utilidades;
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
    public partial class cPrestamo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarBotton_Click(object sender, EventArgs e)
        {
            Expression<Func<Prestamos, bool>> filtro = m => true;
            RepositorioPrestamo repositorio = new RepositorioPrestamo();

            int id = 0;
            
            switch (FiltroDropDownList.SelectedIndex)
            {
                //Todo
                case 0:
                    filtro = d => true;
                    break;
                    //PrestamoId
                case 1:
                    Util.ToInt(CriterioTextBox.Text);
                    filtro = d => d.PrestamoId == id;
                    break;
                case 2:
                    filtro = d => d.Fecha.Equals(CriterioTextBox.Text);
                    break;
                case 3:
                    id = Util.ToInt(CriterioTextBox.Text);
                    filtro = d => (d.CuentaId == id);
                    break;
                
                
            }
            PrestamoGridView.DataSource = repositorio.GetList(filtro);
            PrestamoGridView.DataBind();
           

           
        }
    }
}