namespace PollSystem.Account
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using ErrorHandlerControl;
    using PollSystem.Models;

    public partial class InsertEditQuestion : Page
    {
        private int questionId;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.questionId = Convert.ToInt32(this.Request.Params["questionId"]);
        }

        protected void ButtonSaveQuestionText_Click(object sender, EventArgs e)
        {
            using (var context = new PollSystemEntities())
            {
                Question question = null;
                if (this.questionId == 0) // Creating a new question
                {
                    question = new Question();
                    context.Questions.Add(question);
                }
                else // Editing an existing question
                {
                    question = context.Questions.FirstOrDefault(q => q.QuestionId == this.questionId);
                    if (question == null)
                    {
                        ErrorSuccessNotifier.AddErrorMessage(
                            "An unexpected error occured! The question you want to edit was not found!");
                        return;
                    }
                }

                try
                {
                    question.QuestionText = this.TextBoxQuestionText.Text;
                    context.SaveChanges();

                    ErrorSuccessNotifier.AddSuccessMessage("Question successfully " +
                        (this.questionId == 0 ? "created!" : "edited!"));
                    ErrorSuccessNotifier.ShowAfterRedirect = true;

                    this.Response.Redirect("InsertEditQuestions.aspx", false);
                }
                catch (Exception exc)
                {
                    ErrorSuccessNotifier.AddErrorMessage(exc);
                    return;
                }
            }
        }

        protected void EditAnswer_Command(object sender, CommandEventArgs e)
        {
            this.Response.Redirect("InsertEditAnswer.aspx?answerId=" + e.CommandArgument);
        }

        protected void DeleteAnswer_Command(object sender, CommandEventArgs e)
        {
            using (var context = new PollSystemEntities())
            {
                var answerId = Convert.ToInt32(e.CommandArgument);
                var answer = context.Answers.FirstOrDefault(a => a.AnswerId == answerId);
                if (answer == null)
                {
                    ErrorSuccessNotifier.AddErrorMessage(
                            "An unexpected error occured! The answer you want to delete was not found!");
                    return;
                }

                try
                {
                    context.Answers.Remove(answer);
                    context.SaveChanges();

                    ErrorSuccessNotifier.AddSuccessMessage("Answer successfully deleted!");
                }
                catch (Exception exc)
                {
                    ErrorSuccessNotifier.AddErrorMessage(exc);
                }
            }
        }

        protected void LinkButtonCreateNewAnswer_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("InsertEditAnswer?questionId=" + this.questionId);
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (this.questionId != 0)
            {
                using (var context = new PollSystemEntities())
                {
                    var question = context.Questions.Include(q => q.Answers).FirstOrDefault(q => q.QuestionId == this.questionId);
                    if (question == null)
                    {
                        ErrorSuccessNotifier.AddErrorMessage(
                            "An unexpected error occured! The question you want to edit was not found!");
                        return;
                    }

                    this.TextBoxQuestionText.Text = question.QuestionText;

                    this.RepeaterAnswers.DataSource = question.Answers;
                    this.RepeaterAnswers.DataBind();

                    this.LinkButtonCreateNewAnswer.Visible = true;
                }
            }
        }
    }
}