namespace PollSystem
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using ErrorHandlerControl;
    using PollSystem.Models;

    public partial class _Default : Page
    {
        protected void Page_PreRender(object sender, EventArgs e)
        {
            using (var context = new PollSystemEntities())
            {
                var randomQuestions = context.Questions.Include(q => q.Answers).OrderBy(q => Guid.NewGuid()).Take(3);
                this.ListViewPolls.DataSource = randomQuestions.ToList();
                this.ListViewPolls.DataBind();
            }
        }

        protected void Vote_Command(object sender, CommandEventArgs e)
        {
            using (var context = new PollSystemEntities())
            {
                var answerId = Convert.ToInt32(e.CommandArgument);
                var answer = context.Answers.FirstOrDefault(a => a.AnswerId == answerId);
                if (answer == null)
                {
                    ErrorSuccessNotifier.AddErrorMessage(
                        "An unexpected error occured! The question or the answer you have voted for was not found!");
                }
                else
                {
                    answer.Votes++;
                    context.SaveChanges();

                    ErrorSuccessNotifier.AddSuccessMessage("You have voted successfully!");
                    ErrorSuccessNotifier.ShowAfterRedirect = true;

                    this.Response.Redirect("VotingResults.aspx?questionId=" + answer.QuestionId);
                }
            }
        }
    }
}