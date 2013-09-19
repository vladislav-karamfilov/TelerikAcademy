<%@ Page Title="Insert/Edit Answer"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="InsertEditAnswer.aspx.cs"
    Inherits="PollSystem.Account.InsertEditAnswer" %>

<asp:Content runat="server" ID="ContentInsertEditAnswer" ContentPlaceHolderID="MainContent">
    <asp:Label runat="server" CssClass="label-answer" ID="LabelAnswerText" AssociatedControlID="TextBoxAnswerText" Text="Answer: " />
    <asp:TextBox runat="server" ID="TextBoxAnswerText" />
    <br />

    <asp:Label runat="server" CssClass="label-answer" ID="LabelAnswerVotes" AssociatedControlID="TextBoxAnswerVotes" Text="Votes: " />
    <asp:TextBox runat="server" ID="TextBoxAnswerVotes" />
    <br />

    <asp:Button runat="server" ID="ButtonSaveAnswer" OnClick="ButtonSaveAnswer_Click" Text="Save Answer" />
</asp:Content>
