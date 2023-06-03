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
        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
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
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"M_EditPayWay.aspx?payWayId=" + Request["payWayId"] + "\"} else  {location.href=\"M_PayWayList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllPayWay.AddPayWay(payWay))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"M_EditPayWay.aspx\"} else  {location.href=\"M_PayWayList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_PayWayList.aspx");
        }
    }
}

