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
    ///PayWay 的摘要说明：付款方式实体
    /// </summary>

    public class PayWay
    {
        /*付款方式编号*/
        private int _payWayId;
        public int payWayId
        {
            get { return _payWayId; }
            set { _payWayId = value; }
        }

        /*付款方式名称*/
        private string _payWayName;
        public string payWayName
        {
            get { return _payWayName; }
            set { _payWayName = value; }
        }

    }
}
