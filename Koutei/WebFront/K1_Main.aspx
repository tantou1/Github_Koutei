<%@ Page   Language="C#" AutoEventWireup="true" CodeBehind="K1_Main.aspx.cs" Inherits="Koutei.WebFront.K1_Main" 
    EnableEventValidation = "false" MaintainScrollPositionOnPostback="true" ValidateRequest ="False" Async="true"  %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html lang="ja"><head runat="server">    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>    <link href="../Content/bootstrap.min.css" rel="stylesheet" />        <script src="../Scripts/bootstrap.bundle.min.css"></script>  
    <script src="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.min.js"></script>
    <script src="Scripts/jquery.js"></script>
    <asp:PlaceHolder runat="server">        <%: Styles.Render("~/style/StyleBundle2") %>        <%: Styles.Render("~/style/UCStyleBundle") %>        <%: Scripts.Render("~/scripts/ScriptBundle1") %>       </asp:PlaceHolder>  
       
    
  <script>
      window.onload = function() {		
		//ここで本体を表示にさせる
          document.getElementById('div_board').style.display = 'block';
          
            //alert('ページの読み込みが完了したよ！');   
}
</script>
    <title></title>
    <style>
         .bigcheck input {
                width: 17px;
                height: 17px;
                vertical-align: middle;
                cursor: pointer;
                margin-right: 12px;                
        }

    </style>
</head>
  
<body style="background-color:#FFFFFF;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="True" runat="server">
            <Scripts>
                <%--Framework Scripts--%>                
                 <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Path="../Scripts/Common/FixFocus.js" />
            </Scripts>           
        </asp:ScriptManager>
            
             <nav class="navbar navbar-expand-lg navbar-dark" style="background-color:#7CD0FF; height: 45px;">
                <div class="container d-flex justify-content-center""  >
                    <a class="navbar-brand" href="#" style="font-size: 24px;"> 工程ボート</a>                    
                </div>
            </nav>
         
        <div class="container-fluid" >
            <div style="margin-left:10px; margin-top: 15px;">
            <div class="row ">

                <div class="col col-md-auto">
                    <asp:Button ID="btn_SaishinJyouhou" runat="server" Text="最新情報を表示" role="button" CssClass="UC02SaishinjyouhouBtn UC02MoileSaishinjyouhouBtn"
                    onmousedown="getAllDivScrollPosition('pnlFusenMain','MASTER');"  OnClientClick="displayLoadingModal();" /> <br />
                     
                </div>

                <div class="col col-md-auto">
                    <asp:Button ID="btnFusenTsuika" runat="server" Text="＋タスクを追加" CssClass="UC02FusentSuikaBtn UC02MobileFusentSuikaBtn ml-3" role="button"
                    onmousedown="getAllDivScrollPosition('pnlFusenMain','MASTER');"  OnClientClick="displayLoadingModal();" OnClick="btnFusenTsuika_Click"/> <br />
                     
                </div>

                 <asp:UpdatePanel ID="UpdTaskTsuika" runat="server" UpdateMode="Conditional" >
                    <ContentTemplate>
                        <asp:Panel ID="pnlTask" runat="server"></asp:Panel>               
                    </ContentTemplate>
                </asp:UpdatePanel>

                <div class="col col-md-auto align-content-center mt-2">
                    <asp:CheckBox ID="chk_santo" runat="server" AutoPostBack="True" Text="先頭工程のみ表示" CssClass="bigcheck" OnCheckedChanged="chk_santo_CheckedChanged" Onchange="displayLoadingModal();"/>
                </div>  
            </div>
        </div>    
     
       
        <div class="row mx-0 " id="div_board" runat="server" style="display:none;">
        <asp:UpdatePanel ID="updFusenMain" runat="server" UpdateMode="Conditional" >
            <ContentTemplate>
                <asp:Panel ID="pnlPending" runat="server" class="M02PendingDiv"></asp:Panel>
                <asp:Panel ID="pnlFusenMain" runat="server" class="M02FusenMainDiv">
                   
                </asp:Panel>
                <%--<asp:HiddenField ID="hdnSourceId" runat="server" />
                <asp:HiddenField ID="hdnTargetId" runat="server" />
                <asp:HiddenField ID="hdnFusenId" runat="server" />
                <asp:HiddenField ID="hdnTantouId" runat="server" />
                <asp:HiddenField ID="hdnWorkDate" runat="server" />
                <asp:HiddenField ID="hdnNextSiblingFusenId" runat="server" />
                <asp:HiddenField ID="hdnTodayDate" runat="server" />
                <span class="DisplayNone">
                    <asp:Literal ID="lblhdnTantouName" runat="server"></asp:Literal>
                </span>--%>
             </ContentTemplate>
        </asp:UpdatePanel>
            
        </div>
    </div>        
        
        <asp:UpdatePanel ID="updShinkiPopup" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Button ID="btnShinkiPopup" runat="server" Text="Button" Style="display: none" />
                    <asp:ModalPopupExtender ID="mpeShinkiPopup" runat="server" TargetControlID="btnShinkiPopup"
                        PopupControlID="pnlShinkiPopupScroll" BackgroundCssClass="PopupModalBackground" BehaviorID="pnlShinkiPopupScroll"
                        RepositionMode="RepositionOnWindowResize">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="pnlShinkiPopupScroll" runat="server" Style="display: none;height:100%;overflow:hidden;" CssClass="PopupScrollDiv">
                        <asp:Panel ID="pnlShinkiPopup" runat="server" BorderStyle="None">
                            <iframe id="ifShinkiPopup" runat="server" scrolling="yes"  style="height:100vh;width:100vw;border:none;"></iframe>
                            <div style="display:none;">
                                <asp:Button ID="btn_ClosePopup" runat="server" Text="Button" CssClass="" OnClick="btn_ClosePopup_Click" />
                                <asp:Button ID="btn_SavePopup" runat="server" Text="Button" CssClass="" />
                            </div>
                        </asp:Panel>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
    </form>
</body>
</html>
