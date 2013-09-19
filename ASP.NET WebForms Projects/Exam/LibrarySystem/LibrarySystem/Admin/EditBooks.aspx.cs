namespace LibrarySystem.Account
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using ErrorHandlerControl;
    using LibrarySystem.Models;
    using LibrarySystem.ViewModels;
    using System.Text.RegularExpressions;

    public partial class EditBooks : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PanelCreateEdit.Visible = false;
            this.PanelDelete.Visible = false;

            this.LinkButtonCreateNewBook.Visible = true;
        }

        public IQueryable<BookViewModel> GridViewBooks_GetData()
        {
            var context = new LibrarySystemEntities();
            var books = context.Books.Include(b => b.Category).OrderBy(b => b.BookId).Select(b =>
                new BookViewModel()
                {
                    BookId = b.BookId,
                    Title = b.Title,
                    Authors = b.Authors,
                    Description = b.Description,
                    ISBN = b.ISBN,
                    WebSite = b.WebSite,
                    Category = b.Category.Name
                });
            return books;
        }

        public IQueryable<string> DropDownListBookCategories_GetData()
        {
            var context = new LibrarySystemEntities();
            var categories = context.Categories.OrderBy(c => c.CategoryId).Select(c => c.Name);
            return categories;
        }

        protected void LinkButtonCreateNewBook_Click(object sender, EventArgs e)
        {
            this.LinkButtonCreateNewBook.Visible = false;
            this.LinkButtonEditSave.Visible = false;
            this.LinkButtonCreateConfirm.Visible = true;
            this.PanelCreateEdit.Visible = true;
        }

        protected void EditBook_Command(object sender, CommandEventArgs e)
        {
            this.PanelCreateEdit.Visible = true;
            this.LinkButtonEditSave.Visible = true;
            this.LinkButtonCreateConfirm.Visible = false;
            this.LinkButtonCreateNewBook.Visible = false;
            this.LiteralBookToEditId.Text = e.CommandArgument.ToString();

            var bookId = Convert.ToInt32(e.CommandArgument);
            var context = new LibrarySystemEntities();
            var book = context.Books.Include(b => b.Category).FirstOrDefault(b => b.BookId == bookId);
            if (book == null)
            {
                ErrorSuccessNotifier.AddErrorMessage(
                    "An unexpected error occurred! The book you want to edit was not found...");
            }
            else
            {
                this.TextBoxCreateEditBookTitle.Text = book.Title;
                this.TextBoxCreateEditBookAuthors.Text = book.Authors;
                this.TextBoxCreateEditBookDescription.Text = book.Description;
                this.TextBoxCreateEditBookIsbn.Text = book.ISBN;
                this.TextBoxCreateEditBookWebSite.Text = book.WebSite;
                this.DropDownListBookCategories.SelectedValue = book.Category.Name;
                this.LinkButtonCreateConfirm.Visible = false;
            }
        }

        protected void DeleteBook_Command(object sender, CommandEventArgs e)
        {
            this.PanelDelete.Visible = true;
            this.LinkButtonCreateNewBook.Visible = false;
            this.LiteralBookToDeleteId.Text = e.CommandArgument.ToString();

            var bookId = Convert.ToInt32(e.CommandArgument);
            var context = new LibrarySystemEntities();
            var book = context.Books.FirstOrDefault(b => b.BookId == bookId);
            if (book == null)
            {
                ErrorSuccessNotifier.AddErrorMessage(
                    "An unexpected error occurred! The book you want to delete was not found...");
            }
            else
            {
                this.TextBoxDeleteBookTitle.Text = book.Title;
            }
        }

        protected void LinkButtonCreateConfirm_Click(object sender, EventArgs e)
        {
            var context = new LibrarySystemEntities();
            var newBook = new Book();
            newBook = this.LoadBookData(newBook, context);
            if (newBook == null)
            {
                return;
            }

            try
            {
                context.Books.Add(newBook);
                context.SaveChanges();
                this.GridViewBooks.DataBind();
                this.TextBoxCreateEditBookAuthors.Text = string.Empty;
                this.TextBoxCreateEditBookDescription.Text = string.Empty;
                this.TextBoxCreateEditBookIsbn.Text = string.Empty;
                this.TextBoxCreateEditBookTitle.Text = string.Empty;
                this.TextBoxCreateEditBookWebSite.Text = string.Empty;
                ErrorSuccessNotifier.AddSuccessMessage("Book successfully created!");
            }
            catch (Exception exc)
            {
                ErrorSuccessNotifier.AddErrorMessage(exc);
            }
        }

        protected void LinkButtonEditSave_Click(object sender, EventArgs e)
        {
            var bookToEditId = Convert.ToInt32(this.LiteralBookToEditId.Text);
            var context = new LibrarySystemEntities();
            var bookToEdit = context.Books.FirstOrDefault(b => b.BookId == bookToEditId);
            if (bookToEdit == null)
            {
                ErrorSuccessNotifier.AddErrorMessage(
                    "An unexpected error occurred! The book you want to edit was not found...");
                return;
            }

            bookToEdit = this.LoadBookData(bookToEdit, context);
            if (bookToEdit == null)
            {
                return;
            }

            try
            {
                context.SaveChanges();
                this.GridViewBooks.DataBind();
                this.TextBoxCreateEditBookAuthors.Text = string.Empty;
                this.TextBoxCreateEditBookDescription.Text = string.Empty;
                this.TextBoxCreateEditBookIsbn.Text = string.Empty;
                this.TextBoxCreateEditBookTitle.Text = string.Empty;
                this.TextBoxCreateEditBookWebSite.Text = string.Empty;
                ErrorSuccessNotifier.AddSuccessMessage("Book successfully edited!");
            }
            catch (Exception exc)
            {
                ErrorSuccessNotifier.AddErrorMessage(exc);
            }
        }

        protected void LinkButtonCreateEditCancel_Click(object sender, EventArgs e)
        {
            this.PanelCreateEdit.Visible = false;
        }

        protected void LinkButtonDeleteConfirm_Click(object sender, EventArgs e)
        {
            var bookToDeleteId = Convert.ToInt32(this.LiteralBookToDeleteId.Text);
            var context = new LibrarySystemEntities();

            var bookToDelete = context.Books.FirstOrDefault(b => b.BookId == bookToDeleteId);
            if (bookToDelete == null)
            {
                ErrorSuccessNotifier.AddErrorMessage(
                    "An unexpected error occured! The book you want to delete was not found...");
            }
            else
            {
                try
                {
                    context.Books.Remove(bookToDelete);
                    context.SaveChanges();
                    this.GridViewBooks.PageIndex = 0;
                    this.GridViewBooks.DataBind();
                    ErrorSuccessNotifier.AddSuccessMessage("Book successfully deleted!");
                }
                catch (Exception exc)
                {
                    ErrorSuccessNotifier.AddErrorMessage(exc);
                }
            }
        }

        protected void LinkButtonDeleteCancel_Click(object sender, EventArgs e)
        {
            this.PanelDelete.Visible = false;
        }

        private Book LoadBookData(Book book, LibrarySystemEntities context)
        {
            var bookTitle = this.TextBoxCreateEditBookTitle.Text.Trim();
            if (bookTitle.Length < 2)
            {
                ErrorSuccessNotifier.AddErrorMessage("Book title must consist of at least 2 symbols!");
                return null;
            }

            var bookAuthors = this.TextBoxCreateEditBookAuthors.Text.Trim();
            if (bookAuthors.Length < 2)
            {
                ErrorSuccessNotifier.AddErrorMessage("Book authors must consist of at least 2 symbols!");
                return null;
            }

            var bookIsbn = this.TextBoxCreateEditBookIsbn.Text;
            if (!string.IsNullOrWhiteSpace(bookIsbn))
            {
                bookIsbn = bookIsbn.Trim();
            }

            var bookWebSite = this.TextBoxCreateEditBookWebSite.Text;
            if (!string.IsNullOrWhiteSpace(bookWebSite))
            {
                bookWebSite = bookWebSite.Trim();
                var match = Regex.Match(
                    bookWebSite, @"(http(s)?://)?([\w-]+\.)+[\w-]+(/[\w- ;,./?%&=]*)?", RegexOptions.IgnoreCase);
                if (!match.Success)
                {
                    ErrorSuccessNotifier.AddErrorMessage("Invalid web site!");
                    return null;
                }

                if (!bookWebSite.StartsWith("http://") && !bookWebSite.StartsWith("https://"))
                {
                    bookWebSite = string.Format("http://{0}", bookWebSite);
                }
            }

            var bookDescription = this.TextBoxCreateEditBookDescription.Text;
            if (!string.IsNullOrWhiteSpace(bookDescription))
            {
                bookDescription = bookDescription.Trim();
            }

            var bookCategory = context.Categories.FirstOrDefault(
                c => c.Name == this.DropDownListBookCategories.SelectedValue);
            if (bookCategory == null)
            {
                ErrorSuccessNotifier.AddErrorMessage(
                    "An unexpected error occurred! The category you chose for the book was not found...");
                return null;
            }

            book.Title = bookTitle;
            book.Authors = bookAuthors;
            book.WebSite = bookWebSite;
            book.ISBN = bookIsbn;
            book.Description = bookDescription;
            book.Category = bookCategory;

            return book;
        }
    }
}