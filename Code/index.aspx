<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
<title>asp.net���Ϲ��������̳���վ-��ҳ</title>
<link href="css/index.css" rel="stylesheet" type="text/css" /> 
 </head>
<body> 
   <form runat="server">
    <div id="container">
	<div id="banner"><img src="images/logo.gif" /></div>
	<div id="globallink">
		<ul>
			<li><a href="index.aspx">��ҳ</a></li> 
			<li><a href="Front_CosmeticSmallClass_List.aspx"  target="OfficeMain">���ز�����鿴</a></li>
			<li><a href="Front_CosmeticInfo_List.aspx"  target="OfficeMain">���ز���Ϣ</a></li>
			<li><a href="Front_NewInfo_List.aspx"  target="OfficeMain">������Ϣ</a></li>
			<li><a href="UserRegister.aspx"  target="OfficeMain">�û�ע��</a></li>
		</ul>
		<br />
	</div>
	<div id="user_navigate">
	<table style="background-image: url(images/��¼.jpg); " width="100%" border="0" cellpadding="0" cellspacing="0" runat ="server"   id=tabLoading >
    <tr>
        <td align="center" valign=middle>
              <table style ="font-size: 9pt; font-family: ����;"   >
                <tr style ="height: 18px; font-size: 9pt; font-family: ����;">
                    <td style="width:48px;">��Ա����</td>
                    <td style="width:101px">
                        <asp:TextBox ID="txtName" runat="server"  Width="101px"></asp:TextBox></td>  
                    <td style="width:48px">&nbsp;&nbsp;���룺</td>
                    <td style="width: 101px">
                        <asp:TextBox ID="txtPassword" runat="server"  TextMode="Password"  Width="101px"></asp:TextBox></td> 
                   
                    <td style="width: 158px" align="left">
                        <asp:Button ID="btnLoad" runat="server" Text="��¼" OnClick="btnLoad_Click" Width="40px" CausesValidation="False" />&nbsp; </td>
                  
                
                    <td colspan="2">
                        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    </td>
                </tr>
            </table>  
        </td>
    </tr>
</table>
  <table  style="background-image: url(images/��¼.jpg); height:30px;width: 100%; font-size: 9pt; font-family: ����;"   runat =server id=tabLoad visible=false border="0" cellpadding="0" cellspacing="0"  >
                <tr>
                          <td align="center" valign="middle" >
                         
                       <table style ="width: 100%;  font-size: 9pt; font-family: ����;"   >
                <tr>
                    <td colspan="2" style="width: 174px" align="left" valign="middle"  >
                         &nbsp; &nbsp; &nbsp;��ӭ�ͻ�<u><%=Session["username"]%></u>���٣�</td> 
                    <td colspan="2" align="right" valign="middle" >
                     <asp:HyperLink ID="HyperLink1" runat="server" Target="OfficeMain" NavigateUrl="~/MyCart.aspx">�ҵĹ��ﳵ</asp:HyperLink>
                       &nbsp; &nbsp; &nbsp;<asp:HyperLink ID="HyperLink2" runat="server" Target="OfficeMain" NavigateUrl="~/MyOrder.aspx">�ҵĶ���</asp:HyperLink>
                         &nbsp; &nbsp; &nbsp;<asp:HyperLink ID="hpLinkUser" runat="server" Target="OfficeMain" NavigateUrl="~/ModifyUserInfo.aspx">�ҵĸ�����Ϣ</asp:HyperLink>
                         &nbsp; &nbsp; &nbsp; <asp:LinkButton ID="LBQuit" runat="server" Font-Bold="True" ForeColor="Red" Text="�˳�"  onclick="LBQuit_Click" OnClientClick='return confirm("��ȷ���˳���") '>[�˳���½]</asp:LinkButton></td>
                </tr>
</table></td></tr></table>
</div> 
	<div id="main">
	 <iframe id="frame1" src="desk.aspx" name="OfficeMain" width="100%" height="100%" scrolling="yes" marginwidth=0 marginheight=0 frameborder=0 vspace=0 hspace=0 >
	 </iframe>
	</div>
	<div id="footer">
		<p><a href="Admin/M_UserLogin.aspx" target="_top"><font color=red>ϵͳ��¼</font></a></p>
	</div>
</div>
</form>
</body>
</html>
