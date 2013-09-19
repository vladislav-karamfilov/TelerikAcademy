<%@ Page Title="Edit Books"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="EditBooks.aspx.cs"
    Inherits="LibrarySystem.Account.EditBooks" %>

<asp:Content ID="ContentEditBooks" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Books</h1>

    <asp:GridView runat="server"
        ID="GridViewBooks"
        ItemType="LibrarySystem.ViewModels.BookViewModel"
        AutoGenerateColumns="False"
        DataKeyNames="BookId"
        PageSize="5"
        AllowPaging="true"
        AllowSorting="true"
        SelectMethod="GridViewBooks_GetData"
        CssClass="gridview">
        <Columns>
            <asp:TemplateField HeaderText="Title" SortExpression="Title">
                <ItemTemplate>
                    <%#: (Item.Title.Length <= 20) ? Item.Title : (Item.Title.Substring(0, 17) + "...") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Authors" SortExpression="Authors">
                <ItemTemplate>
                    <%#: (Item.Authors.Length <= 20) ? Item.Authors : (Item.Authors.Substring(0, 17) + "...") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="ISBN" HeaderText="ISBN" SortExpression="ISBN" />
            <asp:TemplateField HeaderText="Web Site" SortExpression="WebSite">
                <ItemTemplate>
                    <a runat="server" href="<%#: Item.WebSite %>">
                        <%#: (Item.WebSite == null || Item.WebSite.Length <= 20) ? Item.WebSite : (Item.WebSite.Substring(0, 17) + "...") %>
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Category" SortExpression="Category">
                <ItemTemplate>
                    <%#: (Item.Category.Length <= 20) ? Item.Category : (Item.Category.Substring(0, 17) + "...") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton runat="server"
                        CommandArgument="<%# Item.BookId %>"
                        CommandName="EditBook"
                        OnCommand="EditBook_Command"
                        CssClass="link-button"
                        Text="Edit">
                    </asp:LinkButton>

                    <asp:LinkButton runat="server"
                        CommandArgument="<%# Item.BookId %>"
                        CommandName="DeleteBook"
                        OnCommand="DeleteBook_Command"
                        CssClass="link-button"
                        Text="Delete">
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div class="create-link">
        <asp:LinkButton runat="server"
            ID="LinkButtonCreateNewBook"
            Text="Create New"
            OnClick="LinkButtonCreateNewBook_Click"
            CssClass="link-button"></asp:LinkButton>
    </div>

    <asp:Panel runat="server" ID="PanelCreateEdit" CssClass="panel">
        <h2>Create New Book</h2>
        <asp:Label runat="server"
            AssociatedControlID="TextBoxCreateEditBookTitle"
            Text="<span>Title: </span>"></asp:Label>
        <asp:TextBox runat="server" ID="TextBoxCreateEditBookTitle"></asp:TextBox>
        <br />
        <asp:Label runat="server"
            AssociatedControlID="TextBoxCreateEditBookAuthors"
            Text="<span>Author(s): </span>"></asp:Label>
        <asp:TextBox runat="server" ID="TextBoxCreateEditBookAuthors"></asp:TextBox>
        <br />
        <asp:Label runat="server"
            AssociatedControlID="TextBoxCreateEditBookIsbn"
            Text="<span>ISBN: </span>"></asp:Label>
        <asp:TextBox runat="server" ID="TextBoxCreateEditBookIsbn"></asp:TextBox>
        <br />
        <asp:Label runat="server"
            AssociatedControlID="TextBoxCreateEditBookWebSite"
            Text="<span>Web Site: </span>"></asp:Label>
        <asp:TextBox runat="server" ID="TextBoxCreateEditBookWebSite"></asp:TextBox>
        <br />
        <asp:Label runat="server"
            AssociatedControlID="TextBoxCreateEditBookDescription"
            Text="<span>Description: </span>"></asp:Label>
        <asp:TextBox runat="server" ID="TextBoxCreateEditBookDescription" TextMode="MultiLine" Rows="5"></asp:TextBox>
        <br />
        <asp:Label runat="server"
            AssociatedControlID="DropDownListBookCategories"
            Text="<span>Category: </span>"></asp:Label>
        <asp:DropDownList runat="server"
            ID="DropDownListBookCategories"
            SelectMethod="DropDownListBookCategories_GetData">
        </asp:DropDownList>
        <br />
        <asp:LinkButton
            runat="server"
            ID="LinkButtonCreateConfirm"
            Text="Create"
            OnClick="LinkButtonCreateConfirm_Click"
            CssClass="link-button">
        </asp:LinkButton>
        <asp:LinkButton
            runat="server"
            ID="LinkButtonEditSave"
            Text="Save"
            OnClick="LinkButtonEditSave_Click"
            CssClass="link-button">
        </asp:LinkButton>
        <asp:LinkButton
            runat="server"
            ID="LinkButtonCreateEditCancel"
            Text="Cancel"
            OnClick="LinkButtonCreateEditCancel_Click"
            CssClass="link-button">
        </asp:LinkButton>
        <asp:Literal runat="server" ID="LiteralBookToEditId" Visible="false"></asp:Literal>
    </asp:Panel>

    <asp:Panel runat="server" ID="PanelDelete" CssClass="panel">
        <h2>Confirm Book Deletion?</h2>
        <asp:Label runat="server"
            AssociatedControlID="TextBoxDeleteBookTitle"
            Text="Title: "></asp:Label>
        <asp:TextBox runat="server" ID="TextBoxDeleteBookTitle" ReadOnly="true"></asp:TextBox>
        <br />
        <asp:LinkButton
            runat="server"
            ID="LinkButtonDeleteConfirm"
            Text="Yes"
            OnClick="LinkButtonDeleteConfirm_Click"
            CssClass="link-button">
        </asp:LinkButton>
        <asp:LinkButton
            runat="server"
            ID="LinkButtonDeleteCancel"
            Text="No"
            OnClick="LinkButtonDeleteCancel_Click"
            CssClass="link-button">
        </asp:LinkButton>
        <asp:Literal runat="server" ID="LiteralBookToDeleteId" Visible="false"></asp:Literal>
    </asp:Panel>

    <div class="back-link">
        <asp:HyperLink runat="server" Text="Back to books" NavigateUrl="/"></asp:HyperLink>
    </div>
</asp:Content>
