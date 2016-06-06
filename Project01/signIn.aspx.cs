using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/**
 * @author: Matthew Lane
 * @date: June 6, 2016
 * @page: This is the sign in page, where users with accounts can sign in to add sport scores
 */

namespace Project01
{
    public partial class signIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendButton_Click(object sender, EventArgs e)
        {
            // this is a placeholder for working code that checks database for the username and signs them in
            Response.Redirect("Scores.aspx");
        }
    }
}