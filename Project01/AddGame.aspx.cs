using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// Using Statements required for EF DB access
using Project01.Models;
using System.Web.ModelBinding;

namespace Project01
{
    public partial class AddGame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetGames();
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            //Redirect back to Students page
            Response.Redirect("Default.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            // Use EF to connect to the server
            using (FootballScoreModel db = new FootballScoreModel())
            {
                // use the Student model to create a new student object and
                // save a new record
                Football_Score newGame = new Football_Score();

                int GameId = 0;

                if (Request.QueryString.Count > 0) // our URL has a DepartmentID in it
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

                    //SportNameTextBox.Text = Convert.ToDateTime(updatedGameScore.GameDate);
                    SpectatorsTextBox.Text = updatedGameScore.Spectators.ToString();
                }
            }
        }

 

 
    }
}