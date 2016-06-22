//Using statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Using Statements required for EF DB access
using Project01.Models;
using System.Web.ModelBinding;

/**
 * @author: Matthew Lane
 * @date: June 18, 2016
 * @page: This page allows a user to add a new game to the database
 * @version: 2.0 - Can now add multiple games, 4 sets of games being tracked
 */

namespace Project01
{
    public partial class AddGame : System.Web.UI.Page
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
          * This method is called when the cancel button is pressed. It returns the user to the viewing page
          * </summary>
          * 
          * @method CancelButton_Click
          * @param {object} sender
          * @param {GridViewPageEventArgs} e
          * @returns {void}
         */
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            //Redirect back to Students page
            Response.Redirect("~/Default.aspx");
        }

        /**
         * <summary>
         * This method is called when the save button is pressed. It saves the provided game information to the database
         * </summary>
         * 
         * @method SaveButton_Click
         * @param {object} sender
         * @param {GridViewPageEventArgs} e
         * @returns {void}
        */
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            //The user has selected to add a Football game
            if (Sport.SelectedValue == "1")
            {
                // Use EF to connect to the server
                using (SportScores db = new SportScores())
                {
                    // use the Student model to create a new student object and save a new record
                    Football_Score newGame = new Football_Score();

                    int GameId = 0;

                    if (Request.QueryString.Count > 0) // our URL has this GameID in it (edit mode)
                    {
                        // get the id from the URL
                        GameId = Convert.ToInt32(Request.QueryString["GameId"]);

                        // get the current student from EF DB
                        newGame = (from GameScore in db.Football_Scores
                                   where GameScore.GameID == GameId
                                   select GameScore).FirstOrDefault();
                    }

                    // add form data to the new student record
                    newGame.GameWeek = Convert.ToInt32(GameWeekDropDownList.SelectedValue);
                    newGame.Spectators = Convert.ToInt32(SpectatorsTextBox.Text);

                    newGame.TeamNameOne = TeamOneNameTextBox.Text;
                    newGame.TeamNameTwo = TeamTwoNameTextBox.Text;

                    newGame.PointsScoredTeamOne = Convert.ToInt32(TeamOneScoreTextBox.Text);
                    newGame.PointsScoredTeamTwo = Convert.ToInt32(TeamTwoScoreTextBox.Text);

                    newGame.PointsAllowedTeamOne = Convert.ToInt32(TeamTwoScoreTextBox.Text);
                    newGame.PointsAllowedTeamTwo = Convert.ToInt32(TeamOneScoreTextBox.Text);

                    //Check which team had the higher score, and save it as the winner
                    if (newGame.PointsScoredTeamOne > newGame.PointsScoredTeamTwo)
                        newGame.TeamWon = newGame.TeamNameOne;
                    else
                        newGame.TeamWon = newGame.TeamNameTwo;

                    // use LINQ to ADO.NET to add / insert new student into the database
                    if (GameId == 0)
                    {
                        db.Football_Scores.Add(newGame);
                    }

                    // save our changes - also updates and inserts
                    db.SaveChanges();

                    // Redirect back to the updated students page
                    Response.Redirect("~/Default.aspx");
                }
            }

            //The user has selected to add a Soccer game
            if (Sport.SelectedValue == "2")
            {
                // Use EF to connect to the server
                using (SportScores db = new SportScores())
                {
                    // use the Student model to create a new student object and save a new record
                    Soccer_Score newGame = new Soccer_Score();

                    int GameId = 0;

                    if (Request.QueryString.Count > 0) // our URL has this GameID in it (edit mode)
                    {
                        // get the id from the URL
                        GameId = Convert.ToInt32(Request.QueryString["GameId"]);

                        // get the current student from EF DB
                        newGame = (from GameScore in db.Soccer_Scores
                                   where GameScore.GameID == GameId
                                   select GameScore).FirstOrDefault();
                    }

                    // add form data to the new student record
                    newGame.GameWeek = Convert.ToInt32(GameWeekDropDownList.SelectedValue);
                    newGame.Spectators = Convert.ToInt32(SpectatorsTextBox.Text);

                    newGame.TeamNameOne = TeamOneNameTextBox.Text;
                    newGame.TeamNameTwo = TeamTwoNameTextBox.Text;

                    newGame.PointsScoredTeamOne = Convert.ToInt32(TeamOneScoreTextBox.Text);
                    newGame.PointsScoredTeamTwo = Convert.ToInt32(TeamTwoScoreTextBox.Text);

                    newGame.PointsAllowedTeamOne = Convert.ToInt32(TeamTwoScoreTextBox.Text);
                    newGame.PointsAllowedTeamTwo = Convert.ToInt32(TeamOneScoreTextBox.Text);

                    //Check which team had the higher score, and save it as the winner
                    if (newGame.PointsScoredTeamOne > newGame.PointsScoredTeamTwo)
                        newGame.TeamWon = newGame.TeamNameOne;
                    else
                        newGame.TeamWon = newGame.TeamNameTwo;

                    // use LINQ to ADO.NET to add / insert new student into the database
                    if (GameId == 0)
                    {
                        db.Soccer_Scores.Add(newGame);
                    }

                    // save our changes - also updates and inserts
                    db.SaveChanges();

                    // Redirect back to the updated students page
                    Response.Redirect("~/Default.aspx");
                }
            }

            //The user has selected to add a Hockey game
            if (Sport.SelectedValue == "3")
            {
                // Use EF to connect to the server
                using (SportScores db = new SportScores())
                {
                    // use the Student model to create a new student object and save a new record
                    Hockey_Score newGame = new Hockey_Score();

                    int GameId = 0;

                    if (Request.QueryString.Count > 0) // our URL has this GameID in it (edit mode)
                    {
                        // get the id from the URL
                        GameId = Convert.ToInt32(Request.QueryString["GameId"]);

                        // get the current student from EF DB
                        newGame = (from GameScore in db.Hockey_Scores
                                   where GameScore.GameID == GameId
                                   select GameScore).FirstOrDefault();
                    }

                    // add form data to the new student record
                    newGame.GameWeek = Convert.ToInt32(GameWeekDropDownList.SelectedValue);
                    newGame.Spectators = Convert.ToInt32(SpectatorsTextBox.Text);

                    newGame.TeamNameOne = TeamOneNameTextBox.Text;
                    newGame.TeamNameTwo = TeamTwoNameTextBox.Text;

                    newGame.PointsScoredTeamOne = Convert.ToInt32(TeamOneScoreTextBox.Text);
                    newGame.PointsScoredTeamTwo = Convert.ToInt32(TeamTwoScoreTextBox.Text);

                    newGame.PointsAllowedTeamOne = Convert.ToInt32(TeamTwoScoreTextBox.Text);
                    newGame.PointsAllowedTeamTwo = Convert.ToInt32(TeamOneScoreTextBox.Text);

                    //Check which team had the higher score, and save it as the winner
                    if (newGame.PointsScoredTeamOne > newGame.PointsScoredTeamTwo)
                        newGame.TeamWon = newGame.TeamNameOne;
                    else
                        newGame.TeamWon = newGame.TeamNameTwo;

                    // use LINQ to ADO.NET to add / insert new student into the database
                    if (GameId == 0)
                    {
                        db.Hockey_Scores.Add(newGame);
                    }

                    // save our changes - also updates and inserts
                    db.SaveChanges();

                    // Redirect back to the updated students page
                    Response.Redirect("~/Default.aspx");
                }
            }

            //The user has selected to add a Lacrosse game
            if (Sport.SelectedValue == "4")
            {
                // Use EF to connect to the server
                using (SportScores db = new SportScores())
                {
                    // use the Student model to create a new student object and save a new record
                    lacrosse_Score newGame = new lacrosse_Score();

                    int GameId = 0;

                    if (Request.QueryString.Count > 0) // our URL has this GameID in it (edit mode)
                    {
                        // get the id from the URL
                        GameId = Convert.ToInt32(Request.QueryString["GameId"]);

                        // get the current student from EF DB
                        newGame = (from GameScore in db.lacrosse_Scores
                                   where GameScore.GameID == GameId
                                   select GameScore).FirstOrDefault();
                    }

                    // add form data to the new student record
                    newGame.GameWeek = Convert.ToInt32(GameWeekDropDownList.SelectedValue);
                    newGame.Spectators = Convert.ToInt32(SpectatorsTextBox.Text);

                    newGame.TeamNameOne = TeamOneNameTextBox.Text;
                    newGame.TeamNameTwo = TeamTwoNameTextBox.Text;

                    newGame.PointsScoredTeamOne = Convert.ToInt32(TeamOneScoreTextBox.Text);
                    newGame.PointsScoredTeamTwo = Convert.ToInt32(TeamTwoScoreTextBox.Text);

                    newGame.PointsAllowedTeamOne = Convert.ToInt32(TeamTwoScoreTextBox.Text);
                    newGame.PointsAllowedTeamTwo = Convert.ToInt32(TeamOneScoreTextBox.Text);

                    //Check which team had the higher score, and save it as the winner
                    if (newGame.PointsScoredTeamOne > newGame.PointsScoredTeamTwo)
                        newGame.TeamWon = newGame.TeamNameOne;
                    else
                        newGame.TeamWon = newGame.TeamNameTwo;

                    // use LINQ to ADO.NET to add / insert new student into the database
                    if (GameId == 0)
                    {
                        db.lacrosse_Scores.Add(newGame);
                    }

                    // save our changes - also updates and inserts
                    db.SaveChanges();

                    // Redirect back to the updated students page
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        /**
        * <summary>
        * This method is called when the user has changed the week they want displayted. We pick this number up later.
        * </summary>
        * 
        * @method Page_Load
        * @param {object} sender
        * @param {GridViewPageEventArgs} e
        * @returns {void}
        */
        protected void GameWeekDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /**
        * <summary>
        * This method is called when the user selects what sport they wish to add a score for. We pick this up later. 
        * </summary>
        * 
        * @method Page_Load
        * @param {object} sender
        * @param {GridViewPageEventArgs} e
        * @returns {void}
        */
        protected void Sport_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}