﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportViewer.aspx.cs" Inherits="FBISumreport.ReportViewer" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div style="width: 100%; text-align: center;">
            <asp:Label ID="lblReportHeader" runat="server">รายงานผลการดำเนินงานเงินฝากสงเคราะห์ชีวิต</asp:Label>
        </div>
        <br />
        <div style="margin: auto; width: 950px; border: 2px solid #808080; padding: 10px; overflow: auto;">
            <table style="width: 100%;">
                <tr>
                    <td>ฝ่าย :</td>
                    <td>
                        <asp:DropDownList ID="ddlRegion" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged" CssClass="dropDownList"></asp:DropDownList></td>
                    <td>ประเภท :</td>
                    <td>
                        <asp:DropDownList ID="ddlPlan" runat="server" OnSelectedIndexChanged="ddlPlan_SelectedIndexChanged" AutoPostBack="True" CssClass="dropDownList"></asp:DropDownList></td>
                    <td>แบบ :</td>
                    <td>
                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="dropDownList" AutoPostBack="True"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td>สนจ. :</td>
                    <td>
                        <asp:DropDownList ID="ddlProvince" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged" CssClass="dropDownList"></asp:DropDownList></td>
                    <td>วันที่ :</td>
                    <td>
                        &nbsp;</td>
                    <td>ถึง :</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>สาขา :</td>
                    <td>
                        <asp:DropDownList ID="ddlBranch" runat="server" CssClass="dropDownList"></asp:DropDownList></td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="7" align="center">
                        <asp:Button ID="btnPreview" runat="server" Text="Preview" OnClick="btnPreview_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:Button ID="btnViewReport" runat="server" Text="View" Width="76px" OnClick="btnViewReport_Click" />
        </div>
        <div>
            <rsweb:reportviewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Height="100%" 
            Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" width="100%"
            style="text-align: center" ProcessingMode="Remote" ShowParameterPrompts="False">
            <LocalReport EnableHyperlinks="True">
            </LocalReport>
         </rsweb:reportviewer>
        </div>
    </form>
</body>
</html>
