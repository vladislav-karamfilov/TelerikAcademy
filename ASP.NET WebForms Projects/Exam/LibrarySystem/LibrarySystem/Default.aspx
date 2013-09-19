<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LibrarySystem._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="span1">
            <h1>Books</h1>
        </div>

        <div class="search-button">
            <div class="form-search">
                <div class="input-append">
                    <asp:TextBox runat="server"
                        CssClass="span3 search-query"
                        ID="TextBoxSearch"
                        Placeholder="Search by book title / author..."></asp:TextBox>
                    <asp:LinkButton runat="server" ID="LinkButtonSearch" CssClass="btn" Text="Search" OnClick="LinkButtonSearch_Click" />
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <asp:ListView runat="server" ID="ListViewCategories" ItemType="LibrarySystem.Models.Category">
            <ItemTemplate>
                <div class="span4" style="min-height: 200px">
                    <ul>
                        <h2><%#: Item.Name %></h2>
                        <asp:Repeater runat="server" ItemType="LibrarySystem.Models.Book" DataSource="<%# Item.Books %>">
                            <ItemTemplate>
                                <li>
                                    <asp:LinkButton runat="server"
                                        CommandArgument="<%# Item.BookId %>"
                                        CommandName="BookDetails"
                                        OnCommand="BookDetails_Command">
                            <span>"</span><asp:Literal runat="server" Text="<%#: Item.Title %>"></asp:Literal><span>"</span>
                            <em>
                                <span>by</span>
                                <asp:Literal runat="server" Text="<%#: Item.Authors %>"></asp:Literal>
                            </em>
                                    </asp:LinkButton>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
