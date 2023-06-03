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
    public partial class M_EditUserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindCardTypecardTypeObj();
                /*���뱾��Ϣ���ҳ��ʾ��ͼ��ͼƬ*/
                this.UserPhotoImage.ImageUrl = "FileUpload\\NoImage.jpg";
                if (Request["username"] != null)
                {
                    LoadData();
                }
            }
        }
        private void BindCardTypecardTypeObj()
        {
            cardTypeObj.DataSource = BLL.bllCardType.getAllCardType();
            cardTypeObj.DataTextField = "cardTypeName";
            cardTypeObj.DataValueField = "cardTypeId";
            cardTypeObj.DataBind();
        }

        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "username")))
            {
                ENTITY.UserInfo userInfo = BLL.bllUserInfo.getSomeUserInfo(Common.GetMes.GetRequestQuery(Request, "username"));
                username.Value = userInfo.username;
                password.Value = userInfo.password;
                realName.Value = userInfo.realName;
                city.Value = userInfo.city;
                cardTypeObj.SelectedValue = userInfo.cardTypeObj.ToString();
                cardNumber.Value = userInfo.cardNumber;
                telephone.Value = userInfo.telephone;
                emailAddress.Value = userInfo.emailAddress;
                userPhoto.Text = userInfo.userPhoto;
                if (userInfo.userPhoto != "") this.UserPhotoImage.ImageUrl = userInfo.userPhoto;
                address.Value = userInfo.address;
                postcode.Value = userInfo.postcode;
            }
        }

        protected void BtnUserInfoSave_Click(object sender, EventArgs e)
        {
            ENTITY.UserInfo userInfo = new ENTITY.UserInfo();
            userInfo.username = this.username.Value;
            userInfo.password = password.Value;
            userInfo.realName = realName.Value;
            userInfo.city = city.Value;
            userInfo.cardTypeObj = int.Parse(cardTypeObj.SelectedValue);
            userInfo.cardNumber = cardNumber.Value;
            userInfo.telephone = telephone.Value;
            userInfo.emailAddress = emailAddress.Value;
            if (userPhoto.Text == "") userPhoto.Text = "FileUpload\\NoImage.jpg";
            userInfo.userPhoto = userPhoto.Text;
            userInfo.address = address.Value;
            userInfo.postcode = postcode.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "username")))
            {
                userInfo.username = Request["username"];
                if (BLL.bllUserInfo.EditUserInfo(userInfo))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"M_EditUserInfo.aspx?username=" + Request["username"] + "\"} else  {location.href=\"M_UserInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllUserInfo.AddUserInfo(userInfo))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"M_EditUserInfo.aspx\"} else  {location.href=\"M_UserInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_UserInfoList.aspx");
        }
        protected void Btn_UserPhotoUpload_Click(object sender, EventArgs e)
        {
            /*����û��ϴ����ļ�*/
            if (this.UserPhotoUpload.PostedFile.ContentLength > 0)
            {
                /*��֤�ϴ����ļ���ʽ��ֻ��Ϊgif��jpeg��ʽ*/
                string mimeType = this.UserPhotoUpload.PostedFile.ContentType;
                if (String.Compare(mimeType, "image/gif", true) == 0 || String.Compare(mimeType, "image/pjpeg", true) == 0 || String.Compare(mimeType, "image/jpeg", true) == 0)
                {
                    this.userPhoto.Text = "�ϴ��ļ���....";
                    string extFileString = System.IO.Path.GetExtension(this.UserPhotoUpload.PostedFile.FileName); /*��ȡ�ļ���չ��*/
                    string saveFileName = DAL.Function.MakeFileName(extFileString); /*������չ�������ļ���*/
                    string imagePath = "FileUpload\\" + saveFileName;/*ͼƬ·��*/
                    this.UserPhotoUpload.PostedFile.SaveAs(Server.MapPath(imagePath));
                    this.UserPhotoImage.ImageUrl = imagePath;
                    this.userPhoto.Text = imagePath;
                }
                else
                {
                    Response.Write("<script>alert('�ϴ��ļ���ʽ����ȷ!');</script>");
                }
            }
        }
    }
}

