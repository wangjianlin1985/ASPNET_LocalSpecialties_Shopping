<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Front_UserInfo_Details.aspx.cs" Inherits="shuangyulin.Front.Front_UserInfo_Details" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <link href="Admin/Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="Admin/JavaScript/Jquery.js"></script>
    <script type="text/javascript" src="Admin/JavaScript/Admin.js"></script>
    <script type="text/javascript" src="Admin/JavaScript/date.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">�û���Ϣ���� �����鿴�û���Ϣ</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �û�����</td>
                    <td width="650px;">
                       <asp:Literal ID="username" runat="server" /></td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    ��½���룺</td>
                    <td width="650px;">
                         <asp:Literal ID="password" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    ��ʵ������</td>
                    <td width="650px;">
                         <asp:Literal ID="realName" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    ���ڳ��У�</td>
                    <td width="650px;">
                         <asp:Literal ID="city" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    ֤�����</td>
                    <td width="650px;">
                         <asp:Literal ID="cardTypeObj" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    ֤�����룺</td>
                    <td width="650px;">
                         <asp:Literal ID="cardNumber" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    ��ϵ�绰��</td>
                    <td width="650px;">
                         <asp:Literal ID="telephone" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    Email��</td>
                    <td width="650px;">
                         <asp:Literal ID="emailAddress" runat="server" /></td>
                </tr>
                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �û�ͷ��</td>
                    <td width="650px;">
                       <table cellpadding="0px" cellspacing="0px" width="90%">
                        <tr><td>
                         <asp:Image ID="UserPhotoImage" runat="server"   Width="200px" />
                         </td></tr>
                       </table>
                    </td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    ��ϵ��ַ��</td>
                    <td width="650px;">
                         <asp:Literal ID="address" runat="server" /></td>
                </tr>
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    �������룺</td>
                    <td width="650px;">
                         <asp:Literal ID="postcode" runat="server" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <input type=button onclick="javascript:history.back();" value="����" /></td>
                </tr>
            </table
    </div>
    </form>
</body>
</html>

