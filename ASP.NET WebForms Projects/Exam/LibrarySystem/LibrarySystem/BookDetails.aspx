<%@ Page Title="Book Details"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="BookDetails.aspx.cs"
    Inherits="LibrarySystem.BookDetails" %>

<asp:Content ID="ContentBookDetails" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Book Details</h1>
    <asp:Panel runat="server" ID="PanelBookDetails">
        <p class="book-title">
            <asp:Literal runat="server" ID="LiteralBookTitle"></asp:Literal>
        </p>
        <p class="book-author">
            <em>
                <asp:Literal runat="server" ID="LiteralBookAuthors"></asp:Literal>
            </em>
        </p>
        <p class="book-isbn">
            <em>
                <asp:Literal runat="server" ID="LiteralBookIsbn"></asp:Literal>
            </em>
        </p>
        <p class="book-isbn">
            <em>
                <span id="book-web-site">Web site:</span>
                <asp:HyperLink runat="server" ID="HyperLinkWebSite"></asp:HyperLink>
            </em>
        </p>
        <div class="row-fluid">
            <div class="span12 book-description">
                <p>
                    <asp:Literal runat="server" ID="LiteralBookDescription"></asp:Literal>
                </p>
            </div>
        </div>
    </asp:Panel>

    <div class="back-link">
        <asp:HyperLink runat="server" ID="HyperLinkBackToBooks" Text="Back to books"></asp:HyperLink>
    </div>
</asp:Content>
