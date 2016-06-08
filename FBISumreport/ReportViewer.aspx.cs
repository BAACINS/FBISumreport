using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FBISumreport
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        public static object ServerReport { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnViewReport_Click(object sender, EventArgs e)
        {
            //http://lifereport/ReportServer/Pages/ReportViewer.aspx //url test report
            //ReportSearchParam reportParam = UCReportSearch1.GetSearchField();


            string reportName = "CommissionFBIRate";
            string reportPath = "BaaclifeReport";
            string ReportServerUrl = "http://lifeuatdb/ReportServer";
            //lifereport/reportserver (url production) : must open soap webservice port

            ReportViewer1.ServerReport.ReportServerUrl = new System.Uri(ReportServerUrl);


            //while (ReportViewer.ServerReport.IsDrillthroughReport)
            //{
            //    ReportViewer.PerformBack();
            //}

            //// Could also be set to the selection of a ListBox.
            string strReport = string.Format("/{0}/{1}", reportPath, reportName);
            ReportViewer1.ServerReport.ReportPath = strReport;

            //string userName = "WebConfig.ReportViewerUser";
            //string password = "WebConfig.ReportViewerPassword";


            ReportViewer1.ServerReport.ReportServerCredentials = new ReportServerCredentials();

            List<Microsoft.Reporting.WebForms.ReportParameter> parameters = new List<Microsoft.Reporting.WebForms.ReportParameter>();

            parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("AreaCode", "0"));
            parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("UpperDivision", "0"));
            parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("Division", "0"));
            parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("AreaCodeName", "reportParam.AreaCodeName"));
            parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("UpperDivisionName", "reportParam.UpperDivisionCodeName"));
            parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("PlanCategory", "0"));
            parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("PlanCategoryName", "reportParam.PlanCategoryName"));
            parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("PlanCode", "0"));
            parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("PlanCodeName", "reportParam.PlanCodeName"));
            parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("StartDate", "2016-01-01"));
            DateTime endDate = DateTime.Now;//reportParam.EndDate.Value.AddDays(1).AddMilliseconds(-1);
            parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("EndDate", "2016-01-01"));

            bool isBranch = true;//BaacLifeUtil.checkBranch(division);
            if (isBranch)
            {
                parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("DivisionName", "division.DivisionName"));
            }
            else
            {
                parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("DivisionName", "reportParam.DivisionCodeName"));
            }
            parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("IsBranch", isBranch.ToString()));

            ReportViewer1.ServerReport.SetParameters(parameters);
            ReportViewer1.ServerReport.Refresh();
        }
    }
}