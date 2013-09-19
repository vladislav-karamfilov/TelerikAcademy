<%@ Page Title="Twitter-Like Web Chat"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="TwitterLikeWebChat._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server"
        ID="GridViewChannels"
        AllowPaging="true"
        AllowSorting="true"
        PageSize="3"
        AutoGenerateColumns="false"
        DataKeyNames="ChannelId"
        SelectMethod="GridViewChannels_GetData"
        OnSelectedIndexChanged="GridViewChannels_SelectedIndexChanged"
        ItemType="TwitterLikeWebChat.Models.Channel">
        <Columns>
            <asp:BoundField DataField="Name" SortExpression="Name" ShowHeader="true" HeaderText="Channel" />
            <asp:CommandField ShowSelectButton="true" SelectText="Show" HeaderText="Action" />
        </Columns>
    </asp:GridView>

    <asp:Button runat="server"
        ID="ButtonClearChannel"
        Text="Clear Channel"
        OnClick="ButtonClearChannel_Click"
        OnClientClick="return confirm('Are you sure you want to clear this channel?');"
        CausesValidation="false"
        Visible="false" />
    <asp:Button runat="server"
        ID="ButtonRefreshChannel"
        Text="Refresh Channel"
        OnClick="ButtonRefreshChannel_Click"
        Visible="false" />
    <br />
    <asp:Repeater runat="server" ID="RepeaterMessages" ItemType="TwitterLikeWebChat.Models.Message">
        <ItemTemplate>
            <asp:Literal runat="server" Text="<%#: Item.Author.UserName %>" />
            <span>: </span>
            <asp:Literal runat="server" Text="<%#: Item.Content %>" />
            <span>[</span>
            <asp:Literal runat="server" Text="<%# Item.Date %>" />
            <span>]</span>
            <br />
        </ItemTemplate>
    </asp:Repeater>
    <br />
    <asp:Panel runat="server" ID="PanelChat" Visible="false">
        <asp:TextBox runat="server" ID="TextBoxUserMessage" />
        <asp:Button runat="server" ID="ButtonSubmitMessage" Text="Submit" OnClick="ButtonSubmitMessage_Click" />
    </asp:Panel>
</asp:Content>
