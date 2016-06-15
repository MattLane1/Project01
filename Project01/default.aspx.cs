using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Using statements that are required to connect top EF database
using Project01.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

/**
 * @author: Matthew Lane
 * @date: June 6, 2016
 * @page: This page holds a grid of the currently reported scores
 */

namespace Project01
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if loading the page for the first time, populate the student grid
            if (!IsPostBack)
            {
                // Get the game data
                this.GetGames();
            }
        }

        /**
         * <summary>
         * This method gets the student data from the DB
         * </summary>
         * 
         * @method GetStudents
         * @returns {void}
         */
        protected void GetGames()
        {
            // connect to EF
            using (FootballScoreModel db = new FootballScoreModel())
            {
                // query the Students Table using EF and LINQ
                var Games = (from allGames in db.Football_Scores
                                select allGames);

                // bind the result to the GridView
                GamesGridView.DataSource = Games.ToList();
                GamesGridView.DataBind();
            }
        }

        /**
         * <summary>
         * This event handler deletes a student from the db using EF
         * </summary>
         * 
         * @method StudentsGridView_RowDeleting
         * @param {object} sender
         * @param {GridViewDeleteEventArgs} e
         * @returns {void}
         */
         
        protected void GamesGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // store which row was clicked
            int selectedRow = e.RowIndex;

            // get the selected StudentID using the Grid's DataKey collection
            int GameID = Convert.ToInt32(GamesGridView.DataKeys[selectedRow].Values["GameID"]);

            // use EF to find the selected student in the DB and remove it
            using (FootballScoreModel db = new FootballScoreModel())
            {
                // create object of the Student class and store the query string inside of it
                Football_Score deletedGame = (from savedGames in db.Football_Scores
                                              where savedGames.GameID == GameID
                                          select savedGames).FirstOrDefault();

                // remove the selected student from the db
                db.Football_Scores.Remove(deletedGame);

                // save my changes back to the database
                db.SaveChanges();

                // refresh the grid
                this.GetGames();
            }
        }
        
        /**
         * <summary>
         * This event handler allows pagination to occur for the Students page
         * </summary>
         * 
         * @method StudentsGridView_PageIndexChanging
         * @param {object} sender
         * @param {GridViewPageEventArgs} e
         * @returns {void}
         */

        protected void GamesGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the new page number
            GamesGridView.PageIndex = e.NewPageIndex;

            // refresh the grid
            this.GetGames();
        }

        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the new Page size
           /// GamesGridView.PageSize = Convert.ToInt32(PageSizeDropDownList.SelectedValue);

            // refresh the grid
            this.GetGames();
        }

        protected void GamesGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            // get the column to sorty by
            Session["SortColumn"] = e.SortExpression;

            // Refresh the Grid
            this.GetGames();

            // toggle the direction
            Session["SortDirection"] = Session["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
    }
}

    
