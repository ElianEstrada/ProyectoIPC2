using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace Fase3
{
    public partial class Reporte1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            
            if(Session["reporte"] != null)
            {
                CrystalReportViewer1.ReportSource = (InventarioBodega)Session["reporte"];
            }

            CrystalReportViewer1.RefreshReport();
        }

        

        protected void Button1_Click(object sender, EventArgs e)
        {
            InventarioBodega inventario = new InventarioBodega();
            inventario.SetParameterValue("@idBodega", int.Parse(TextBox1.Text));
            inventario.SetParameterValue("@idUsuario", int.Parse(Session["usuario"].ToString()));

            CrystalReportViewer1.ReportSource = inventario;
            CrystalReportViewer1.RefreshReport();
        }
    }
}