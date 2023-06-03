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
    ///OrderInfo ��ժҪ˵����������Ϣʵ��
    /// </summary>

    public class OrderInfo
    {
        /*�������*/
        private string _orderNo;
        public string orderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }

        /*��ʵ����*/
        private string _realName;
        public string realName
        {
            get { return _realName; }
            set { _realName = value; }
        }

        /*�ջ��˵绰*/
        private string _telephone;
        public string telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        /*�ջ���ַ*/
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

        /*�µ�ʱ��*/
        private DateTime _orderTime;
        public DateTime orderTime
        {
            get { return _orderTime; }
            set { _orderTime = value; }
        }

        /*����״̬*/
        private int _orderState;
        public int orderState
        {
            get { return _orderState; }
            set { _orderState = value; }
        }

        /*���ʽ*/
        private int _payWay;
        public int payWay
        {
            get { return _payWay; }
            set { _payWay = value; }
        }

        /*���ͷ�ʽ*/
        private int _trasportWay;
        public int trasportWay
        {
            get { return _trasportWay; }
            set { _trasportWay = value; }
        }

        /*�û���*/
        private string _username;
        public string username
        {
            get { return _username; }
            set { _username = value; }
        }

    }
}
