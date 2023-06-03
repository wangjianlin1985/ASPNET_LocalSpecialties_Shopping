using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ENTITY
{
    /// <summary>
    ///UserInfo 的摘要说明：用户信息实体
    /// </summary>

    public class UserInfo
    {
        /*用户名*/
        private string _username;
        public string username
        {
            get { return _username; }
            set { _username = value; }
        }

        /*登陆密码*/
        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        /*真实姓名*/
        private string _realName;
        public string realName
        {
            get { return _realName; }
            set { _realName = value; }
        }

        /*所在城市*/
        private string _city;
        public string city
        {
            get { return _city; }
            set { _city = value; }
        }

        /*证件类别*/
        private int _cardTypeObj;
        public int cardTypeObj
        {
            get { return _cardTypeObj; }
            set { _cardTypeObj = value; }
        }

        /*证件号码*/
        private string _cardNumber;
        public string cardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }
        }

        /*联系电话*/
        private string _telephone;
        public string telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        /*Email*/
        private string _emailAddress;
        public string emailAddress
        {
            get { return _emailAddress; }
            set { _emailAddress = value; }
        }

        /*用户头像*/
        private string _userPhoto;
        public string userPhoto
        {
            get { return _userPhoto; }
            set { _userPhoto = value; }
        }

        /*联系地址*/
        private string _address;
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        /*邮政编码*/
        private string _postcode;
        public string postcode
        {
            get { return _postcode; }
            set { _postcode = value; }
        }

    }
}
