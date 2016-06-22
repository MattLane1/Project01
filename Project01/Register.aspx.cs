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
 * @page: This page allows the user to register an account with the site
 * @version 1.0 - Set up the form and connected it ot the DB
 */

namespace Project01
{
    public partial class Register : System.Web.UI.Page
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
        * This method is called when a user clicks the cancel button. It redirects them to the main page
        * </summary>
        * 
        * @method CancelButton_Click
        * @param {object} sender
        * @param {GridViewPageEventArgs} e
        * @returns {void}
        */
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        /**
        * <summary>
        * This method is called when a user clicks the register page. It checks their info and then registers the account if all is well
        * </summary>
        * 
        * @method CancelButton_Click
        * @param {object} sender
        * @param {GridViewPageEventArgs} e
        * @returns {void}
        */
        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            //create a new userStore and manager
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            //create a new user object
            var user = new IdentityUser()
            {
                UserName = UserNameTextBox.Text,
                PhoneNumber = PhoneNumberTextBox.Text,
                Email = EmailTextBox.Text
            };

            //Create a new user in the db and store the result
            IdentityResult result = userManager.Create(user, PasswordTextBox.Text);

            // Check if successfully registered
            if (result.Succeeded)
            {
                // Authenticate and log in the new user
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                //Sign in 
                authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);

                // Redirect to the MainMenu
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                // display error in the AlertFlash div
                StatusLabel.Text = result.Errors.FirstOrDefault();
                AlertFlash.Visible = true;
            }
        }
    }
}