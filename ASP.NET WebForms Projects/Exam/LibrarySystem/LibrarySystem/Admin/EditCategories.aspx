<%@ Page Title="Edit Categories"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="EditCategories.aspx.cs"
    Inherits="LibrarySystem.Account.EditCategories" %>

<asp:Content ID="ContentEditCategories" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Edit Categories</h1>

    <asp:GridView runat="server"
        ID="GridViewCategories"
        ItemType="LibrarySystem.Models.Category"
        AutoGenerateColumns="False"
        DataKeyNames="CategoryId"
        PageSize="5"
        AllowPaging="true"
        AllowSorting="true"
        SelectMethod="GridViewCategories_GetData"
        CssClass="gridview">
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Category Name" SortExpression="Name" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:LinkButton runat="server"
                        CommandArgument="<%# Item.CategoryId %>"
                        CommandName="EditCategory"
                        OnCommand="EditCategory_Command"
                        CssClass="link-button"
                        Text="Edit">
                    </asp:LinkButton>

                    <asp:LinkButton runat="server"
                        CommandArgument="<%# Item.CategoryId %>"
                        CommandName="DeleteCategory"
                        OnCommand="DeleteCategory_Command"
                        CssClass="link-button"
                        Text="Delete">
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div class="create-link">
        <asp:LinkButton runat="server"
            ID="LinkButtonCreateNewCategory"
            Text="Create New"
            OnClick="LinkButtonCreateNewCategory_Click"
            CssClass="link-button"></asp:LinkButton>
    </div>

    <asp:Panel runat="server" ID="PanelCreate" CssClass="panel">
        <h2>Create New Category</h2>
        <asp:Label runat="server"
            ID="LabelCreateCategoryName"
            AssociatedControlID="TextBoxCreateCategoryName"
            Text="Category: "></asp:Label>
        <asp:TextBox runat="server" ID="TextBoxCreateCategoryName" Placeholder="Enter category name..."></asp:TextBox>
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
            ID="LinkButtonCreateCancel"
            Text="Cancel"
            OnClick="LinkButtonCreateCancel_Click"
            CssClass="link-button">
        </asp:LinkButton>
    </asp:Panel>

    <asp:Panel runat="server" ID="PanelEdit" CssClass="panel">
        <h2>Edit Category</h2>
        <asp:Label runat="server"
            ID="LabelEditCategoryName"
            AssociatedControlID="TextBoxEditCategoryName"
            Text="Category: "></asp:Label>
        <asp:TextBox runat="server" ID="TextBoxEditCategoryName"></asp:TextBox>
        <br />
        <asp:LinkButton
            runat="server"
            ID="LinkButtonEditSave"
            Text="Save"
            OnClick="LinkButtonEditSave_Click"
            CssClass="link-button">
        </asp:LinkButton>
        <asp:LinkButton
            runat="server"
            ID="LinkButtonCancel"
            Text="Cancel"
            OnClick="LinkButtonEditCancel_Click"
            CssClass="link-button">
        </asp:LinkButton>
        <asp:Literal runat="server" ID="LiteralCategoryToEditId" Visible="false"></asp:Literal>
    </asp:Panel>

    <asp:Panel runat="server" ID="PanelDelete" CssClass="panel">
        <h2>Confirm Category Deletion?</h2>
        <asp:Label runat="server"
            ID="LabelDeleteCategoryName"
            AssociatedControlID="TextBoxDeleteCategoryName"
            Text="Category: "></asp:Label>
        <asp:TextBox runat="server" ID="TextBoxDeleteCategoryName" ReadOnly="true"></asp:TextBox>
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
        <asp:Literal runat="server" ID="LiteralCategoryToDeleteId" Visible="false"></asp:Literal>
    </asp:Panel>

    <div class="back-link">
        <asp:HyperLink runat="server" Text="Back to books" NavigateUrl="/"></asp:HyperLink>
    </div>
</asp:Content>
