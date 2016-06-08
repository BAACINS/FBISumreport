<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportViewer.aspx.cs" Inherits="FBISumreport.ReportViewer" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
