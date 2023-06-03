<%@ Page Language="C#" AutoEventWireup="true" CodeFile="M_EditUserInfo.aspx.cs" Inherits="shuangyulin.Admin.M_EditUserInfo" %>
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
            var username = document.getElementById("username").value;
            if (username == "") {
                alert("�������û���...");
                document.getElementById("username").focus();
                return false;
            }

            var password = document.getElementById("password").value;
            if (password == "") {
                alert("�������½����...");
                document.getElementById("password").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">�û���Ϣ���� �����༭�û���Ϣ</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �û�����</td>
                    <td width="650px;">
                         <input id="username" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�������û�����</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��½���룺</td>
                    <td width="650px;">
                         <input id="password" type="text"   style="width:200px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>�������½���룡</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��ʵ������</td>
                    <td width="650px;">
                         <input id="realName" type="text"   style="width:100px;" runat="server" maxlength="25"/></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ���ڳ��У�</td>
                    <td width="650px;">
                         <input id="city" type="text"   style="width:200px;" runat="server" maxlength="25"/></td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    ֤�����</td>
                    <td width="650px;">
                         <asp:DropDownList ID="cardTypeObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ֤�����룺</td>
                    <td width="650px;">
                         <input id="cardNumber" type="text"   style="width:500px;" runat="server" maxlength="25"/></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��ϵ�绰��</td>
                    <td width="650px;">
                         <input id="telephone" type="text"   style="width:200px;" runat="server" maxlength="25"/></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   Email��</td>
                    <td width="650px;">
                         <input id="emailAddress" type="text"   style="width:200px;" runat="server" maxlength="25"/></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �û�ͷ��</td>
                    <td width="650px;">
                       <table cellpadding="0px" cellspacing="0px" width="90%">
                        <tr><td width="400px">
                         ͼƬ·����<asp:TextBox ID="userPhoto" runat="server" ReadOnly="True" Width="228px" Enabled="False"></asp:TextBox> &nbsp; &nbsp; &nbsp
                         <br />
                         <br />
                         �ϴ�ͼƬ��<asp:FileUpload ID="UserPhotoUpload" runat="server" Width="237px" />&nbsp;
                         <asp:Button ID="Btn_UserPhotoUpload" runat="server" Text="�ϴ�" OnClick="Btn_UserPhotoUpload_Click" /></td><td>
                         <asp:Image ID="UserPhotoImage" runat="server" Height="90px" Width="99px" />
                         </td></tr>
                       </table>
                    </td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ��ϵ��ַ��</td>
                    <td width="650px;">
                         <input id="address" type="text"   style="width:500px;" runat="server" maxlength="25"/></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �������룺</td>
                    <td width="650px;">
                         <input id="postcode" type="text"   style="width:200px;" runat="server" maxlength="25"/></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnUserInfoSave" runat="server" Text=" ������Ϣ "
                            OnClientClick="return CheckIn()" onclick="BtnUserInfoSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="ȡ��" onclick="Button1_Click" /></td>
                </tr>
            </table
    </div>
    </form>
</body>
</html>

