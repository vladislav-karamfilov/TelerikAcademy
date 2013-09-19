namespace TwitterLikeWebChat
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using ErrorHandlerControl;
    using TwitterLikeWebChat.Models;

    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.RepeaterMessages.DataSource = null;
            this.RepeaterMessages.DataBind();
        }

        public IQueryable<Channel> GridViewChannels_GetData()
        {
            var context = new TwitterLikeWebChatEntities();
            return context.Channels.OrderBy(ch => ch.ChannelId);
        }

        protected void GridViewChannels_SelectedIndexChanged(object sender, EventArgs e)
        {
            var context = new TwitterLikeWebChatEntities();
            var channelId = Convert.ToInt32(this.GridViewChannels.SelectedDataKey.Value);
            var messages = context.Messages.Where(m => m.ChannelId == channelId);
            this.RepeaterMessages.DataSource = messages.ToList();
            this.RepeaterMessages.DataBind();
            this.ButtonClearChannel.Visible = true;
            this.ButtonRefreshChannel.Visible = true;

            if (this.User.Identity.IsAuthenticated)
            {
                this.PanelChat.Visible = true;
                this.TextBoxUserMessage.Text = string.Empty;
            }
        }

        protected void ButtonSubmitMessage_Click(object sender, EventArgs e)
        {
            int currentChannelId = Convert.ToInt32(this.GridViewChannels.SelectedDataKey.Value);
            if (currentChannelId == 0)
            {
                ErrorSuccessNotifier.AddErrorMessage("No chat channel is selected!");
            }
            else
            {
                var context = new TwitterLikeWebChatEntities();
                var channel = context.Channels.FirstOrDefault(ch => ch.ChannelId == currentChannelId);
                if (channel == null)
                {
                    ErrorSuccessNotifier.AddErrorMessage(
                        "An unexpected error occurred! The channel you want to chat in was not found!");
                }
                else
                {
                    try
                    {
                        var newMessage = new Message();
                        newMessage.Author = context.AspNetUsers.FirstOrDefault(u => u.UserName == this.User.Identity.Name);
                        var newMessageText = this.TextBoxUserMessage.Text.Trim();
                        if (newMessageText.Length < 1)
                        {
                            ErrorSuccessNotifier.AddInfoMessage("Message content must be at least one symbol!");
                        }
                        else
                        {
                            newMessage.Content = newMessageText;
                            newMessage.Date = DateTime.Now;
                            channel.Messages.Add(newMessage);

                            context.SaveChanges();
                            this.TextBoxUserMessage.Text = string.Empty;
                        }

                        this.GridViewChannels_SelectedIndexChanged(null, null);
                    }
                    catch (Exception exc)
                    {
                        ErrorSuccessNotifier.AddErrorMessage(exc);
                    }
                }
            }
        }

        protected void ButtonClearChannel_Click(object sender, EventArgs e)
        {
            int currentChannelId = Convert.ToInt32(this.GridViewChannels.SelectedDataKey.Value);
            if (currentChannelId == 0)
            {
                ErrorSuccessNotifier.AddSuccessMessage("No chat channel is selected!");
            }
            else
            {
                var context = new TwitterLikeWebChatEntities();
                try
                {
                    var messages = context.Messages.Where(m => m.ChannelId == currentChannelId);
                    context.Messages.RemoveRange(messages);
                    context.SaveChanges();

                    this.ButtonClearChannel.Visible = false;
                    this.ButtonRefreshChannel.Visible = false;
                    this.PanelChat.Visible = false;

                    ErrorSuccessNotifier.AddSuccessMessage("Channel successfully cleared!");
                }
                catch (Exception exc)
                {
                    ErrorSuccessNotifier.AddErrorMessage(exc);
                }
            }
        }

        protected void ButtonRefreshChannel_Click(object sender, EventArgs e)
        {
            int currentChannelId = Convert.ToInt32(this.GridViewChannels.SelectedDataKey.Value);
            if (currentChannelId == 0)
            {
                ErrorSuccessNotifier.AddSuccessMessage("No chat channel is selected!");
            }
            else
            {
                this.GridViewChannels_SelectedIndexChanged(null, null);
            }
        }
    }
}