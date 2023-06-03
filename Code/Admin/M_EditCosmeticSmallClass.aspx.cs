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

        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
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
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"M_EditCosmeticSmallClass.aspx?smallClassId=" + Request["smallClassId"] + "\"} else  {location.href=\"M_CosmeticSmallClassList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllCosmeticSmallClass.AddCosmeticSmallClass(cosmeticSmallClass))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"M_EditCosmeticSmallClass.aspx\"} else  {location.href=\"M_CosmeticSmallClassList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_CosmeticSmallClassList.aspx");
        }
    }
}

