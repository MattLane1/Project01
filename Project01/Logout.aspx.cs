//Using statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//required for Identity and OWIN Security
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

/**
 * @author: Matthew Lane
 * @date: June 6, 2016
 * @page: This page allows the user to logout
 * @version 1.0 - Set up the form with connected buttons
 */

namespace Project01
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Store session info and authentication methods in the authentiationManager object
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            // Sign out user
            authenticationManager.SignOut();

            //Redirect to default page
            Response.Redirect("~/Login.aspx");
        }
    }
}