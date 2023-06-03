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
    public partial class M_EditCosmeticSmallClass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindCosmeticBigClassbigClassObj();
                if (Request["smallClassId"] != null)
                {
                    LoadData();
                }
            }
        }
        private void BindCosmeticBigClassbigClassObj()
        {
            bigClassObj.DataSource = BLL.bllCosmeticBigClass.getAllCosmeticBigClass();
            bigClassObj.DataTextField = "bigClassName";
            bigClassObj.DataValueField = "bigClassId";
            bigClassObj.DataBind();
        }

        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "smallClassId")))
            {
                ENTITY.CosmeticSmallClass cosmeticSmallClass = BLL.bllCosmeticSmallClass.getSomeCosmeticSmallClass(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "smallClassId")));
                bigClassObj.SelectedValue = cosmeticSmallClass.bigClassObj.ToString();
                smallClassName.Value = cosmeticSmallClass.smallClassName;
            }
        }

        protected void BtnCosmeticSmallClassSave_Click(object sender, EventArgs e)
        {
            ENTITY.CosmeticSmallClass cosmeticSmallClass = new ENTITY.CosmeticSmallClass();
            cosmeticSmallClass.bigClassObj = int.Parse(bigClassObj.SelectedValue);
            cosmeticSmallClass.smallClassName = smallClassName.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "smallClassId")))
            {
                cosmeticSmallClass.smallClassId = int.Parse(Request["smallClassId"]);
                if (BLL.bllCosmeticSmallClass.EditCosmeticSmallClass(cosmeticSmallClass))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"M_EditCosmeticSmallClass.aspx?smallClassId=" + Request["smallClassId"] + "\"} else  {location.href=\"M_CosmeticSmallClassList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllCosmeticSmallClass.AddCosmeticSmallClass(cosmeticSmallClass))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"M_EditCosmeticSmallClass.aspx\"} else  {location.href=\"M_CosmeticSmallClassList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_CosmeticSmallClassList.aspx");
        }
    }
}

