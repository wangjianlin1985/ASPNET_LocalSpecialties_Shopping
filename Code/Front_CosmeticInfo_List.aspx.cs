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

namespace shuangyulin.Front
{
    public partial class Front_CosmeticInfo_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCosmeticSmallClass();
                string sqlstr = " where 1=1 ";
                if (Request["classObj"] != null && Request["classObj"].ToString() != "0")
                {
                    sqlstr += "  and classObj=" + Request["classObj"].ToString();
                    classObj.SelectedValue = Request["classObj"].ToString();
                }
                if (Request["cosmeticName"] != null && Request["cosmeticName"].ToString() != "")
                {
                    sqlstr += "  and cosmeticName like '%" + Request["cosmeticName"].ToString() + "%'";
                    cosmeticName.Text = Request["cosmeticName"].ToString();
                }

              

                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BindCosmeticSmallClass()
        {
            /*
            classObj.DataSource = BLL.bllCosmeticSmallClass.getAllCosmeticSmallClass();
            classObj.DataTextField = "smallClassName";
            classObj.DataValueField = "smallClassId";
            classObj.DataBind();
             */

            DataSet ds = BLL.bllCosmeticSmallClass.getAllCosmeticSmallClass();
            ListItem li = null;
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                int bigClassId = Convert.ToInt32(ds.Tables[0].Rows[i]["bigClassObj"]);
                int smallClassId = Convert.ToInt32(ds.Tables[0].Rows[i]["smallClassId"]);
                String smallClassName = ds.Tables[0].Rows[i]["smallClassName"].ToString();
                String bigClassName = BLL.bllCosmeticBigClass.getSomeCosmeticBigClass(bigClassId).bigClassName;
                li = new ListItem(bigClassName + "：" + smallClassName, smallClassId + "");
                classObj.Items.Add(li);
            }

            li = new ListItem("=请选择=", "0");
            classObj.Items.Add(li);
            classObj.SelectedValue = "0";
        }

        private void BindData(string strClass)
        {
            int DataCount = 0;
            int NowPage = 1;
            int AllPage = 0;
            int PageSize = Convert.ToInt32(HPageSize.Value);
            switch (strClass)
            {
                case "next":
                    NowPage = Convert.ToInt32(HNowPage.Value) + 1;
                    break;
                case "up":
                    NowPage = Convert.ToInt32(HNowPage.Value) - 1;
                    break;
                case "end":
                    NowPage = Convert.ToInt32(HAllPage.Value);
                    break;
                default:
                    break;
            }
            DataTable dsLog = BLL.bllCosmeticInfo.GetCosmeticInfo(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
            if (dsLog.Rows.Count == 0 || AllPage == 1)
            {
                LBEnd.Enabled = false;
                LBHome.Enabled = false;
                LBNext.Enabled = false;
                LBUp.Enabled = false;
            }
            else if (NowPage == 1)
            {
                LBHome.Enabled = false;
                LBUp.Enabled = false;
                LBNext.Enabled = true;
                LBEnd.Enabled = true;
            }
            else if (NowPage == AllPage)
            {
                LBHome.Enabled = true;
                LBUp.Enabled = true;
                LBNext.Enabled = false;
                LBEnd.Enabled = false;
            }
            else
            {
                LBEnd.Enabled = true;
                LBHome.Enabled = true;
                LBNext.Enabled = true;
                LBUp.Enabled = true;
            }
            RpCosmeticInfo.DataSource = dsLog;
            RpCosmeticInfo.DataBind();
            PageMes.Text = string.Format("[每页<font color=green>{0}</font>条 第<font color=red>{1}</font>页／共<font color=green>{2}</font>页   共<font color=green>{3}</font>条]", PageSize, NowPage, AllPage, DataCount);
            HNowPage.Value = Convert.ToString(NowPage++);
            HAllPage.Value = AllPage.ToString();
        }

        protected void LBHome_Click(object sender, EventArgs e)
        {
            BindData("");
        }
        protected void LBUp_Click(object sender, EventArgs e)
        {
            BindData("up");
        }
        protected void LBNext_Click(object sender, EventArgs e)
        {
            BindData("next");
        }
        protected void LBEnd_Click(object sender, EventArgs e)
        {
            BindData("end");
        }
        public string GetCosmeticSmallClassclassObj(string classObj)
        {
            return BLL.bllCosmeticSmallClass.getSomeCosmeticSmallClass(int.Parse(classObj)).smallClassName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("Front_CosmeticInfo_List.aspx?classObj=" + classObj.SelectedValue.Trim()+ "&&cosmeticName=" + cosmeticName.Text.Trim());
        }
    }
}
