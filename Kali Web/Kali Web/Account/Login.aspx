<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Kali_Web.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src='https://www.google.com/recaptcha/api.js'></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <!--<script type="text/javascript" src="https://www.google.com/recaptcha/api.js?onload=onloadCallback&render=explicit"async defer></script>-->
    <script type="text/javascript">
        var onloadCallback = function () {
            grecaptcha.render('dvCaptcha', {
                'sitekey': '<%=ReCaptcha_Key %>',
                'callback': function (response) {
                    $.ajax({
                        type: "POST",
                        url: "Default.aspx/VerifyCaptcha",
                        data: "{response: '" + response + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (r) {
                            var captchaResponse = jQuery.parseJSON(r.d);
                            if (captchaResponse.success) {
                                $("[id*=txtCaptcha]").val(captchaResponse.success);
                                $("[id*=rfvCaptcha]").hide();
                            } else {
                                $("[id*=txtCaptcha]").val("");
                                $("[id*=rfvCaptcha]").show();
                                var error = captchaResponse["error-codes"][0];
                                $("[id*=rfvCaptcha]").html("RECaptcha error. " + error);
                            }
                        }
                    });
                }
            });
        };
    </script>
    <br />
    <%--<div style="font-size: 30px">--%>
    <asp:Label Font-Size="30px" ID="Label1" runat="server" Text="Log in"></asp:Label>
    <br />
    <asp:Label runat="server" Text="Log in to your account"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
    <br />

    <div class="col-md-12 text-center">
        <div class="form-horizontal col-md-6 col-xs-offset-3">
            
            <div class="form-group">
                <asp:Label ID="Label4" runat="server" CssClass="text-danger"></asp:Label>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox1"
                    CssClass="text-danger" ErrorMessage="The email field is required." />
            </div>

            <div class="form-group">
                <asp:Label Font-Size="20px" ID="Label2" class="col-xs-3 control-label" runat="server" Text="Email"></asp:Label>
                <div class="col-xs-8">
                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Email" TextMode="Email"></asp:TextBox>
                </div>
            </div>

            <div class="form-group">
                <asp:RequiredFieldValidator runat="server" ControlToValidate="TextBox2"
                    CssClass="text-danger" ErrorMessage="The password field is required." />
            </div>
            <div class="form-group">
                <asp:Label Font-Size="20px" class="col-xs-3 control-label" ID="Label3" runat="server" Text="Password"></asp:Label>
                <div class="col-xs-8">
                    <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                </div>

                <asp:Label ID="Label5" runat="server" CssClass="text-danger"></asp:Label>
                <asp:Label ID="Label8" runat="server" CssClass="text-danger"></asp:Label>
            </div>

            <div class="form-group">
                <div class="col-xs-8 col-xs-offset-3">
                    <!--<asp:CheckBox ID="CheckBox1" runat="server" Text=" Remember Me?" />-->
                    <div class="g-recaptcha" data-sitekey="6Le2QysUAAAAAJuMqCdo8wDVETXyrDPTtP4LjeRc"></div>
                    <asp:TextBox ID="txtCaptcha" runat="server" Style="display: none" />
                    <asp:RequiredFieldValidator ID = "rfvCaptcha" ErrorMessage="Captcha validation is required." ControlToValidate="txtCaptcha" runat="server" ForeColor = "Red" Display = "Dynamic" />
                </div>
            </div>

            <div class="form-group">
                <div class="col-xs-8 col-xs-offset-3">
                    <asp:Button ID="Button1" runat="server" class="btn btn-custom" Text="Log in" OnClick="Login_Click" />
                </div>
            </div>
            <br />
            <br />

            <div class="form-group">
                <div class="col-xs-8 col-xs-offset-3">
    <br />
                   </div>
            </div>
        </div>
    </div>
</asp:Content>