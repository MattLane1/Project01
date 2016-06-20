//Using statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/**
 * @author: Matthew Lane
 * @date: June 6, 2016
 * @page: This page allows the user to send a message to me
 * @version 1.0 - Set up the form with connected buttons
 */

namespace Project01
{
    public partial class Contact : System.Web.UI.Page
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
        * This method is called when the Send button is pressed
        * </summary>
        * 
        * @method SendButton_Click
        * @param {object} sender
        * @param {GridViewPageEventArgs} e
        * @returns {void}
        */
        protected void SendButton_Click(object sender, EventArgs e)
        {
            // this is a placeholder for working code that sends email 
            Response.Redirect("~/Default.aspx");
        }
    }
}