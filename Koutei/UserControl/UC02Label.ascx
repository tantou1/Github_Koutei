<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC02Label.ascx.cs" Inherits="Koutei.UserControl.UC02Label" %>

<div class="UC01FusenDiv" id="divFusenJouhou" runat="server">
    <div>
        <asp:Label ID="lblLabelId" runat="server" CssClass="DisplayNone" ></asp:Label>
        <asp:Label ID="lblAnkenId" runat="server" CssClass="UC01AnkenIdLbl" ></asp:Label><br />
        <asp:Label ID="lblTitle" runat="server" ></asp:Label><br />
        <asp:Label ID="lblKouteiId" runat="server" CssClass="DisplayNone"></asp:Label>
        <asp:Label ID="lblKouteiName" runat="server" CssClass="DisplayNone"></asp:Label>
        <asp:Label ID="lblLabelOrder" runat="server" CssClass="DisplayNone"></asp:Label>    
        <asp:Label ID="lblStatus" runat="server" CssClass="DisplayNone"></asp:Label>
        <asp:Label ID="lbId" runat="server" CssClass="DisplayNone" />
    </div>
    <div class="UC01DivHeight">
        <div style="float: right;">
            <asp:Button ID="bt_end" runat="server" Text="完了" CssClass="WhiteBackgroundButton1" OnClick="Button1_Click"/>
        </div>
    </div>
</div>

