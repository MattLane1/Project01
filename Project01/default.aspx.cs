﻿
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

//required for Identity and OWIN Security
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

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
                this.GetGames();
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
            using (Football_Model db = new Football_Model())
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
        protected void GetGames()
        {

            // connect to EF
            using (Football_Model db = new Football_Model())
            {

                int gameWeek = Convert.ToInt32(GameWeekDropDownList.SelectedValue);

                   // query the Students Table using EF and LINQ
                var GameNum = (from allGames in db.Football_Scores
                                    select allGames.GameID);

                    // query the Students Table using EF and LINQ
                    var Games = (from allGames in db.Football_Scores
                                 where allGames.GameWeek == gameWeek
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

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;

            if (authenticationManager.User.Identity.Name == "")
            {
                Response.Redirect("~/Login.aspx");
            }
            else
            {
                // store which row was clicked
                int selectedRow = e.RowIndex;

                // get the selected StudentID using the Grid's DataKey collection
                int GameID = Convert.ToInt32(GamesGridView.DataKeys[selectedRow].Values["GameID"]);

                // use EF to find the selected student in the DB and remove it
                using (Football_Model db = new Football_Model())
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
            this.GetGames();
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
            this.GetGames();

            // toggle the direction
            Session["SortDirection"] = Session["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }


        /**
        * <summary>
        * This event handler allows speficying which week to display games from
        * </summary>
        * 
        * @method GameWeekDropDownList_SelectedIndexChanged
        * @param {object} sender
        * @param {GridViewPageEventArgs} e
        * @returns {void}
        */
        protected void GameWeekDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetGames();
        }
    }
}

    
