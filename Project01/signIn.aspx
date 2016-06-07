<%@ Page Title="SignIn" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="signIn.aspx.cs" Inherits="Project01.signIn" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-6 text-center">
                <h2>Please Sign-in below with your username and password</h2>
            </div>
        </div>

        <br />
        <br />
        <div class="col-md-6">
            <div class="form-group">
                <label class="control-label" for="UserNameTextBox">User Name</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="UserNameTextBox" placeholder="User Name" required="true"></asp:TextBox>
                <asp:RequiredFieldValidator Display="Dynamic" CssClass="alert-danger" ID="RequiredFieldValidator1" runat="server" ErrorMessage="User Name is required" ControlToValidate="UserNameTextBox"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label class="control-label" for="PasswordTextBox">Password</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="PasswordTextBox" placeholder="Password" required="true"></asp:TextBox>
                <asp:RequiredFieldValidator Display="Dynamic" CssClass="alert-danger" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Password is required" ControlToValidate="PasswordTextBox"></asp:RequiredFieldValidator>
            </div>
            <div class="text-right">
                <a class="btn btn-default btn-lg" id="CancelButton" href="scores.aspx">Cancel</a>
                <asp:Button runat="server" CssClass="btn btn-primary btn-lg" ID="SendButton" Text="Send" CausesValidation="true" OnClick="SendButton_Click" />
            </div>
        </div>
</asp:Content>

