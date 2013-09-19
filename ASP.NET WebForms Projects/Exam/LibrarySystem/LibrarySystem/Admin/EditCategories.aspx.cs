namespace LibrarySystem.Account
{
    using System;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using ErrorHandlerControl;
    using LibrarySystem.Models;

    public partial class EditCategories : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.PanelCreate.Visible = false;
            this.PanelEdit.Visible = false;
            this.PanelDelete.Visible = false;

            this.LinkButtonCreateNewCategory.Visible = true;
        }

        public IQueryable<Category> GridViewCategories_GetData()
        {
            var context = new LibrarySystemEntities();
            var categories = context.Categories.OrderBy(c => c.CategoryId);
            return categories;
        }

        protected void LinkButtonCreateNewCategory_Click(object sender, EventArgs e)
        {
            this.LinkButtonCreateNewCategory.Visible = false;
            this.PanelCreate.Visible = true;
        }

        protected void EditCategory_Command(object sender, CommandEventArgs e)
        {
            this.PanelEdit.Visible = true;
            this.LinkButtonCreateNewCategory.Visible = false;
            this.LiteralCategoryToEditId.Text = e.CommandArgument.ToString();

            var categoryId = Convert.ToInt32(e.CommandArgument);
            var context = new LibrarySystemEntities();
            var category = context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (category == null)
            {
                ErrorSuccessNotifier.AddErrorMessage(
                    "An unexpected error occurred! The category you want to edit was not found...");
            }
            else
            {
                this.TextBoxEditCategoryName.Text = category.Name;
            }
        }

        protected void DeleteCategory_Command(object sender, CommandEventArgs e)
        {
            this.PanelDelete.Visible = true;
            this.LinkButtonCreateNewCategory.Visible = false;
            this.LiteralCategoryToDeleteId.Text = e.CommandArgument.ToString();

            var categoryId = Convert.ToInt32(e.CommandArgument);
            var context = new LibrarySystemEntities();
            var category = context.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
            if (category == null)
            {
                ErrorSuccessNotifier.AddErrorMessage(
                    "An unexpected error occurred! The category you want to delete was not found...");
            }
            else
            {
                this.TextBoxDeleteCategoryName.Text = category.Name;
            }
        }

        protected void LinkButtonCreateConfirm_Click(object sender, EventArgs e)
        {
            var categoryName = this.TextBoxCreateCategoryName.Text.Trim();
            if (categoryName.Length < 2)
            {
                ErrorSuccessNotifier.AddErrorMessage("Category name must consist of at least 2 symbols!");
                return;
            }

            var context = new LibrarySystemEntities();
            if (context.Categories.Any(c => c.Name == categoryName))
            {
                ErrorSuccessNotifier.AddErrorMessage("Category with this name already exists!");
                return;
            }

            var newCategory = new Category();
            newCategory.Name = categoryName;
            context.Categories.Add(newCategory);

            try
            {
                context.SaveChanges();
                this.GridViewCategories.DataBind();
                this.TextBoxCreateCategoryName.Text = string.Empty;
                ErrorSuccessNotifier.AddSuccessMessage("Category successfully created!");
            }
            catch (Exception exc)
            {
                ErrorSuccessNotifier.AddErrorMessage(exc);
            }
        }

        protected void LinkButtonCreateCancel_Click(object sender, EventArgs e)
        {
            this.PanelCreate.Visible = false;
        }

        protected void LinkButtonEditSave_Click(object sender, EventArgs e)
        {
            var categoryToEditId = Convert.ToInt32(this.LiteralCategoryToEditId.Text);
            var categoryToEditNewName = this.TextBoxEditCategoryName.Text;
            var context = new LibrarySystemEntities();
            var categoryToEdit = context.Categories.FirstOrDefault(c => c.CategoryId == categoryToEditId);
            if (categoryToEdit.Name == categoryToEditNewName)
            {
                ErrorSuccessNotifier.AddSuccessMessage("Category successfully edited!");
                return;
            }

            if (context.Categories.Any(c => c.Name == categoryToEditNewName))
            {
                ErrorSuccessNotifier.AddErrorMessage("Category with this name already exists!");
                return;
            }

            if (categoryToEdit == null)
            {
                ErrorSuccessNotifier.AddErrorMessage(
                    "An unexpected error occured! The category you want to edit was not found...");
            }
            else
            {
                categoryToEdit.Name = categoryToEditNewName;
                try
                {
                    context.SaveChanges();
                    this.GridViewCategories.DataBind();
                    ErrorSuccessNotifier.AddSuccessMessage("Category successfully edited!");
                }
                catch (Exception exc)
                {
                    ErrorSuccessNotifier.AddErrorMessage(exc);
                }
            }
        }

        protected void LinkButtonEditCancel_Click(object sender, EventArgs e)
        {
            this.PanelEdit.Visible = false;
        }

        protected void LinkButtonDeleteConfirm_Click(object sender, EventArgs e)
        {
            var categoryToDeleteId = Convert.ToInt32(this.LiteralCategoryToDeleteId.Text);
            var context = new LibrarySystemEntities();

            var categoryToDelete = context.Categories.FirstOrDefault(c => c.CategoryId == categoryToDeleteId);
            if (categoryToDelete == null)
            {
                ErrorSuccessNotifier.AddErrorMessage(
                    "An unexpected error occured! The category you want to delete was not found...");
            }
            else
            {
                try
                {
                    context.Books.RemoveRange(categoryToDelete.Books);
                    context.Categories.Remove(categoryToDelete);
                    context.SaveChanges();
                    this.GridViewCategories.PageIndex = 0;
                    this.GridViewCategories.DataBind();
                    ErrorSuccessNotifier.AddSuccessMessage("Category successfully deleted!");
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
    }
}