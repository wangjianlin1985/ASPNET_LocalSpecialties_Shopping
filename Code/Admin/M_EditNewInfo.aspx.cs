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
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
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
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"M_EditNewInfo.aspx?newsId=" + Request["newsId"] + "\"} else  {location.href=\"M_NewInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllNewInfo.AddNewInfo(newInfo))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"M_EditNewInfo.aspx\"} else  {location.href=\"M_NewInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_NewInfoList.aspx");
        }
    }
}

