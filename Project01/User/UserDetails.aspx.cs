//Using statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//required for EF DB Access
using Project01.Models;
using System.Web.ModelBinding;

//required for Identity and OWIN Security
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

/**
 * @author: Matthew Lane
 * @date: June 20th, 2016
 * @page: This page allows a user, or the admin, to edit a user account
 * @version 1.0 - Set up the page with all edit controls included and site security. 
 */

namespace Project01.User
{
    public partial class UserDetails : System.Web.UI.Page
    {
        /**
        * <summary>
        * This method is called when the page is displayed, if it is the first time, it gets the users info
        * If user info exists, then it populats the edit controls with it
        * </summary>
        * 
        * @method Page_Load
        * @param {object} sender
        * @param {GridViewPageEventArgs} e
        * @returns {void}
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Request.QueryString.Count > 0)
                {
                    PasswordPlaceHolder.Visible = false;
                    this.GetUser();
                }
                else
                {
                    //Store session info and authentication methods in the authentiationManager object
                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                  
                    //Connect to the DB and get the users info
                    using (UserConnection db = new UserConnection())
                    {
                        AspNetUser updatedUser = (from user in db.AspNetUsers
                                                  where user.UserName == authenticationManager.User.Identity.Name
                                                  select user).FirstOrDefault();

                        if (updatedUser != null)
                        {
                            UserNameTextBox.Text = updatedUser.UserName;
                            PhoneNumberTextBox.Text = updatedUser.PhoneNumber;
                            EmailTextBox.Text = updatedUser.Email;
                        }
                    }

                    PasswordPlaceHolder.Visible = false;
                }
            }
        }

        /**
        * <summary>
        * This method gets the information about the current, or selected, user
        * </summary>
        * 
        * @method GetUser
        * @returns {void}
        */
        protected void GetUser()
        {
            string UserID = Request.QueryString["Id"].ToString();

            //Connect to the Db
            using (UserConnection db = new UserConnection())
            {
                //Get the users info which has the same ID as the selected one
                AspNetUser updatedUser = (from user in db.AspNetUsers
                                          where user.Id == UserID
                                          select user).FirstOrDefault();

                if(updatedUser != null)
                {
                    UserNameTextBox.Text = updatedUser.UserName;
                    PhoneNumberTextBox.Text = updatedUser.PhoneNumber;
                    EmailTextBox.Text = updatedUser.Email;
                }
            }
        }

        /**
        * <summary>
        * This method is called when the cancel button is pressed, it redirects back to the main page
        * </summary>
        * 
        * @method CancelButton_Click
        * @param {object} sender
        * @param {GridViewPageEventArgs} e
        * @returns {void}
        */
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            //Reidrect to user page
            Response.Redirect("~/Default.aspx");
        }

        /**
        * <summary>
        * This method is called when the save button is pressed, it edits a user, or creates a new one
        * </summary>
        * 
        * @method SaveButton_Click
        * @param {object} sender
        * @param {GridViewPageEventArgs} e
        * @returns {void}
        */
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string UserID = "";
            
            //Store session info and authentication methods in the authentiationManager object
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            //Connect to the database 
                using (UserConnection db = new UserConnection())
                {
                    AspNetUser newUser = new AspNetUser();

                //If the user is the Admin account, then get the user via the edit button, since the Admin can edit anyone
                if (authenticationManager.User.Identity.GetUserName() == "Admin")
                    UserID = Request.QueryString["Id"].ToString();

                //If the user is not the Admin, then get the info from the currently logged in user, since the normal user can only edit themselves
                else
                    UserID = authenticationManager.User.Identity.GetUserId();

                    newUser = (from users in db.AspNetUsers
                               where users.Id == UserID
                               select users).FirstOrDefault();

                    newUser.UserName = UserNameTextBox.Text;
                    newUser.PhoneNumber = PhoneNumberTextBox.Text;
                    newUser.Email = EmailTextBox.Text;

                    db.SaveChanges();

                    //redirect to users list
                    if (newUser.UserName == "Admin")
                        Response.Redirect("~/User/Users.aspx");

                    else
                        Response.Redirect("~/Default.aspx");
                }

            //If creating a new user
            if (UserID == "")
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

                if(result.Succeeded)
                {
                    //redirect to users list
                    if (user.UserName == "Admin")
                        Response.Redirect("~/User/Users.aspx");

                    else
                        Response.Redirect("~/Default.aspx");
                }
                else
                {
                    StatusLabel.Text = result.Errors.FirstOrDefault();
                    AlertFlash.Visible = true;
                }
            }
        }
    }
}