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
    public partial class M_EditOrderState : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                if (Request["stateId"] != null)
                {
                    LoadData();
                }
            }
        }
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "stateId")))
            {
                ENTITY.OrderState orderState = BLL.bllOrderState.getSomeOrderState(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "stateId")));
                stateName.Value = orderState.stateName;
            }
        }

        protected void BtnOrderStateSave_Click(object sender, EventArgs e)
        {
            ENTITY.OrderState orderState = new ENTITY.OrderState();
            orderState.stateName = stateName.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "stateId")))
            {
                orderState.stateId = int.Parse(Request["stateId"]);
                if (BLL.bllOrderState.EditOrderState(orderState))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"M_EditOrderState.aspx?stateId=" + Request["stateId"] + "\"} else  {location.href=\"M_OrderStateList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllOrderState.AddOrderState(orderState))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"M_EditOrderState.aspx\"} else  {location.href=\"M_OrderStateList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_OrderStateList.aspx");
        }
    }
}

