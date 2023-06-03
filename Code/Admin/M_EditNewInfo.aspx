<%@ Page Language="C#" AutoEventWireup="true" CodeFile="M_EditNewInfo.aspx.cs" Inherits="shuangyulin.Admin.M_EditNewInfo" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script type="text/javascript" src="JavaScript/Admin.js"></script>
    <script type="text/javascript" src="JavaScript/date.js"></script>
    <script type="text/javascript">
        function CheckIn() {
            var re = /^[0-9]+.?[0-9]*$/;
            var resc=/^[1-9]+[0-9]*]*$/ ;
            var newTitle = document.getElementById("newTitle").value;
            if (newTitle == "") {
                alert("���������ű���...");
                document.getElementById("newTitle").focus();
                return false;
            }

            var newBody = document.getElementById("newBody").value;
            if (newBody == "") {
                alert("��������������...");
                document.getElementById("newBody").focus();
                return false;
            }

            var publishDate = document.getElementById("publishDate").value;
            if (publishDate == "") {
                alert("�����뷢������...");
                document.getElementById("publishDate").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">������Ϣ���� �����༭������Ϣ</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ���ű��⣺</td>
                    <td width="650px;">
                         <input id="newTitle" type="text"   style="width:500px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>���������ű��⣡</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �������ݣ�</td>
                    <td width="650px;">
                         <textarea id="newBody"  runat="server" rows="8" cols="80"></textarea><span class="WarnMes">*</span>�������������ݣ�</td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  �������ڣ�</td>
                    <td width="650px;">
                          <asp:TextBox ID="publishDate"  runat="server" Width="112px"
                              onclick="javascript:HS_setDate(this);"></asp:TextBox></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnNewInfoSave" runat="server" Text=" ������Ϣ "
                            OnClientClick="return CheckIn()" onclick="BtnNewInfoSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="ȡ��" onclick="Button1_Click" /></td>
                </tr>
            </table
    </div>
    </form>
</body>
</html>

