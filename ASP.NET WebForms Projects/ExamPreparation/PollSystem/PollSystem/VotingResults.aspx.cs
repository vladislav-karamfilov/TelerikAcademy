namespace PollSystem
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.UI;
    using ErrorHandlerControl;
    using PollSystem.Models;

    public partial class VotingResults : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var questionId = Convert.ToInt32(this.Request.Params["questionId"]);
            var question = this.GetQuestion(questionId);
            if (question != null)
            {
                this.LabelQuestionText.Text = question.QuestionText;

                this.ChartQuestionVotingResults.DataSource = question.Answers;
                this.ChartQuestionVotingResults.ChartAreas["ChartAreaVotes"].AxisX.Title = "Answer";
                this.ChartQuestionVotingResults.ChartAreas["ChartAreaVotes"].AxisY.Title = "Votes";
                this.ChartQuestionVotingResults.Series["SeriesVotes"].XValueMember = "AnswerText";
                this.ChartQuestionVotingResults.Series["SeriesVotes"].YValueMembers = "Votes";
                this.ChartQuestionVotingResults.DataBind();
            }
            else
            {
                ErrorSuccessNotifier.AddErrorMessage(
                        "An unexpected error occured! The question you have voted for was not found!");
            }
        }

        protected void GoBack_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("/", true);
        }

        private Question GetQuestion(int questionId)
        {
            var context = new PollSystemEntities();
            var question = context.Questions.Include(q => q.Answers)
                .FirstOrDefault(q => q.QuestionId == questionId);
            return question;
        }
    }
}