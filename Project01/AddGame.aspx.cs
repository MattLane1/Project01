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
 * @date: June 14, 2016
 * @page: This page allows a user to add a new game to the database
 * @version: 1.0 - Connected page to database, it is populating correctly. 
 */

namespace Project01
{
    public partial class AddGame : System.Web.UI.Page
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
            //Check to see if this is the first time the page has been loaded, if so, populate the grid
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetGames();
            }
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
            Response.Redirect("Default.aspx");
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
            // Use EF to connect to the server
            using (FootballScoreModel db = new FootballScoreModel())
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
                newGame.GameDate = Convert.ToDateTime(GameDateTextBox.Text);
                newGame.Spectators = Convert.ToInt32(SpectatorsTextBox.Text);

                newGame.TeamNameOne = TeamOneNameTextBox.Text;
                newGame.TeamNameTwo = TeamTwoNameTextBox.Text;

                newGame.PointsScoredTeamOne = Convert.ToInt32(TeamOneScoreTextBox.Text);
                newGame.PointsScoredTeamTwo = Convert.ToInt32(TeamTwoScoreTextBox.Text);

                newGame.PointsAllowedTeamOne = Convert.ToInt32(TeamTwoScoreTextBox.Text);
                newGame.PointsAllowedTeamTwo = Convert.ToInt32(TeamOneScoreTextBox.Text);

                // use LINQ to ADO.NET to add / insert new student into the database
                if (GameId == 0)
                {
                    db.Football_Scores.Add(newGame);
                }

                // save our changes - also updates and inserts
                db.SaveChanges();

                // Redirect back to the updated students page
                Response.Redirect("Default.aspx");
            }
        }

        /**
         * <summary>
         * This method gets the information about the games from the database, and checks to see if the game already exists
         * </summary>
         * 
         * @method GetGames
         * @returns {void}
        */
        protected void GetGames()
        {
            // populate the form with existing data from the database
            int GameId = Convert.ToInt32(Request.QueryString["GameId"]);

            // connect to the EF DB
            using (FootballScoreModel db = new FootballScoreModel())
            {
                // populate a student object instance with the StudentID from the URL Parameter
                Football_Score updatedGameScore = (from GameScore in db.Football_Scores
                                                where GameScore.GameID == GameId
                                                select GameScore).FirstOrDefault();

                // map the student properties to the form controls
                if (updatedGameScore != null)
                {
                    TeamOneNameTextBox.Text = updatedGameScore.TeamNameOne;
                    TeamTwoNameTextBox.Text = updatedGameScore.TeamNameTwo;

                    TeamOneScoreTextBox.Text = updatedGameScore.PointsScoredTeamOne.ToString();
                    TeamTwoScoreTextBox.Text = updatedGameScore.PointsScoredTeamTwo.ToString();

                    SpectatorsTextBox.Text = updatedGameScore.Spectators.ToString();
                }
            }
        }
    }
}