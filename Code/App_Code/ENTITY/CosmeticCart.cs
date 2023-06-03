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
    ///CosmeticCart 的摘要说明：购物车实体
    /// </summary>

    public class CosmeticCart
    {
        /*记录编号*/
        private int _cartId;
        public int cartId
        {
            get { return _cartId; }
            set { _cartId = value; }
        }

        /*用户名*/
        private string _username;
        public string username
        {
            get { return _username; }
            set { _username = value; }
        }

        /*土特产编号*/
        private int _cosmeticId;
        public int cosmeticId
        {
            get { return _cosmeticId; }
            set { _cosmeticId = value; }
        }

        /*单价*/
        private float _price;
        public float price
        {
            get { return _price; }
            set { _price = value; }
        }

        /*购买数量*/
        private int _count;
        public int count
        {
            get { return _count; }
            set { _count = value; }
        }

    }
}
