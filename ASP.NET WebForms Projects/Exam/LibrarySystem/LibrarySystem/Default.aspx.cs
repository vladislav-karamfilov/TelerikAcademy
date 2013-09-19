namespace LibrarySystem
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using ErrorHandlerControl;
    using LibrarySystem.Models;

    public partial class _Default : Page
    {
        private const int MaxSearchQueryStringLength = 100;

        protected void Page_PreRender(object sender, EventArgs e)
        {
            var context = new LibrarySystemEntities();
            var categories = context.Categories.Include(c => c.Books).OrderBy(c => c.CategoryId);
            this.ListViewCategories.DataSource = categories.ToList();
            this.ListViewCategories.DataBind();
        }

        protected void BookDetails_Command(object sender, CommandEventArgs e)
        {
            try
            {
                int bookId = Convert.ToInt32(e.CommandArgument);
                this.Response.Redirect("BookDetails.aspx?bookId=" + bookId, false);
            }
            catch (Exception exc)
            {
                ErrorSuccessNotifier.AddErrorMessage(exc);
            }
        }

        protected void LinkButtonSearch_Click(object sender, EventArgs e)
        {
            var searchQuery = this.TextBoxSearch.Text.Trim();
            if (searchQuery.Length > MaxSearchQueryStringLength)
            {
                ErrorSuccessNotifier.AddErrorMessage(
                    "Too long search term! The maximal allowed length is " + MaxSearchQueryStringLength + "!");
            }
            else
            {
                this.Response.Redirect("Search?q=" + searchQuery, false);
            }
        }
    }
}