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
    ///UserInfo ��ժҪ˵�����û���Ϣʵ��
    /// </summary>

    public class UserInfo
    {
        /*�û���*/
        private string _username;
        public string username
        {
            get { return _username; }
            set { _username = value; }
        }

        /*��½����*/
        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        /*��ʵ����*/
        private string _realName;
        public string realName
        {
            get { return _realName; }
            set { _realName = value; }
        }

        /*���ڳ���*/
        private string _city;
        public string city
        {
            get { return _city; }
            set { _city = value; }
        }

        /*֤�����*/
        private int _cardTypeObj;
        public int cardTypeObj
        {
            get { return _cardTypeObj; }
            set { _cardTypeObj = value; }
        }

        /*֤������*/
        private string _cardNumber;
        public string cardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }
        }

        /*��ϵ�绰*/
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

        /*�û�ͷ��*/
        private string _userPhoto;
        public string userPhoto
        {
            get { return _userPhoto; }
            set { _userPhoto = value; }
        }

        /*��ϵ��ַ*/
        private string _address;
        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        /*��������*/
        private string _postcode;
        public string postcode
        {
            get { return _postcode; }
            set { _postcode = value; }
        }

    }
}
