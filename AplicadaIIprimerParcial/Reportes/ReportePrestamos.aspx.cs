using BLL;
using Entidades;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AplicadaIIprimerParcial.Reportes
{
    public partial class ReportePrestamos : System.Web.UI.Page
    {
        Expression<Func<Prestamos, bool>> filtrar = m => true;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PrestamosReportViewer.ProcessingMode = ProcessingMode.Local;
                PrestamosReportViewer.Reset();
                PrestamosReportViewer.LocalReport.ReportPath = Server.MapPath(@"~\Reportes\ListadoPrestamos.rdlc");
                PrestamosReportViewer.LocalReport.DataSources.Clear();
                PrestamosReportViewer.LocalReport.DataSources.Add(new ReportDataSource("Prestamos", ListPrestamo(filtrar)));
                PrestamosReportViewer.LocalReport.Refresh();
            }
        }
        public static List<Prestamos> ListPrestamo(Expression<Func<Prestamos, bool>> filtro)
        {
            filtro = p => true;
            RepositorioBase<Prestamos> repositorio = new RepositorioBase<Prestamos>();
            List<Prestamos> list = new List<Prestamos>();

            list = repositorio.GetList(filtro);

            return list;
        }

    }
}