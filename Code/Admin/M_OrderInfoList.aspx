<%@ Page Language="C#" AutoEventWireup="true" CodeFile="M_OrderInfoList.aspx.cs" Inherits="shuangyulin.Admin.M_OrderInfoList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>������Ϣ�б�</title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
   <script src="JavaScript/Admin.js" type="text/javascript"></script>
   <script type="text/javascript" src="JavaScript/calendar.js"></script>
</head>
<body>
   <form id="form1" runat="server">
    <div class="div_All">
    <div class="Body_Title">������Ϣ���� ����������Ϣ�б�</div>
     <div class="Body_Search">
        �������&nbsp;&nbsp;<asp:TextBox ID="orderNo" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        �ջ��˵绰&nbsp;&nbsp;<asp:TextBox ID="telephone" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        ����״̬&nbsp;&nbsp;<asp:DropDownList ID="orderState" runat="server"></asp:DropDownList>  &nbsp;&nbsp;
        �û���&nbsp;&nbsp;<asp:TextBox ID="username" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="��ѯ" onclick="btnSearch_Click" /> 
    <asp:Repeater ID="RpOrderInfo" runat="server" onitemcommand="RpOrderInfo_ItemCommand">
        <HeaderTemplate>
            <table cellpadding="2" cellspacing="1" class="Admin_Table">
                <thead>
                    <tr class="Admin_Table_Title">
                        <th>ѡ��</th> 
                        <th>�������</th>
                        <th>��ʵ����</th>
                        <th>�ջ��˵绰</th>
                      
                        <th>��������</th>
                        <th>�µ�ʱ��</th>
                        <th>����״̬</th>
                        <th>���ʽ</th>
                        <th>���ͷ�ʽ</th>
                        <th>�û���</th>
                        <th>����</th> 
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center"><input type="checkbox" value='<%#Eval("orderNo") %>' name="CheckMes" id="DelChecked"/></td>
                <td align="center"><a href="OrderDetail.aspx?orderNo=<%#Eval("orderNo")%>"><%#Eval("orderNo")%></a> </td>
                <td align="center"><%#Eval("realName")%> </td>
                <td align="center"><%#Eval("telephone")%> </td>
                
                <td align="center"><%#Eval("postcode")%> </td>
                  <td align="center"><%# Convert.ToDateTime(Eval("orderTime")).ToShortDateString() %></td>
                  <td align="center"><%#GetOrderStateorderState(Eval("orderState").ToString())%></td>
                  <td align="center"><%#GetPayWaypayWay(Eval("payWay").ToString())%></td>
                  <td align="center"><%#GetTransportWaytrasportWay(Eval("trasportWay").ToString())%></td>
                <td align="center"><%#Eval("username")%> </td>
                <td align="center"><a href="M_EditOrderInfo.aspx?orderNo=<%#Eval("orderNo") %>"><img src="Images/MillMes_ICO.gif" alt="�޸���Ϣ..." /></a><asp:ImageButton class="DelClass" ID="IBDelClass" runat="server" CommandArgument='<%#Eval("orderNo")%>' CommandName="Del" ImageUrl="Images/Delete.gif"  ToolTip="ɾ������Ϣ..."/></td>
             </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>

    <div class="Body_Search">
        <div class="page_Left">
            <input id="BtnAllSelect" type="button" value="ȫѡ" />&nbsp;
            <asp:Button ID="BtnAllDel" runat="server" Text=" ɾ��ѡ�� " onclick="BtnAllDel_Click" />
        </div>
        <div class="page_Right">
        <span class="pageBtn">   <asp:Label runat="server" ID="PageMes"></asp:Label></span>
            <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn" 
                onclick="LBHome_Click">[��ҳ]</asp:LinkButton>
            <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
                onclick="LBUp_Click">[��һҳ]</asp:LinkButton>
            <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn" 
                onclick="LBNext_Click">[��һҳ]</asp:LinkButton>
            <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn" 
                onclick="LBEnd_Click">[βҳ]</asp:LinkButton>
        </div>
    </div>
    </div>
    <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
    <asp:HiddenField ID="HWhere" runat="server" Value=""/>
    <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
    <asp:HiddenField ID="HPageSize" runat="server" Value="6"/>
    <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
    </form>
</body>
</html>
