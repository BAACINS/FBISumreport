using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


using System.Net;
using System.Security.Principal;
using System.Collections.Generic;
using System.Text;
using Microsoft.Reporting.WebForms;

namespace FBISumreport
{
    [Serializable]
    public sealed class ReportServerCredentials :
        IReportServerCredentials
    {
        public WindowsIdentity ImpersonationUser
        {
            get
            {
                // Use the default Windows user.  Credentials will be
                // provided by the NetworkCredentials property.
                return null;
            }
        }

        public ICredentials NetworkCredentials
        {
            get
            {
                // Read the user information from the Web.config file.  
                // By reading the information on demand instead of
                // storing it, the credentials will not be stored in
                // session, reducing the vulnerable surface area to the
                // Web.config file, which can be secured with an ACL.

                // User name
                //string userName = "administrateur";
                string userName = "life";//WebConfig.ReportViewerUser;

                if (string.IsNullOrEmpty(userName))
                    throw new Exception(
                        "Missing user name from web.config file");

                // Password
                //string password = "citroen";
                string password = "baac@123";//WebConfig.ReportViewerPassword;

                if (string.IsNullOrEmpty(password))
                    throw new Exception(
                        "Missing password from web.config file");

                // Domain
                //string domain = "";
                string domain = "";//WebConfig.ReportViewerDomain;

                //if (string.IsNullOrEmpty(domain))
                //    throw new Exception(
                //        "Missing domain from web.config file");

                if (string.IsNullOrEmpty(domain))
                    return new NetworkCredential(userName, password);
                else
                    return new NetworkCredential(userName, password, domain);
            }
        }

        public bool GetFormsCredentials(out Cookie authCookie,
                    out string userName, out string password,
                    out string authority)
        {
            authCookie = null;
            userName = null;
            password = null;
            authority = null;

            // Not using form credentials
            return false;
        }


        public static string ReportServerUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["ReportServerUrl"];
            }
        }

        public static string ReportPath
        {
            get
            {
                return ConfigurationManager.AppSettings["ReportPath"];
            }
        }

        public static string ReportViewerUser
        {
            get
            {
                return ConfigurationManager.AppSettings["ReportViewerUser"];
            }
        }

        public static string ReportViewerPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["ReportViewerPassword"];
            }
        }

        public static string ReportViewerDomain
        {
            get
            {
                return ConfigurationManager.AppSettings["ReportViewerDomain"];
            }
        }
    }
}
