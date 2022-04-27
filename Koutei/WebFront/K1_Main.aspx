<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="K1_Main.aspx.cs" Inherits="Koutei.WebFront.K1_Main" EnableEventValidation = "false" MaintainScrollPositionOnPostback="true" ValidateRequest ="False" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%--<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server" >--%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml"><head runat="server"><meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>    <link href="../Content/bootstrap.min.css" rel="stylesheet" />        <script src="../Scripts/bootstrap.bundle.min.css"></script>
   <asp:PlaceHolder runat="server">             <%: Styles.Render("~/style/StyleBundle2") %>             <%: Styles.Render("~/style/UCStyleBundle") %>        <%: Scripts.Render("~/scripts/ScriptBundle1") %>        </asp:PlaceHolder>
    <title></title>
   
</head>
<body style="background-color:lightgray;">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="True" runat="server">
            <Scripts>
                <%--Framework Scripts--%>
                
                <asp:ScriptReference Path="../Scripts/Common/FixFocus.js" />

            </Scripts>
        </asp:ScriptManager>
        <div style="margin-left:4px;">
             <asp:Button ID="btnFusenTsuika" runat="server" Text="＋タスクを追加" CssClass="UC02FusentSuikaBtn UC02MobileFusentSuikaBtn ml-3" role="button"
            onmousedown="getAllDivScrollPosition('pnlFusenMain','MASTER');" OnClick="btnFusenTsuika_Click" /> <br />
        </div>
        <div class="row mx-0 ">
        <asp:UpdatePanel ID="updFusenMain" runat="server" UpdateMode="Conditional">
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
        <asp:UpdatePanel ID="updShinkiPopup" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Button ID="btnShinkiPopup" runat="server" Text="Button" Style="display: none" />
                    <asp:ModalPopupExtender ID="mpeShinkiPopup" runat="server" TargetControlID="btnShinkiPopup"
                        PopupControlID="pnlShinkiPopupScroll" BackgroundCssClass="PopupModalBackground" BehaviorID="pnlShinkiPopupScroll"
                        RepositionMode="RepositionOnWindowResize">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="pnlShinkiPopupScroll" runat="server" Style="display: none;height:100%;overflow:hidden;" CssClass="PopupScrollDiv">
                        <asp:Panel ID="pnlShinkiPopup" runat="server">
                            <iframe id="ifShinkiPopup" runat="server" scrolling="yes"  style="height:100vh;width:100vw;"></iframe>
                            <asp:Button ID="btn_ClosePopup" runat="server" Text="Button" CssClass="" OnClick="btn_ClosePopup_Click" />
                            <asp:Button ID="btn_SavePopup" runat="server" Text="Button" CssClass="" />
                        </asp:Panel>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
    </form>
</body>
</html>
