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
    public partial class M_EditCosmeticBigClass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                if (Request["bigClassId"] != null)
                {
                    LoadData();
                }
            }
        }
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "bigClassId")))
            {
                ENTITY.CosmeticBigClass cosmeticBigClass = BLL.bllCosmeticBigClass.getSomeCosmeticBigClass(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "bigClassId")));
                bigClassName.Value = cosmeticBigClass.bigClassName;
            }
        }

        protected void BtnCosmeticBigClassSave_Click(object sender, EventArgs e)
        {
            ENTITY.CosmeticBigClass cosmeticBigClass = new ENTITY.CosmeticBigClass();
            cosmeticBigClass.bigClassName = bigClassName.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "bigClassId")))
            {
                cosmeticBigClass.bigClassId = int.Parse(Request["bigClassId"]);
                if (BLL.bllCosmeticBigClass.EditCosmeticBigClass(cosmeticBigClass))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"M_EditCosmeticBigClass.aspx?bigClassId=" + Request["bigClassId"] + "\"} else  {location.href=\"M_CosmeticBigClassList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllCosmeticBigClass.AddCosmeticBigClass(cosmeticBigClass))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"M_EditCosmeticBigClass.aspx\"} else  {location.href=\"M_CosmeticBigClassList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_CosmeticBigClassList.aspx");
        }
    }
}

