<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC03Main.ascx.cs" Inherits="Koutei.UserControl.UC03Main" %>
<!DOCTYPE html>
<html >
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<script>
  function playSound() {
  var audio = new Audio('../sound/歓声と拍手2.mp3');
      audio.play();
    }    
</script>

<body >
    <div class="container-fluid" >
        <div style="margin-left:4px;">
            <div class="row ">
                <div class="col col-md-auto">
                    <asp:Button ID="btnFusenTsuika" runat="server" Text="＋タスクを追加" CssClass="UC02FusentSuikaBtn UC02MobileFusentSuikaBtn ml-3" role="button"
                    onmousedown="getAllDivScrollPosition('pnlFusenMain','MASTER');"  OnClientClick="displayLoadingModal();" OnClick="btnFusenTsuika_Click" /> <br />
                     
                </div>
                <%--<div class="col col-md-auto align-content-center mt-2">
                    <asp:CheckBox ID="chk_santo" runat="server" AutoPostBack="True" Text="先頭工程のみ表示" CssClass="bigcheck" onchange="displayLoadingModal();" OnCheckedChanged="chk_santo_CheckedChanged"/>
                </div>  --%>
            </div>
            </div>   
        </div>
    </body>

</html>