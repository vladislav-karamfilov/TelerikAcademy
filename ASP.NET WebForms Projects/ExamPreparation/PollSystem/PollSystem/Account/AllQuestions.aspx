<%@ Page Title="All questions"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="AllQuestions.aspx.cs"
    Inherits="PollSystem.Account.ViewAllResults" %>

<asp:Content ID="ContentAllQuestions" ContentPlaceHolderID="MainContent" runat="server">
    <h4>All questions results</h4>
    <asp:GridView ID="GridViewQuestions"
        runat="server"
        AutoGenerateColumns="False"
        DataKeyNames="QuestionId"
        PageSize="3"
        AllowPaging="true"
        AllowSorting="true"
        ItemType="PollSystem.Models.Question"
        SelectMethod="GridViewQuestions_GetData"
        OnSelectedIndexChanged="GridViewQuestions_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="QuestionText" HeaderText="Question" SortExpression="QuestionText" />
            <asp:CommandField ShowSelectButton="True" SelectText="Details" HeaderText="Action" />
        </Columns>
    </asp:GridView>

    <ul>
        <asp:Repeater ID="RepeaterAnswers" runat="server" ItemType="PollSystem.Models.Answer">
            <ItemTemplate>
                <li>
                    <%#: Item.AnswerText %> --> <%# Item.Votes %>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
</asp:Content>
