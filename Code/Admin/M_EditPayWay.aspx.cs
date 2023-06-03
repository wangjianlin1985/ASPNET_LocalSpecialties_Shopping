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
    public partial class M_EditPayWay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                if (Request["payWayId"] != null)
                {
                    LoadData();
                }
            }
        }
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "payWayId")))
            {
                ENTITY.PayWay payWay = BLL.bllPayWay.getSomePayWay(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "payWayId")));
                payWayName.Value = payWay.payWayName;
            }
        }

        protected void BtnPayWaySave_Click(object sender, EventArgs e)
        {
            ENTITY.PayWay payWay = new ENTITY.PayWay();
            payWay.payWayName = payWayName.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "payWayId")))
            {
                payWay.payWayId = int.Parse(Request["payWayId"]);
                if (BLL.bllPayWay.EditPayWay(payWay))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"M_EditPayWay.aspx?payWayId=" + Request["payWayId"] + "\"} else  {location.href=\"M_PayWayList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllPayWay.AddPayWay(payWay))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"M_EditPayWay.aspx\"} else  {location.href=\"M_PayWayList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_PayWayList.aspx");
        }
    }
}

