<%@ Page Title="Insert/Edit Question"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="InsertEditQuestion.aspx.cs"
    Inherits="PollSystem.Account.InsertEditQuestion" %>

<asp:Content runat="server"
    ID="ContentInsertEditQuestion"
    ContentPlaceHolderID="MainContent">
    <asp:Label runat="server" CssClass="label-question" ID="LabelQuestionText" Text="Question: " AssociatedControlID="TextBoxQuestionText" />
    <asp:TextBox runat="server" ID="TextBoxQuestionText" />
    <asp:Button runat="server" ID="ButtonSaveQuestionText" OnClick="ButtonSaveQuestionText_Click" Text="Save" />

    <ul id="question-answers">
        <asp:Repeater runat="server" ID="RepeaterAnswers" ItemType="PollSystem.Models.Answer">
            <ItemTemplate>
                <li class="answer">
                    <span>Answer: </span>
                    <asp:Literal runat="server" Text="<%#: Item.AnswerText %>"></asp:Literal>
                    <br />
                    <span>Votes: </span>
                    <asp:Literal runat="server" Text="<%#: Item.Votes %>"></asp:Literal>
                    <br />
                    <asp:LinkButton runat="server"
                        Text="Edit"
                        CommandName="Edit"
                        CommandArgument="<%# Item.AnswerId %>"
                        OnCommand="EditAnswer_Command" />
                    <asp:Literal runat="server" Text=" | "></asp:Literal>
                    <asp:LinkButton runat="server"
                        CausesValidation="false"
                        HeaderText="Action"
                        CommandName="DeleteAnswer"
                        CommandArgument="<%# Item.AnswerId %>"
                        OnCommand="DeleteAnswer_Command"
                        OnClientClick="return confirm('Are you sure you want to delete this answer?');"
                        Text="Delete" />
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>

    <asp:LinkButton runat="server"
        ID="LinkButtonCreateNewAnswer"
        Text="Create New Answer"
        OnClick="LinkButtonCreateNewAnswer_Click" Visible="false">
    </asp:LinkButton>
</asp:Content>
