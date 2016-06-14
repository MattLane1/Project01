<%@ Page Title="Scores" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project01.Default" %>

<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8"></div>

            <asp:GridView runat="server" CssClass="table table-bordered table-striped table-hover" ID="GamesGridView" 
                AutoGenerateColumns="true" DataKeyNames="TeamId" OnRowDeleting="GamesGridView_RowDeleting"  PageSize="3" 
                OnPageIndexChanging="GamesGridView_PageIndexChanging"  
                OnRowDataBound="GamesGridView_RowDataBound" >
                <Columns>
                     <asp:BoundField DataField="TeamId" HeaderText="Game ID" Visible="true" SortExpression="GameId"/>
                     <asp:BoundField DataField="SportName" HeaderText="Sport" Visible="true" SortExpression="SportName"/>
                     <asp:BoundField DataField="TeamNameOne" HeaderText="Team One" Visible="true" SortExpression="TeamNameOne"/>
                     <asp:BoundField DataField="PointsScoredTeamOne" HeaderText="Points Team One" Visible="true" SortExpression="PointsScoredTeamOne"/>
                     <asp:BoundField DataField="PointsAllowedTeamOne" HeaderText="Points Allowed Team One" Visible="true" SortExpression="PointsAllowedTeamOne"/>
                     <asp:BoundField DataField="TeamNameTwo" HeaderText="Team Two" Visible="true" SortExpression="TeamNameTwo"/>
                     <asp:BoundField DataField="PointsScoredTeamTwo" HeaderText="Points Team Two" Visible="true" SortExpression="PointsScoredTeamTwo"/>
                     <asp:BoundField DataField="PointsAllowedTeamTwo" HeaderText="Points Allowed Team Two" Visible="true" SortExpression="PointsAllowedTeamTwo"/>
                     <asp:BoundField DataField="Spectators" HeaderText="Spectators" Visible="true" SortExpression="Spectators"/>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
 