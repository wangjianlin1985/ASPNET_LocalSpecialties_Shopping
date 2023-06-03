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
    public partial class M_EditCardType : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                if (Request["cardTypeId"] != null)
                {
                    LoadData();
                }
            }
        }
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "cardTypeId")))
            {
                ENTITY.CardType cardType = BLL.bllCardType.getSomeCardType(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "cardTypeId")));
                cardTypeName.Value = cardType.cardTypeName;
            }
        }

        protected void BtnCardTypeSave_Click(object sender, EventArgs e)
        {
            ENTITY.CardType cardType = new ENTITY.CardType();
            cardType.cardTypeName = cardTypeName.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "cardTypeId")))
            {
                cardType.cardTypeId = int.Parse(Request["cardTypeId"]);
                if (BLL.bllCardType.EditCardType(cardType))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"M_EditCardType.aspx?cardTypeId=" + Request["cardTypeId"] + "\"} else  {location.href=\"M_CardTypeList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllCardType.AddCardType(cardType))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"M_EditCardType.aspx\"} else  {location.href=\"M_CardTypeList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_CardTypeList.aspx");
        }
    }
}

