<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC02Label.ascx.cs" Inherits="Koutei.UserControl.UC02Label" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script>
  function playSound() {
  var audio = new Audio('../sound/歓声と拍手2.mp3');
      audio.play();
    }    
</script>

<body >
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
    <div class="text-center">
            <asp:Image ID="Image" runat="server" Width="100" Height="100" class="rounded" />       
        
        <br />
    </div>
    <div class="UC01DivHeight">        
        <div style="float: right;">
            <asp:Button ID="bt_end" runat="server" Text="完了" CssClass="WhiteBackgroundButton1" OnClick="Button1_Click" OnClientClick="playSound();displayLoadingModal();"/>
        </div>
    </div>
</div>
</body>
</html>

