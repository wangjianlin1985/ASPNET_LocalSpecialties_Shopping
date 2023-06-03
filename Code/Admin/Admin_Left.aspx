<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Left.aspx.cs" Inherits="WebSystem.Admin.Admin_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script src="JavaScript/Admin.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="LeftNote">
    <img src="Images/MenuTop.jpg"/><br /><img src="images/menu_topline.gif" alt=""/>
    
        <!--
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;土特产大类别管理</div>
        <div class="MenuNote" style="display:none;" id="CosmeticBigClassDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="M_EditCosmeticBigClass.aspx" target="main">添加土特产大类别</a></li>
                <li><a href="M_CosmeticBigClassList.aspx" target="main">土特产大类别查询</a></li> 
            </ul>
        </div>
        -->


          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;土特产分类管理</div>
        <div class="MenuNote" style="display:none;" id="CosmeticSmallClassDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="M_EditCosmeticSmallClass.aspx" target="main">添加土特产分类</a></li>
                <li><a href="M_CosmeticSmallClassList.aspx" target="main">土特产分类查询</a></li> 
            </ul>
        </div>
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;土特产信息管理</div>
        <div class="MenuNote" style="display:none;" id="CosmeticInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="M_EditCosmeticInfo.aspx" target="main">添加土特产信息</a></li>
                <li><a href="M_CosmeticInfoList.aspx" target="main">土特产信息查询</a></li> 
            </ul>
        </div>
        
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;用户信息管理</div>
          <div class="MenuNote" style="display:none;" id="UserInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="M_EditUserInfo.aspx" target="main">添加用户信息</a></li>
                <li><a href="M_UserInfoList.aspx" target="main">用户信息查询</a></li> 
            </ul>
            </div>
        
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;订单信息管理</div>
        <div class="MenuNote" style="display:none;" id="OrderInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL"> 
                <li><a href="M_OrderInfoList.aspx" target="main">订单信息查询</a></li> 
            </ul>
        </div>
        
         <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;订单详细项目管理</div>
        <div class="MenuNote" style="display:none;" id="OrderDetailDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li> 
                <li><a href="M_OrderDetailList.aspx" target="main">订单详细项目查询</a></li> 
            </ul>
        </div>
        
         <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;新闻信息管理</div>
        <div class="MenuNote" style="display:none;" id="NewsDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="M_EditNewInfo.aspx" target="main">添加新闻信息</a></li>
                <li><a href="M_NewInfoList.aspx" target="main">新闻信息查询</a></li> 
            </ul>
        </div>
 
        
        
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;付款方式管理</div>
        <div class="MenuNote" style="display:none;" id="PayWayDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="M_EditPayWay.aspx" target="main">添加付款方式</a></li>
                <li><a href="M_PayWayList.aspx" target="main">付款方式查询</a></li> 
            </ul>
        </div>
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;运送方式管理</div>
        <div class="MenuNote" style="display:none;" id="TransportWayDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="M_EditTransportWay.aspx" target="main">添加运送方式</a></li>
                <li><a href="M_TransportWayList.aspx" target="main">运送方式查询</a></li> 
            </ul>
        </div>
        </div>
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;证件类型管理</div>
        <div class="MenuNote" style="display:none;" id="CardTypeDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="M_EditCardType.aspx" target="main">添加证件类型</a></li>
                <li><a href="M_CardTypeList.aspx" target="main">证件类型查询</a></li> 
            </ul>
        </div>
        
         
          
 
 
        
       <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;系统信息管理</div>
        <div class="MenuNote" style="display:none;" id="sysDiv"  runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
           <li><a href="M_AddUsersInfo.aspx" target="main">添加管理员</a></li>
             <li><a href="M_UsersList.aspx" target="main">管理员列表</a></li>           
            </ul>
        </div>
        <asp:HiddenField ID="Hvalue" runat="server" />
    </div>
    </form>
</body>
</html>
