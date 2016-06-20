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
 * @version: 0.0.2 - Changes links to apply to project needs
 */

namespace Project01
{
    public partial class Navbar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check if a user is logged in
                if(HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    //Show the private content
                    PrivatePlaceHolder.Visible = true;
                    PublicPlaceHolder.Visible = false;
                }
                else
                {
                    //Show the public content
                    PrivatePlaceHolder.Visible = false;
                    PublicPlaceHolder.Visible = true;
                }
                SetActivePage();
            }
        }

        /**
         * This method adds a css class of "active" to list items
         * relating to the current page
         * 
         * @private
         * @method SetActivePage
         * @return {void}
         */
        private void SetActivePage()
        {
            switch (Page.Title)
            {
                case "Scores":
                    @default.Attributes.Add("class", "active");
                    break;
                case "Login":
                    Login.Attributes.Add("class", "active");
                    break;
                case "Register":
                    Register.Attributes.Add("class", "active");
                    break;
                case "Contact":
                    contact.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}