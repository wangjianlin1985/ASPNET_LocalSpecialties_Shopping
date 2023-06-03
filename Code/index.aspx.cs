using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] != null)
        {
            this.tabLoading.Visible = false;
            this.tabLoad.Visible = true;
        }
    }
    protected void btnLoad_Click(object sender, EventArgs e)
    {
        //获取到用户名和密码
        String username = this.txtName.Text;
        String password = this.txtPassword.Text;
        bool success = BLL.bllUserInfo.ulogin(username,password);
        if (success)
        {
            Session["username"] = username;
            Response.Redirect("index.aspx");
        }
        else
        {
            Response.Write("<script>alert('用户名或密码错误');</script>");
        }
    }

    protected void LBQuit_Click(object sender, EventArgs e)
    {
        Common.SetMes.RemoveSession("username"); 
        Common.ShowMessage.RefreshPage(Page, "throw", "top", "index.aspx");
    }
}
