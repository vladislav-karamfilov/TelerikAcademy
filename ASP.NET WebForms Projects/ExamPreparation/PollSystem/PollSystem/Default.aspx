<%@ Page Title="Polls" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PollSystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListViewPolls" runat="server" ItemType="PollSystem.Models.Question">
        <LayoutTemplate>
            <div id="itemPlaceholder" runat="server"></div>
        </LayoutTemplate>
        <ItemTemplate>
            <div class="question-container">
                <span class="question-text"><%#: Item.QuestionText %></span><br />
                <ul>
                    <asp:Repeater ID="RepeaterAnswers" runat="server" ItemType="PollSystem.Models.Answer" DataSource="<%# Item.Answers %>">
                        <ItemTemplate>
                            <li class="answer-container">
                                <%#: Item.AnswerText %>
                                <asp:LinkButton runat="server"
                                    Text="Vote"
                                    CommandArgument="<%# Item.AnswerId %>"
                                    CommandName="Vote"
                                    OnCommand="Vote_Command" />
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
