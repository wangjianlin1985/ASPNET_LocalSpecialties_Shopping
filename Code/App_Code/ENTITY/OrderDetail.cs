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
    ///OrderDetail ��ժҪ˵����������ϸ��Ŀʵ��
    /// </summary>

    public class OrderDetail
    {
        /*��ϸ��Ŀ���*/
        private int _detailId;
        public int detailId
        {
            get { return _detailId; }
            set { _detailId = value; }
        }

        /*��������*/
        private string _orderNo;
        public string orderNo
        {
            get { return _orderNo; }
            set { _orderNo = value; }
        }

        /*�����ͻ�*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*�������ز�*/
        private int _cosmeticObj;
        public int cosmeticObj
        {
            get { return _cosmeticObj; }
            set { _cosmeticObj = value; }
        }

        /*��������*/
        private int _count;
        public int count
        {
            get { return _count; }
            set { _count = value; }
        }

        /*���򵥼�*/
        private float _price;
        public float price
        {
            get { return _price; }
            set { _price = value; }
        }

    }
}
