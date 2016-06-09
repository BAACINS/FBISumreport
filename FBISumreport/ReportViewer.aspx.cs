using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FBISumreport
{
    public partial class ReportViewer : System.Web.UI.Page
    {
        CultureInfo us = System.Globalization.CultureInfo.GetCultureInfo("en-US");
        CultureInfo th = System.Globalization.CultureInfo.GetCultureInfo("th-TH");
        C001_GetData getData = new C001_GetData();

        string DateFrom = string.Empty;
        string DateTo = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            GetRegion();
            GetProvince();
            GetBranch();
            GetPlanCategories();
            GetPlanAssurance();

            string DateNow = DateTime.Now.ToString("dd/MM/yyyy", th);
            //txtDateFrom.TextDate = DateNow;
            //txtDateTo.TextDate = DateNow;
        }

        #region Methods
        private void GetRegion()
        {
            ddlRegion.DataSource = getData.SearchRegionFromDBO();
            ddlRegion.DataTextField = "DivisionAreaName";
            ddlRegion.DataValueField = "DivisionAreaCode";
            ddlRegion.DataBind();
        }

        private void GetProvince()
        {
            ddlProvince.DataSource = getData.SearchProvinceFromDBO(ddlRegion.SelectedValue);
            ddlProvince.DataTextField = "PROVINCENAME";
            ddlProvince.DataValueField = "PROVINCENO";
            ddlProvince.DataBind();
        }

        private void GetBranch()
        {
            ddlBranch.DataSource = getData.SearchBranchFromDBO(ddlProvince.SelectedValue, ddlRegion.SelectedValue);
            ddlBranch.DataTextField = "DivisionName";
            ddlBranch.DataValueField = "DivisionCode";
            ddlBranch.DataBind();
        }

        private void GetPlanCategories()
        {
            ddlPlan.DataSource = getData.GetPlanCategories();
            ddlPlan.DataTextField = "PlanCategoryName";
            ddlPlan.DataValueField = "PlanCategoryID";
            ddlPlan.DataBind();
        }

        private void GetPlanAssurance()
        {
            ddlCategory.DataSource = getData.GetPlanAssurance(ddlPlan.SelectedValue);
            ddlCategory.DataTextField = "PLANNAME";
            ddlCategory.DataValueField = "PLANCODE";
            ddlCategory.DataBind();
        }

        #endregion

        #region DDLs
        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetProvince();
            GetBranch();
        }

        protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBranch();
        }

        protected void ddlPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetPlanAssurance();
        }
        #endregion

        protected void btnViewReport_Click(object sender, EventArgs e)
        {
            //http://lifereport/ReportServer/Pages/ReportViewer.aspx //url test report
            //ReportSearchParam reportParam = UCReportSearch1.GetSearchField();

            string reportName = "CommissionFBIRate";
            string reportPath = "BaaclifeReport";

            //string ReportServerUrl = "http://lifeuatdb/ReportServer";

            string ReportServerUrl = "http://lifereport/reportserver";
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

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            //http://lifereport/ReportServer/Pages/ReportViewer.aspx //url test report
            //ReportSearchParam reportParam = UCReportSearch1.GetSearchField();

            //DateFrom = DateTime.Parse(txtDateFrom.TextDate.ToString()).ToString("yyyy-MM-dd", us);
            //DateTo = DateTime.Parse(txtDateTo.TextDate.ToString()).ToString("yyyy-MM-dd", us);

            string reportName = "CommissionFBIRate";
            string reportPath = "BaaclifeReport";
            string ReportServerUrl = "http://lifeuatdb/ReportServer";
            //string ReportServerUrl = "http://lifereport/reportserver";
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

            parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("AreaCode", ddlRegion.SelectedValue.ToString()));
            parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("UpperDivision", ddlProvince.SelectedValue.ToString()));
            parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("Division", ddlBranch.SelectedValue.ToString()));
            parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("AreaCodeName", ddlBranch.SelectedItem.Text));
            parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("UpperDivisionName", ddlProvince.SelectedItem.Text));
            parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("PlanCategory", ddlPlan.SelectedValue.ToString()));
            parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("PlanCategoryName", ddlPlan.SelectedItem.Text));
            parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("PlanCode", ddlCategory.SelectedValue.ToString()));
            parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("PlanCodeName", ddlCategory.SelectedItem.Text));
            parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("StartDate", DateFrom));
            DateTime endDate = DateTime.Now;//reportParam.EndDate.Value.AddDays(1).AddMilliseconds(-1);
            parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("EndDate", DateTo));

            bool isBranch = true;//BaacLifeUtil.checkBranch(division);
                                 //if (isBranch)
                                 //{
            parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("DivisionName", "division.DivisionName"));
            //}
            //else
            //{
            //    parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("DivisionName", "reportParam.DivisionCodeName"));
            //}
            parameters.Add(new Microsoft.Reporting.WebForms.ReportParameter("IsBranch", isBranch.ToString()));

            ReportViewer1.ServerReport.SetParameters(parameters);
            ReportViewer1.ServerReport.Refresh();
        }
    }
}