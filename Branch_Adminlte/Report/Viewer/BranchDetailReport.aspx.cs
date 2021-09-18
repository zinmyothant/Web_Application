using Branch_Adminlte.ViewModel;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Branch_Adminlte.Report.Viewer
{
    public partial class BranchDetailReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //clear
                this.ReportViewer1.Reset();
                this.ReportViewer1.LocalReport.DataSources.Clear();
                //load report
                this.ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/Report/Rdlc/BranchDetailReport.rdlc");
                //catch report data
                List<BranchViewModel> items = Session["ReportData"] as List<BranchViewModel>;
                //load data to datasource
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name ="BranchDetailDataSet";
                reportDataSource.Value = items;
                //load datasource to report data
                this.ReportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.ReportViewer1.LocalReport.Refresh();
                Session["ReportData"] = null;

            }
        }
    }
}