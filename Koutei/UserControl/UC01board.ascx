<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC01board.ascx.cs" Inherits="Koutei.UserControl.UC01board" %>
<!DOCTYPE html>

<html >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<style>
         
         /*#title_bar{
             width:100%;
             height:1%;
             background-color:lightgreen;
         }*/
         body,html{
             margin:0;
         }
      </style>
</head>
<body>
<div id="divFusenList" class="UC02BoardDiv CustomScroll" runat="server">
    <div id="title_bar" runat="server"> <br /></div>
    <div id="divPendingHeader" class="UC02FusenTopDiv DisplayNone" runat="server">
        <div class="UC02InnerTopDiv d-flex justify-content-around ">
           
            <asp:Label ID="Label1" runat="server" class="font-weight-bold" text=""></asp:Label>
            <asp:Label ID="lblPendingHeader" runat="server" class="font-weight-bold" Text="保留中のボード"></asp:Label>
            <asp:Label ID="lblcount" runat="server" class="UC01TaskCount" Text=""></asp:Label>
            <asp:Label ID="lblPendingHeader_ID" runat="server" class="font-weight-bold" Text="0000" Visible="False"></asp:Label>
           
        </div>
        
</div>
<asp:Panel ID="pnlFusen" runat="server" CssClass="UC02FusenInfoDiv"></asp:Panel>
</div>
</body>

</html>
