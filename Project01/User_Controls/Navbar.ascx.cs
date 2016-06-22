//Using Statements
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
 * @page: This page allows the user to navigate through the website
 * @version: 1.0 - Updated all the links to represent the new pages
 */

namespace Project01
{
    public partial class Navbar : System.Web.UI.UserControl
    {
        /**
        * <summary>
        * This method is called when the page is displayed
        * </summary>
        * 
        * @method Page_Load
        * @param {object} sender
        * @param {GridViewPageEventArgs} e
        * @returns {void}
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Check if the Admin is logged in, if so they get access to the users page
                if (HttpContext.Current.User.Identity.Name.ToString() == "Admin")
                {
                    AdminPlaceHolder.Visible = true;
                    PrivatePlaceHolder.Visible = true;
                    PublicPlaceHolder.Visible = false;
                }
                
                //Check if a user is logged in
                else if (HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    //Show the private content
                    PrivatePlaceHolder.Visible = true;
                    PublicPlaceHolder.Visible = false;
                    AdminPlaceHolder.Visible = false;
                }

                //Default, noone is logged in
                else
                {
                    //Show the public content
                    PrivatePlaceHolder.Visible = false;
                    PublicPlaceHolder.Visible = true;
                    AdminPlaceHolder.Visible = false;
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
            //Change which page is highlighted based on which page the user is on
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
                case "User Details":
                    EditUserDetails.Attributes.Add("class", "active");
                    break;
                case "Users":
                    UserAccounts.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}