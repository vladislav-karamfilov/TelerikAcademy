<%@ Page Title="Voting Results"
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="VotingResults.aspx.cs"
    Inherits="PollSystem.VotingResults" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting"
    TagPrefix="asp" %>

<asp:Content ID="ContentQuestionVotingResults" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        <asp:Label runat="server" ID="LabelQuestionText"></asp:Label>
    </h1>
    <asp:Chart ID="ChartQuestionVotingResults" runat="server" ItemType="PollSystem.Models.Answer">
        <Series>
            <asp:Series Name="SeriesVotes" YValueType="Int32" ChartType="Column">
            </asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartAreaVotes">
            </asp:ChartArea>
            <%-- <asp:ChartArea Name="ChartAreaVotes" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent"
                BackColor="Transparent" ShadowColor="Transparent" BorderWidth="0">

                <Area3DStyle Inclination="68" Enable3D="true" LightStyle="Realistic" />
            </asp:ChartArea> --%>
        </ChartAreas>
    </asp:Chart>
    <br />
    <asp:LinkButton runat="server" OnClick="GoBack_Click" Text="Go Back" />
</asp:Content>
