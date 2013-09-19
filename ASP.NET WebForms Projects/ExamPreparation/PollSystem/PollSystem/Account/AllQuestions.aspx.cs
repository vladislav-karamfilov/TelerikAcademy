namespace PollSystem.Account
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.UI;
    using PollSystem.Models;

    public partial class ViewAllResults : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.RepeaterAnswers.DataSource = null;
            this.RepeaterAnswers.DataBind();
        }

        public IQueryable<Question> GridViewQuestions_GetData()
        {
            var context = new PollSystemEntities();
            return context.Questions.OrderBy(q => q.QuestionId);
        }

        protected void GridViewQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var context = new PollSystemEntities())
            {
                var questionId = Convert.ToInt32(this.GridViewQuestions.SelectedDataKey.Value);
                var answers = context.Answers.Where(a => a.QuestionId == questionId).ToList();
                this.RepeaterAnswers.DataSource = answers;
                this.RepeaterAnswers.DataBind();
            }
        }
    }
}