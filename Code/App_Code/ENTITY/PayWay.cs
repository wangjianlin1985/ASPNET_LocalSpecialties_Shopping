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
    ///PayWay ��ժҪ˵�������ʽʵ��
    /// </summary>

    public class PayWay
    {
        /*���ʽ���*/
        private int _payWayId;
        public int payWayId
        {
            get { return _payWayId; }
            set { _payWayId = value; }
        }

        /*���ʽ����*/
        private string _payWayName;
        public string payWayName
        {
            get { return _payWayName; }
            set { _payWayName = value; }
        }

    }
}
