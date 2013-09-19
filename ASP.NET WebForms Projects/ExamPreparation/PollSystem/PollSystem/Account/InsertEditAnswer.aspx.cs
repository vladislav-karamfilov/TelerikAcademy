namespace PollSystem.Account
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using ErrorHandlerControl;
    using PollSystem.Models;

    public partial class InsertEditAnswer : Page
    {
        private int questionId;
        private int answerId;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.questionId = Convert.ToInt32(this.Request.Params["questionId"]);
            this.answerId = Convert.ToInt32(this.Request.Params["answerId"]);
        }

        protected void ButtonSaveAnswer_Click(object sender, EventArgs e)
        {
            using (var context = new PollSystemEntities())
            {
                Answer answer = null;
                if (questionId == 0) // Editing an existing answer
                {
                    answer = context.Answers.FirstOrDefault(a => a.AnswerId == this.answerId);
                    if (answer == null)
                    {
                        ErrorSuccessNotifier.AddErrorMessage(
                            "An unexpected error occured! The answer you want to edit was not found!");
                        return;
                    }
                }
                else // Creating a new answer
                {
                    answer = new Answer();
                    var question = context.Questions.FirstOrDefault(q => q.QuestionId == this.questionId);
                    if (question == null)
                    {
                        ErrorSuccessNotifier.AddErrorMessage(
                            "An unexpected error occured! The question for the answer you want to create was not found!");
                        return;
                    }

                    question.Answers.Add(answer);
                }

                answer.AnswerText = this.TextBoxAnswerText.Text;
                var answerVotesString = this.TextBoxAnswerVotes.Text == string.Empty ? "0" : this.TextBoxAnswerVotes.Text;
                answer.Votes = int.Parse(answerVotesString);
                if (answer.Votes < 0)
                {
                    ErrorSuccessNotifier.AddErrorMessage("Invalid votes count! Answer votes cannot be less than 0!");
                    return;
                }

                try
                {
                    context.SaveChanges();

                    ErrorSuccessNotifier.AddSuccessMessage("Answer successfully " +
                        (this.questionId == 0 ? "edited!" : "created!"));
                    ErrorSuccessNotifier.ShowAfterRedirect = true;

                    this.Response.Redirect("InsertEditQuestion.aspx?questionId=" + answer.QuestionId, false);
                }
                catch (Exception exc)
                {
                    ErrorSuccessNotifier.AddErrorMessage(exc);
                }
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (this.answerId != 0)
            {
                using (var context = new PollSystemEntities())
                {
                    var answer = context.Answers.FirstOrDefault(a => a.AnswerId == answerId);
                    if (answer == null)
                    {
                        ErrorSuccessNotifier.AddErrorMessage(
                            "An unexpected error occured! The answer you want to edit was not found!");
                        return;
                    }

                    this.TextBoxAnswerText.Text = answer.AnswerText;
                    this.TextBoxAnswerVotes.Text = answer.Votes.ToString();
                }
            }
        }
    }
}