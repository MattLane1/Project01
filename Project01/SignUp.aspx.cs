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
 * @page: This page allows an unregistered user to sign up
 * @version: 0.8 - Put the editBox controls in place, still need to connect this to the database
 */

namespace Project01
{
    public partial class signUp : System.Web.UI.Page
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
        * This method is called when the Send button is clicked. It will send an email to myself with the contets of the message
        * </summary>
        * 
        * @method Page_Load
        * @param {object} sender
        * @param {GridViewPageEventArgs} e
        * @returns {void}
        */
        protected void SendButton_Click(object sender, EventArgs e)
        {
            // this is a placeholder for working code that checkls the database for the username, and signs them up
            Response.Redirect("Scores.aspx");
        }
    }
}