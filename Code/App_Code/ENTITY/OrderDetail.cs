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
    ///OrderDetail 的摘要说明：订单详细项目实体
    /// </summary>

    public class OrderDetail
    {
        /*详细类目编号*/
        private int _detailId;
        public int detailId
        {
            get { return _detailId; }
            set { _detailId = value; }
        }

        /*所属订单*/
        private string _orderNo;
        public string orderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }

        /*所属客户*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*所属土特产*/
        private int _cosmeticObj;
        public int cosmeticObj
        {
            get { return _cosmeticObj; }
            set { _cosmeticObj = value; }
        }

        /*购买数量*/
        private int _count;
        public int count
        {
            get { return _count; }
            set { _count = value; }
        }

        /*购买单价*/
        private float _price;
        public float price
        {
            get { return _price; }
            set { _price = value; }
        }

    }
}
