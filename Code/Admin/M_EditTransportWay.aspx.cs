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
    public partial class M_EditTransportWay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                if (Request["transportId"] != null)
                {
                    LoadData();
                }
            }
        }
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "transportId")))
            {
                ENTITY.TransportWay transportWay = BLL.bllTransportWay.getSomeTransportWay(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "transportId")));
                transportName.Value = transportWay.transportName;
            }
        }

        protected void BtnTransportWaySave_Click(object sender, EventArgs e)
        {
            ENTITY.TransportWay transportWay = new ENTITY.TransportWay();
            transportWay.transportName = transportName.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "transportId")))
            {
                transportWay.transportId = int.Parse(Request["transportId"]);
                if (BLL.bllTransportWay.EditTransportWay(transportWay))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"M_EditTransportWay.aspx?transportId=" + Request["transportId"] + "\"} else  {location.href=\"M_TransportWayList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllTransportWay.AddTransportWay(transportWay))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"M_EditTransportWay.aspx\"} else  {location.href=\"M_TransportWayList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_TransportWayList.aspx");
        }
    }
}

