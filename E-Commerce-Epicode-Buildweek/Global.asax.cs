using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace E_Commerce_Epicode_Buildweek
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();
            var httpException = exception as HttpException;
            if(httpException != null && httpException.GetHttpCode() == 404)
            {
                Response.Redirect("~/NotFound.aspx");
            }
        }
    }
}