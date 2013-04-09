<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Access.ascx.cs" Inherits="Mordomo.Client.Controls.Access" %>
<div>
    <div>

    </div>
    <div id="pro_log_in">
        <input type="text" value="Login" onfocus="if(this.value=='Login'){this.value=''}" onblur="if(this.value==''){this.value='Login'}">
        <input type="password" value="Password" onfocus="if(this.value=='Password'){this.value=''}" onblur="if(this.value==''){this.value='Password'}">
        <a class="pro_btn pro_sign-in" onclick="document.getElementById('pro_log_in').submit()">Log In</a>
    </div>
</div>
