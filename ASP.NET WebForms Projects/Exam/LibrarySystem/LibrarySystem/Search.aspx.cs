namespace LibrarySystem
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using ErrorHandlerControl;
    using LibrarySystem.Models;

    public partial class Search : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new LibrarySystemEntities();
            try
            {
                var query = this.Request.Params["q"].ToString().Trim();
                var queryResults = context.Books.Include(b => b.Category)
                    .Where(b => b.Title.Contains(query) || b.Authors.Contains(query))
                    .OrderBy(b => b.Title).ThenBy(b => b.Authors);

                this.RepeaterQueryResults.DataSource = queryResults.ToList();
                this.RepeaterQueryResults.DataBind();

                this.LiteralQuery.Text = this.Server.HtmlEncode(query);
                this.HyperLinkBackToBooks.NavigateUrl = "Default.aspx";
            }
            catch (Exception exc)
            {
                ErrorSuccessNotifier.AddErrorMessage(exc);
            }
        }

        protected void ShowBookDetails_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var bookId = Convert.ToInt32(e.CommandArgument);
                this.Response.Redirect("BookDetails.aspx?bookId=" + bookId);
            }
            catch (Exception exc)
            {
                ErrorSuccessNotifier.AddErrorMessage(exc);
            }
        }
    }
}