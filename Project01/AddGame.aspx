<%@ Page Title="Add Game" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddGame.aspx.cs" Inherits="Project01.AddGame" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-3 col md-6">
                <h1>Game details</h1>
                <h5>All fields are required</h5>
                <br />

            <div>
                <label for="GameWeekDropDownList">Week To Display </label>
                <asp:DropDownList ID="GameWeekDropDownList" runat="server"
                    AutoPostBack="true" CssClass="btn btn-default bt-sm dropdown-toggle"
                    OnSelectedIndexChanged="GameWeekDropDownList_SelectedIndexChanged">
                    <asp:ListItem Text="Week 1" Value="1" />
                    <asp:ListItem Text="Week 2" Value="2" />
                    <asp:ListItem Text="Week 3" Value="3" />
                    <asp:ListItem Text="Week 4" Value="4" />
                    <asp:ListItem Text="Week 5" Value="5" />
                    <asp:ListItem Text="Week 6" Value="6" />
                    <asp:ListItem Text="Week 7" Value="7" />
                    <asp:ListItem Text="Week 8" Value="8" />
                    <asp:ListItem Text="Week 9" Value="9" />
                    <asp:ListItem Text="Week 10" Value="10" />
                </asp:DropDownList>
            </div>

                <div class="form-group">
                    <label class="control-label" for="TeamOneNameTextBox">Team One Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="TeamOneNameTextBox" placeholder="Team One Name" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="TeamOneScoreTextBox">Team One Score</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="TeamOneScoreTextBox" placeholder="Team One Score" required="true"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label class="control-label" for="TeamTwoNameTextBox">Team Two Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="TeamTwoNameTextBox" placeholder="Team Two Name" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="TeamTwoScoreTextBox">Team Two Score</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="TeamTwoScoreTextBox" placeholder="Team Two Score" required="true"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label class="control-label" for="SpectatorsTextBox">Spectators</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="SpectatorsTextBox" placeholder="Spectators" required="true"></asp:TextBox>
                </div>

                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" CssClass="btn btn-warning btn-lg" runat="server"
                        UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click" />
                    <asp:Button Text="Save" ID="SaveButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="SaveButton_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
