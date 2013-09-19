namespace LibrarySystem.Account
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using ErrorHandlerControl;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;

    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            string userName = UserName.Text;
            var manager = new AuthenticationIdentityManager(new IdentityStore());
            User u = new User(userName) { UserName = userName };
            IdentityResult result = manager.Users.CreateLocalUser(u, Password.Text);
            if (result.Success)
            {
                manager.Authentication.SignIn(Context.GetOwinContext().Authentication, u.Id, isPersistent: false);
                OpenAuthProviders.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                var errorMessageText = result.Errors.FirstOrDefault();
                ErrorMessage.Text = errorMessageText;
                ErrorSuccessNotifier.AddErrorMessage(errorMessageText);
            }
        }
    }
}