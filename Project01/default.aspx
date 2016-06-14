<%@ Page Title="Scores" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project01.Default" %>

<asp:Content ID="Content5" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8"></div>
            <h1>Games List</h1>
            <a href="AddGame.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus"></i> Add Game </a>

           <asp:GridView runat="server" CssClass="table table-bordered table-striped table-hover" ID="GamesGridView" OnRowDeleting="GamesGridView_RowDeleting" AutoGenerateColumns="false">
                <Columns>
                     <asp:BoundField runat="Server" DataField="GameId" HeaderText="Game ID" Visible="true"/>
                     <asp:BoundField runat="Server" DataField="SportName" HeaderText="Sport" Visible="true" />
                     <asp:BoundField runat="Server" DataField="TeamNameOne" HeaderText="Team One" Visible="true" />
                     <asp:BoundField runat="Server" DataField="PointsScoredTeamOne" HeaderText="Points Team One" Visible="true" />
                     <asp:BoundField runat="Server" DataField="PointsAllowedTeamOne" HeaderText="Points Allowed Team One" Visible="true" />
                     <asp:BoundField runat="Server" DataField="TeamNameTwo" HeaderText="Team Two" Visible="true" />
                     <asp:BoundField runat="Server" DataField="PointsScoredTeamTwo" HeaderText="Points Team Two" Visible="true" />
                     <asp:BoundField runat="Server" DataField="PointsAllowedTeamTwo" HeaderText="Points Allowed Team Two" Visible="true" />
                     <asp:BoundField runat="Server" DataField="Spectators" HeaderText="Spectators" Visible="true" />

                     <asp:CommandField HeaderText="Delete" DeleteText="Delete" ShowDeleteButton ="true" ButtonType="Link"
                        ControlStyle-CssClass="btn btn-danger btn-sm" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
 