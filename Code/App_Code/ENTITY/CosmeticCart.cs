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
    ///CosmeticCart ��ժҪ˵�������ﳵʵ��
    /// </summary>

    public class CosmeticCart
    {
        /*��¼���*/
        private int _cartId;
        public int cartId
        {
            get { return _cartId; }
            set { _cartId = value; }
        }

        /*�û���*/
        private string _username;
        public string username
        {
            get { return _username; }
            set { _username = value; }
        }

        /*���ز����*/
        private int _cosmeticId;
        public int cosmeticId
        {
            get { return _cosmeticId; }
            set { _cosmeticId = value; }
        }

        /*����*/
        private float _price;
        public float price
        {
            get { return _price; }
            set { _price = value; }
        }

        /*��������*/
        private int _count;
        public int count
        {
            get { return _count; }
            set { _count = value; }
        }

    }
}
