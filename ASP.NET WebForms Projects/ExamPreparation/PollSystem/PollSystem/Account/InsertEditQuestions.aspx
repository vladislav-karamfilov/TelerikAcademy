<%@ Page Title="Insert/Edit Questions"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="InsertEditQuestions.aspx.cs"
    Inherits="PollSystem.Account.InsertEditQuestions" %>

<asp:Content ID="ContentInsertEditQuestions" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server"
        ID="GridViewQuestions"
        AutoGenerateColumns="False"
        DataKeyNames="QuestionId"
        PageSize="3"
        AllowPaging="true"
        AllowSorting="true"
        ItemType="PollSystem.Models.Question"
        SelectMethod="GridViewQuestions_GetData"
        DeleteMethod="GridViewQuestions_DeleteItem">
        <Columns>
            <asp:BoundField DataField="QuestionText" HeaderText="Question" SortExpression="QuestionText" />
            <asp:HyperLinkField Text="Edit"
                HeaderText="Action"
                DataNavigateUrlFields="QuestionId"
                DataNavigateUrlFormatString="InsertEditQuestion.aspx?questionId={0}" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton runat="server"
                        Text="Delete"
                        CausesValidation="false"
                        HeaderText="Action"
                        CommandName="Delete"
                        CommandArgument="<%# Item.QuestionId %>"
                        OnClientClick="return confirm('Are you sure you want to delete this question?');" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:LinkButton runat="server"
        ID="LinkButtonCreateNewQuestion"
        Text="Create New Question"
        OnClick="LinkButtonCreateNewQuestion_Click">
    </asp:LinkButton>
</asp:Content>
