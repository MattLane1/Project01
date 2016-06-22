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
 * @date: June 21, 2016
 * @page: This page allows the user to sign in so they can edit or add games
 * @version 1.0 - Set up the form with connected buttons
 */

namespace Project01
{
    public partial class Login : System.Web.UI.Page
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

        }

        /**
        * <summary>
        * This method is called when a user clicks "Login", it checks that their info is valid
        * </summary>
        * 
        * @method LoginButton_Click
        * @param {object} sender
        * @param {GridViewPageEventArgs} e
        * @returns {void}
        */
        protected void LoginButton_Click(object sender, EventArgs e)
        {
            //create a new userStore and manager
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            //search for and create a new user object
            var user = userManager.Find(UserNameTextBox.Text, PasswordTextBox.Text);

            // if a matching user is found
            if(user != null)
            {
                // Authenticate and log in the new user
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                //Sign in the user 
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);

                //Redirect to main page
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                //Throw error to alert flash
                StatusLabel.Text = "Invalid Username or Password";
                AlertFlash.Visible = true;
            }

        }
    }
}