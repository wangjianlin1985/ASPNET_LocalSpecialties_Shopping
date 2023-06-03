<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
<title>asp.net网上购物网上商城网站-首页</title>
<link href="css/index.css" rel="stylesheet" type="text/css" /> 
 </head>
<body> 
   <form runat="server">
    <div id="container">
	<div id="banner"><img src="images/logo.gif" /></div>
	<div id="globallink">
		<ul>
			<li><a href="index.aspx">首页</a></li> 
			<li><a href="Front_CosmeticSmallClass_List.aspx"  target="OfficeMain">土特产分类查看</a></li>
			<li><a href="Front_CosmeticInfo_List.aspx"  target="OfficeMain">土特产信息</a></li>
			<li><a href="Front_NewInfo_List.aspx"  target="OfficeMain">新闻信息</a></li>
			<li><a href="UserRegister.aspx"  target="OfficeMain">用户注册</a></li>
		</ul>
		<br />
	</div>
	<div id="user_navigate">
	<table style="background-image: url(images/登录.jpg); " width="100%" border="0" cellpadding="0" cellspacing="0" runat ="server"   id=tabLoading >
    <tr>
        <td align="center" valign=middle>
              <table style ="font-size: 9pt; font-family: 宋体;"   >
                <tr style ="height: 18px; font-size: 9pt; font-family: 宋体;">
                    <td style="width:48px;">会员名：</td>
                    <td style="width:101px">
                        <asp:TextBox ID="txtName" runat="server"  Width="101px"></asp:TextBox></td>  
                    <td style="width:48px">&nbsp;&nbsp;密码：</td>
                    <td style="width: 101px">
                        <asp:TextBox ID="txtPassword" runat="server"  TextMode="Password"  Width="101px"></asp:TextBox></td> 
                   
                    <td style="width: 158px" align="left">
                        <asp:Button ID="btnLoad" runat="server" Text="登录" OnClick="btnLoad_Click" Width="40px" CausesValidation="False" />&nbsp; </td>
                  
                
                    <td colspan="2">
                        &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                    </td>
                </tr>
            </table>  
        </td>
    </tr>
</table>
  <table  style="background-image: url(images/登录.jpg); height:30px;width: 100%; font-size: 9pt; font-family: 宋体;"   runat =server id=tabLoad visible=false border="0" cellpadding="0" cellspacing="0"  >
                <tr>
                          <td align="center" valign="middle" >
                         
                       <table style ="width: 100%;  font-size: 9pt; font-family: 宋体;"   >
                <tr>
                    <td colspan="2" style="width: 174px" align="left" valign="middle"  >
                         &nbsp; &nbsp; &nbsp;欢迎客户<u><%=Session["username"]%></u>光临！</td> 
                    <td colspan="2" align="right" valign="middle" >
                     <asp:HyperLink ID="HyperLink1" runat="server" Target="OfficeMain" NavigateUrl="~/MyCart.aspx">我的购物车</asp:HyperLink>
                       &nbsp; &nbsp; &nbsp;<asp:HyperLink ID="HyperLink2" runat="server" Target="OfficeMain" NavigateUrl="~/MyOrder.aspx">我的订单</asp:HyperLink>
                         &nbsp; &nbsp; &nbsp;<asp:HyperLink ID="hpLinkUser" runat="server" Target="OfficeMain" NavigateUrl="~/ModifyUserInfo.aspx">我的个人信息</asp:HyperLink>
                         &nbsp; &nbsp; &nbsp; <asp:LinkButton ID="LBQuit" runat="server" Font-Bold="True" ForeColor="Red" Text="退出"  onclick="LBQuit_Click" OnClientClick='return confirm("你确定退出吗？") '>[退出登陆]</asp:LinkButton></td>
                </tr>
</table></td></tr></table>
</div> 
	<div id="main">
	 <iframe id="frame1" src="desk.aspx" name="OfficeMain" width="100%" height="100%" scrolling="yes" marginwidth=0 marginheight=0 frameborder=0 vspace=0 hspace=0 >
	 </iframe>
	</div>
	<div id="footer">
		<p><a href="Admin/M_UserLogin.aspx" target="_top"><font color=red>系统登录</font></a></p>
	</div>
</div>
</form>
</body>
</html>
