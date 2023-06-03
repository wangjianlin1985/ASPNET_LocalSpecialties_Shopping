using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CheckUserName : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "text/plain";
        Response.Charset = "UTF-8";
        String userName = Request.QueryString["username"];
        if (BLL.bllUserInfo.getSomeUserInfo(userName) == null)
            Response.Write("<font color='blue'>恭喜你，该用户名还未被注册</font>");
        else
            Response.Write("<font color='red'>不好意思该用户名已被注册!</font>");


         
    }
}