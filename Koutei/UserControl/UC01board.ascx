<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC01board.ascx.cs" Inherits="Koutei.UserControl.UC01board" %>
<div id="divFusenList" class="UC02BoardDiv CustomScroll" runat="server">
    
    <div id="divPendingHeader" class="UC02FusenTopDiv DisplayNone" runat="server">
        <div class="UC02InnerTopDiv text-center d-flex justify-content-center">
           
            <asp:Label ID="lblPendingHeader" runat="server" class="font-weight-bold" Text="保留中のボード"></asp:Label>
            <asp:Label ID="lblPendingHeader_ID" runat="server" class="font-weight-bold" Text="0000" Visible="False"></asp:Label>
           
        </div>
        
</div>
<asp:Panel ID="pnlFusen" runat="server" CssClass="UC02FusenInfoDiv"></asp:Panel>
</div>
