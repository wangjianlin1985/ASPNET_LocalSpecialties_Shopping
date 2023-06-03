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

namespace shuangyulin.Admin
{
    public partial class M_EditNewInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                if (Request["newsId"] != null)
                {
                    LoadData();
                }
            }
        }
        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "newsId")))
            {
                ENTITY.NewInfo newInfo = BLL.bllNewInfo.getSomeNewInfo(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "newsId")));
                newTitle.Value = newInfo.newTitle;
                newBody.Value = newInfo.newBody;
                publishDate.Text = newInfo.publishDate.ToShortDateString();
            }
        }

        protected void BtnNewInfoSave_Click(object sender, EventArgs e)
        {
            ENTITY.NewInfo newInfo = new ENTITY.NewInfo();
            newInfo.newTitle = newTitle.Value;
            newInfo.newBody = newBody.Value;
            newInfo.publishDate = Convert.ToDateTime(publishDate.Text);
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "newsId")))
            {
                newInfo.newsId = int.Parse(Request["newsId"]);
                if (BLL.bllNewInfo.EditNewInfo(newInfo))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"M_EditNewInfo.aspx?newsId=" + Request["newsId"] + "\"} else  {location.href=\"M_NewInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllNewInfo.AddNewInfo(newInfo))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"M_EditNewInfo.aspx\"} else  {location.href=\"M_NewInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_NewInfoList.aspx");
        }
    }
}

