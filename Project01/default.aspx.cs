
// Using statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Using statements that are required to connect to EF database, and for the models
using Project01.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

/**
 * @author: Matthew Lane
 * @date: June 14, 2016
 * @page: This page holds the grids of the currently reported scores
 * @version: 1.8 - Completed Grids and connection to Db. Still need to allow for viewing one week at a time. 
 */

namespace Project01
{
    public partial class Default : System.Web.UI.Page
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
            // if loading the page for the first time, populate the student grid
            if (!IsPostBack)
            {
                // Get the game data
                this.GetGames(1);
            }
        }

    /**
    * <summary>
    * This method will get the date associated with the game for displaying week to week
    * </summary>
    * 
    * @method GetDates
    * @returns {void}
    */
        protected void GetDates()
        {
            using (FootballScoreModel db = new FootballScoreModel())
            {
                // query the Students Table using EF and LINQ
                var Games = (from allGames in db.Football_Scores where allGames.GameID == 1 select allGames);
            }
        }

        /**
         * <summary>
         * This method gets the list of games from the DB based on the selected week
         * </summary>
         * 
         * @method GetGames
         * @returns {void}
         * @param int Week
         */
        protected void GetGames(int Week)
        {
           // if (Week == 1)

            // connect to EF
            using (FootballScoreModel db = new FootballScoreModel())
            {

                   // query the Students Table using EF and LINQ
                   var GameNum = (from allGames in db.Football_Scores
                                    select allGames.GameID);

                    // query the Students Table using EF and LINQ
                    var Games = (from allGames in db.Football_Scores
                            // where allGames.GameID == 1
                             select allGames);

                // bind the result to the GridView
                GamesGridView.DataSource = Games.ToList();
                GamesGridView.DataBind();
            }

           // GetDates();
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
                this.GetGames(1);
            }
        }

        /**
         * <summary>
         * This event handler allows pagination to occur for the Students page
         * </summary>
         * 
         * @method GamesGridView_PageIndexChanging
         * @param {object} sender
         * @param {GridViewPageEventArgs} e
         * @returns {void}
         */
        protected void GamesGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the new page number
            GamesGridView.PageIndex = e.NewPageIndex;

            // refresh the grid
            this.GetGames(1);
        }

        /**
        * <summary>
        * This event handler allows for the number of games being displayed on one page to be changed
        * </summary>
        * 
        * @method PageSizeDropDownList_SelectedIndexChanged
        * @param {object} sender
        * @param {GridViewPageEventArgs} e
        * @returns {void}
        */
        protected void PageSizeDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the new Page size
            GamesGridView.PageSize = Convert.ToInt32(PageSizeDropDownList.SelectedValue);

            // refresh the grid
            this.GetGames(Convert.ToInt32(PageSizeDropDownList.SelectedValue));
        }

        /**
      * <summary>
      * This event handler allows for the list of games to be sorted by various columns
      * </summary>
      * 
      * @method GamesGridView_Sorting
      * @param {object} sender
      * @param {GridViewPageEventArgs} e
      * @returns {void}
      */
        protected void GamesGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            // get the column to sorty by
            Session["SortColumn"] = e.SortExpression;

            // Refresh the Grid
            this.GetGames(1);

            // toggle the direction
            Session["SortDirection"] = Session["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }
    }
}

    
