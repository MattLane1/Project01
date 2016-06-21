<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar.ascx.cs" Inherits="Project01.Navbar" %>
<nav class="navbar navbar-inverse" role="navigation">
    <div class="container-fluid">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="Default.aspx"><i class="fa fa-video-camera fa-lg"></i> Score Recording</a>
        </div>
        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav navbar-right">
                <li id="default" runat="server"><a href="/default.aspx"><i class="fa fa-home fa-lg"></i> Score Reports</a></li>  

                <asp:PlaceHolder ID="PublicPlaceHolder" runat="server">
                 <li id="Register" runat="server"><a href="/Register.aspx"><i class="fa fa-user-plus fa-lg"></i> Sign Up</a></li>
                 <li id="Login" runat="server"><a href="/Login.aspx"><i class="fa fa-user fa-lg"></i> Sign In</a></li>
                </asp:Placeholder>

                <asp:PlaceHolder ID="PrivatePlaceHolder" runat="server">
                <li id="Logout" runat="server"><a href="/Logout.aspx"><i class="fa fa-user-times fa-lg"></i> Sign Out</a></li>
                <li id="EditUserDetails" runat="server"><a href="/User/UserDetails.aspx"><i class="fa fa-file-text fa-lg"></i> Edit Account </a></li>
                </asp:PlaceHolder>

                <asp:PlaceHolder ID="AdminPlaceHolder" runat="server">
                <li id="Li1" runat="server"><a href="/User/Users.aspx"><i class="fa fa-group fa-lg"></i> Registered Users </a></li>
                </asp:PlaceHolder>

                <li id="contact" runat="server"><a href="/Contact.aspx"><i class="fa fa-phone fa-lg"></i> Contact</a></li>
            </ul>
        </div>
        <!-- /.navbar-collapse -->
    </div>
    <!-- /.container-fluid -->
</nav>
