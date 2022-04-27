<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC02Label.ascx.cs" Inherits="Koutei.UserControl.UC02Label" %>
<div class="UC01FusenDiv" id="divFusenJouhou" runat="server" onclick="openFusenPropertyPopup(this,'btnOpenProperty');">
    <asp:Label ID="lblLabelId" runat="server" CssClass="UC01AnkenIdLbl" ></asp:Label><br />
    <asp:Label ID="lblTitle" runat="server" ></asp:Label>
    <asp:Label ID="lblKouteiId" runat="server" CssClass="DisplayNone"></asp:Label>
    <asp:Label ID="lblKouteiName" runat="server" CssClass="DisplayNone"></asp:Label>
    <asp:Label ID="lblLabelOrder" runat="server" CssClass="DisplayNone"></asp:Label>
    <asp:Label ID="lblStatus" runat="server" CssClass="DisplayNone"></asp:Label>

    <div class="UC01DivHeight">
        <div style="float: right;">
            <asp:Button ID="Button1" runat="server" Text="完了" CssClass="WhiteBackgroundButton1"/>
        </div>
    </div>
</div>

