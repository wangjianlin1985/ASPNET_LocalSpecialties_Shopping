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
    public partial class Front_UserInfo_Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*���뱾��Ϣ���ҳ��ʾ��ͼ��ͼƬ*/
                this.UserPhotoImage.ImageUrl = "Admin\\FileUpload\\NoImage.jpg";
                if (Request["username"] != null)
                {
                    LoadData();
                }
            }
        }
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "username")))
            {
                ENTITY.UserInfo userInfo = BLL.bllUserInfo.getSomeUserInfo(Common.GetMes.GetRequestQuery(Request, "username"));
                username.Text = userInfo.username;
                password.Text = userInfo.password;
                realName.Text = userInfo.realName;
                city.Text = userInfo.city;
            cardTypeObj.Text = BLL.bllCardType.getSomeCardType(userInfo.cardTypeObj).cardTypeName;
                cardNumber.Text = userInfo.cardNumber;
                telephone.Text = userInfo.telephone;
                emailAddress.Text = userInfo.emailAddress;
            if (userInfo.userPhoto != "") this.UserPhotoImage.ImageUrl = "Admin\\" + userInfo.userPhoto;
                address.Text = userInfo.address;
                postcode.Text = userInfo.postcode;
            }
        }
    }
}
