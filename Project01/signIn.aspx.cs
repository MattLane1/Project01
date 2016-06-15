//Using commands
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/**
 * @author: Matthew Lane
 * @date: June 8, 2016
 * @page: This page allows a registered user to sign in
 * @version: 0.8 - Put the editBox controls in place, still need to connect this to the database
 */

namespace Project01
{
    public partial class signIn : System.Web.UI.Page
    {
        /**
        * <summary>
        * This method is called when the page is displayed, if it is the first time it populates the grids
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
        * This method is called when the Send button is clicked. It will check the database for the users name, and if it does not exisit, it will be added along with the password. 
        * </summary>
        * 
        * @method Page_Load
        * @param {object} sender
        * @param {GridViewPageEventArgs} e
        * @returns {void}
        */
        protected void SendButton_Click(object sender, EventArgs e)
        {
            // this is a placeholder for working code that checks database for the username and signs them in
            Response.Redirect("Scores.aspx");
        }
    }
}