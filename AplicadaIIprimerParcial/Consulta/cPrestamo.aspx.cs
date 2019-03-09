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
            RepositorioPrestamo<Prestamos> repositorio = new RepositorioPrestamo<Prestamos>();

            int id;
            decimal n;
            switch (FiltroDropDownList.SelectedIndex)
            {
              
            }

           
        }
    }
}