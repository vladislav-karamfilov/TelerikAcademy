<%@ Page Title="Search"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Search.aspx.cs"
    Inherits="LibrarySystem.Search" %>

<asp:Content ID="ContentSearch" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="span12">
            <h1 runat="server">
                <span>Search Results for Query </span><em>"<asp:Literal runat="server" ID="LiteralQuery"></asp:Literal>"</em>:
            </h1>

            <div class="span12 search-results">
                <asp:Repeater runat="server" ID="RepeaterQueryResults" ItemType="LibrarySystem.Models.Book">
                    <ItemTemplate>
                        <li>
                            <asp:LinkButton runat="server"
                                CommandArgument="<%# Item.BookId %>"
                                CommandName="ShowBookDetails"
                                OnCommand="ShowBookDetails_Command">
                            <span>"<%#: Item.Title %>"</span>
                            <em class="book-authors">by <%#: Item.Authors %></em>
                            </asp:LinkButton>

                            <span>(Category: <%#: Item.Category.Name %>)</span>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <div class="back-link">
        <asp:HyperLink runat="server" ID="HyperLinkBackToBooks" Text="Back to books"></asp:HyperLink>
    </div>
</asp:Content>
