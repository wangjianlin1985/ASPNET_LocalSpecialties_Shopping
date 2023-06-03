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
    public partial class Front_CosmeticBigClass_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                bigClassName.Text = cosmeticBigClass.bigClassName;
            }
        }
    }
}
