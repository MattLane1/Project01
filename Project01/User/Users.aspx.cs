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

/**
 * @author: Matthew Lane
 * @date: June 20, 2016
 * @page: This page containsa  gridview of all the registered users, only the Admin can access it
 * @version 1.0 - Set up this form with all the edit boxes connected to the DB and being populated by it
 */

namespace Project01.Admin
{
    public partial class Users : System.Web.UI.Page
    {
        /**
        * <summary>
        * This method is called when the page is displayed, if it is the first time, it gets the user list
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
                this.GetUsers();
        }

        /**
        * <summary>
        * This method gets the list of users from the db and populates the gridview with them
        * </summary>
        * 
        * @method GetUsers
        * @returns {void}
        */
        protected void GetUsers()
        {
            //Connect to the DB
            using (UserConnection db = new UserConnection())
            {
                var Users = (from users in db.AspNetUsers
                             select users);

                UsersGridView.DataSource = Users.ToList();
                UsersGridView.DataBind();
            }
        }

        /**
        * <summary>
        * This method is called when the delete button is pressed on a user account
        * it removes the user from the db
        * </summary>
        * 
        * @method UsersGridView_RowDeleting
        * @param {object} sender
        * @param {GridViewPageEventArgs} e
        * @returns {void}
        */
        protected void UsersGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int selectedRow = e.RowIndex;

            //Get the info on who is ebing deleted
            string UserID = UsersGridView.DataKeys[selectedRow].Values["Id"].ToString();

            //Connect to the DB
            using (UserConnection db = new UserConnection())
            {
                AspNetUser deletedUser = (from users in db.AspNetUsers
                                            where users.Id == UserID
                                            select users).FirstOrDefault();

                db.AspNetUsers.Remove(deletedUser);
                db.SaveChanges();
            }

            //Refresh the grid
            this.GetUsers();
        }
    }
}