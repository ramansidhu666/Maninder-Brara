<%@ Page Title="" Language="C#" MasterPageFile="~/PropertyNew.Master" AutoEventWireup="true" CodeBehind="Renovation.aspx.cs" Inherits="Property.Renovation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxtoolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <link href="../css/style_002.css" rel="stylesheet" />
    <link href="../slider/css/style.css" rel="stylesheet" />
    <link href="../css/shortcodes.css" rel="stylesheet" />
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyDxw4-H4Y1ig9brfwS9Qwt8wCNE96ueVhE&libraries=places,geometry"></script>
    <script type="text/javascript">
        google.maps.event.addDomListener(window, 'load', function () {
            var places = new google.maps.places.Autocomplete(document.getElementById('MainContent_search'));
            google.maps.event.addListener(places, 'place_changed', function () {
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxtoolkit:ToolkitScriptManager ID="fds" runat="server"></ajaxtoolkit:ToolkitScriptManager>
    <div class="form_backg">
        <div class="row frnt_line_cls">
            <div class="col-md-3 col-sm-3">
                <%--<div class="contact_in_right">

                    <img src="Images/contact-img-2_new.png" alt="" />
                </div>--%>
            </div>
            <div class="col-md-6 col-sm-6">
                <div class="contact_in_left">
                    <h2>Renovation Form</h2>
                    <div class="agent_input">
                        <p>
                            First Name:
                            <asp:TextBox ID="FirstName" CssClass="CTextBox" runat="server" PlaceHolder="Name" MaxLength="20"></asp:TextBox>

                        </p>
                    </div>
                    <div class="agent_input">
                        <p>
                            Last Name:
                            <asp:TextBox ID="LastName" CssClass="CTextBox" runat="server" PlaceHolder="Name" MaxLength="20"></asp:TextBox>

                        </p>
                    </div>
                    <div class="agent_input">
                        <p>
                            E-mail:
                          <asp:TextBox ID="txtEmail" CssClass="CTextBox" runat="server" PlaceHolder="Email"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ValidationGroup="FreeHome" Display="Dynamic" ControlToValidate="txtEmail" ErrorMessage="EmailID required" SetFocusOnError="true"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rgeEmail" runat="server" ValidationGroup="FreeHome" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Invalid email address." />
                        </p>
                    </div>
                    <div class="agent_input">
                        <p>
                            Phone Number:
                          <asp:TextBox ID="txtPhoneno" CssClass="CTextBox" runat="server" PlaceHolder="Phone Number"></asp:TextBox>
                            <ajaxtoolkit:MaskedEditExtender runat="server" ID="mee" Mask="(999) 999-9999"
                                TargetControlID="txtPhoneno">
                            </ajaxtoolkit:MaskedEditExtender>
                            
                        </p>
                    </div>
                    <div class="agent_input">
                        <p>
                            Property Address:
                        <asp:TextBox ID="search" CssClass="CTextBox" runat="server" PlaceHolder="Type Address here" ></asp:TextBox>
                        </p>
                    </div>
                    <div class="agent_input">
                        <p>
                            Remarks
                       <asp:TextBox ID="Remarks" CssClass="CTextBox" TextMode="MultiLine" runat="server" PlaceHolder="Remarks" MaxLength="200"></asp:TextBox>
                        </p>
                    </div>
                    <div style="margin: 0 0 50px 0">
                        <asp:Label ID="lblResult" runat="server" ForeColor="Red"></asp:Label>
                        <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="Sendbutton" Width="24%"
                            UseSubmitBehavior="false" ValidationGroup="FreeHome" OnClick="btnSend_Click" />
                    </div>


                </div>
            </div>
                  <div class="col-md-3 col-sm-3">
                      </div>

        </div>
    </div>
</asp:Content>
