<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="K2_Kouteipopup.aspx.cs" Inherits="Koutei.WebFront.K2_Kouteipopup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>    <link href="../Content/bootstrap.min.css" rel="stylesheet" />        <script src="../Scripts/bootstrap.bundle.min.css"></script>
   <asp:PlaceHolder runat="server">            <%: Styles.Render("~/style/StyleBundle2") %>             <%: Styles.Render("~/style/UCStyleBundle") %>       <%: Scripts.Render("~/scripts/ScriptBundle1") %>        </asp:PlaceHolder>
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
<body class="bg-transparent">

    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="True" runat="server">
            <Scripts>
                <%--Framework Scripts--%>
                
                <asp:ScriptReference Path="../Scripts/Common/FixFocus.js" />

            </Scripts>
        </asp:ScriptManager>

        <asp:UpdatePanel ID="updBody" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div id="Div_Body" runat="server" style="background-color: transparent; padding-top: 100px; min-height: 100%;">

                    <div style="max-width: 400px; margin-left: auto; margin-right: auto; background-color: white; padding: 10px 0px 0px 0px; border-radius:5px;">
                        <div class="ml-3">
                            <asp:TextBox ID="TB_taskname" runat="server" CssClass="form-control mb-3" Width="300px" Height="30px" placeholder="タスク名"></asp:TextBox>
                            <asp:CheckBoxList ID="CheckBoxList" runat="server" CssClass="bigcheck">

                            </asp:CheckBoxList>
                            <div class="">
                                <asp:Button ID="BT_Cancel" runat="server" Text="キャンセル" CssClass="WhiteBackgroundButton mb-3 " Width="100px" OnClick="BT_Cancel_Click"/>
                                <asp:Button ID="BT_Save" runat="server" Text="追加" CssClass="BlueBackgroundButton mb-3 " autopostback="false" Width="100px" OnClick="BT_Save_Click" MaintainScrollPositionOnPostBack="true" />
                            </div>
                            
                        </div>

                        </div>
                    </div>
                
                </ContentTemplate>
            </asp:UpdatePanel>
        
        <asp:HiddenField ID="hdnHome" runat="server" />

    </form>
</body>
</html>
