namespace LibrarySystem
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using ErrorHandlerControl;
    using LibrarySystem.Models;

    public partial class BookDetails : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var context = new LibrarySystemEntities();
            try
            {
                var bookId = Convert.ToInt32(this.Request.Params["bookId"]);
                var book = context.Books.FirstOrDefault(b => b.BookId == bookId);
                if (book == null)
                {
                    ErrorSuccessNotifier.AddErrorMessage(
                        "An unexpected error occurred! The book you want to view was not found...");
                }
                else
                {
                    this.LiteralBookTitle.Text = this.Server.HtmlEncode(book.Title);
                    this.LiteralBookAuthors.Text = this.Server.HtmlEncode(string.Format("by {0}", book.Authors));
                    this.LiteralBookIsbn.Text = this.Server.HtmlEncode(string.Format("ISBN {0}", book.ISBN));
                    this.HyperLinkWebSite.Text = this.Server.HtmlEncode(book.WebSite);
                    this.HyperLinkWebSite.NavigateUrl = this.Server.HtmlEncode(book.WebSite);
                    this.LiteralBookDescription.Text = this.Server.HtmlEncode(book.Description);
                    this.HyperLinkBackToBooks.NavigateUrl = "Default.aspx";
                }
            }
            catch (Exception exc)
            {
                ErrorSuccessNotifier.AddErrorMessage(exc);
            }
        }
    }
}