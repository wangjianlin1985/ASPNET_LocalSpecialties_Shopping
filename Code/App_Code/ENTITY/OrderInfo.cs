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
    ///OrderInfo 的摘要说明：订单信息实体
    /// </summary>

    public class OrderInfo
    {
        /*订单编号*/
        private string _orderNo;
        public string orderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }

        /*真实姓名*/
        private string _realName;
        public string realName
        {
            get { return _realName; }
            set { _realName = value; }
        }

        /*收货人电话*/
        private string _telephone;
        public string telephone
        {
            get { return _telephone; }
            set { _telephone = value; }
        }

        /*收货地址*/
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

        /*下单时间*/
        private DateTime _orderTime;
        public DateTime orderTime
        {
            get { return _orderTime; }
            set { _orderTime = value; }
        }

        /*订单状态*/
        private int _orderState;
        public int orderState
        {
            get { return _orderState; }
            set { _orderState = value; }
        }

        /*付款方式*/
        private int _payWay;
        public int payWay
        {
            get { return _payWay; }
            set { _payWay = value; }
        }

        /*运送方式*/
        private int _trasportWay;
        public int trasportWay
        {
            get { return _trasportWay; }
            set { _trasportWay = value; }
        }

        /*用户名*/
        private string _username;
        public string username
        {
            get { return _username; }
            set { _username = value; }
        }

    }
}
