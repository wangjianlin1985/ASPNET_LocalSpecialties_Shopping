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
                /*进入本信息添加页显示无图的图片*/
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

        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
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
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"M_EditUserInfo.aspx?username=" + Request["username"] + "\"} else  {location.href=\"M_UserInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllUserInfo.AddUserInfo(userInfo))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"M_EditUserInfo.aspx\"} else  {location.href=\"M_UserInfoList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("M_UserInfoList.aspx");
        }
        protected void Btn_UserPhotoUpload_Click(object sender, EventArgs e)
        {
            /*如果用户上传了文件*/
            if (this.UserPhotoUpload.PostedFile.ContentLength > 0)
            {
                /*验证上传的文件格式，只能为gif和jpeg格式*/
                string mimeType = this.UserPhotoUpload.PostedFile.ContentType;
                if (String.Compare(mimeType, "image/gif", true) == 0 || String.Compare(mimeType, "image/pjpeg", true) == 0 || String.Compare(mimeType, "image/jpeg", true) == 0)
                {
                    this.userPhoto.Text = "上传文件中....";
                    string extFileString = System.IO.Path.GetExtension(this.UserPhotoUpload.PostedFile.FileName); /*获取文件扩展名*/
                    string saveFileName = DAL.Function.MakeFileName(extFileString); /*根据扩展名生成文件名*/
                    string imagePath = "FileUpload\\" + saveFileName;/*图片路径*/
                    this.UserPhotoUpload.PostedFile.SaveAs(Server.MapPath(imagePath));
                    this.UserPhotoImage.ImageUrl = imagePath;
                    this.userPhoto.Text = imagePath;
                }
                else
                {
                    Response.Write("<script>alert('上传文件格式不正确!');</script>");
                }
            }
        }
    }
}

