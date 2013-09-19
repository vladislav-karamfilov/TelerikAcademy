namespace PollSystem.Account
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.UI;
    using ErrorHandlerControl;
    using PollSystem.Models;

    public partial class InsertEditQuestions : Page
    {
        public IQueryable<Question> GridViewQuestions_GetData()
        {
            var context = new PollSystemEntities();
            return context.Questions.OrderBy(q => q.QuestionId);
        }

        public void GridViewQuestions_DeleteItem(int questionId)
        {
            using (var context = new PollSystemEntities())
            {
                var question = context.Questions.Include(q => q.Answers).FirstOrDefault(q => q.QuestionId == questionId);
                if (question == null)
                {
                    ErrorSuccessNotifier.AddErrorMessage(
                            "An unexpected error occured! The question you want to delete was not found!");
                    return;
                }

                try
                {
                    context.Answers.RemoveRange(question.Answers);
                    context.Questions.Remove(question);
                    context.SaveChanges();

                    ErrorSuccessNotifier.AddSuccessMessage("Question successfully deleted!");
                }
                catch (Exception exc)
                {
                    ErrorSuccessNotifier.AddErrorMessage(exc);
                }

                this.GridViewQuestions.PageIndex = 0;
            }
        }

        protected void LinkButtonCreateNewQuestion_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("InsertEditQuestion.aspx");
        }
    }
}