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
    ///TransportWay 的摘要说明：运送方式实体
    /// </summary>

    public class TransportWay
    {
        /*运送方式编号*/
        private int _transportId;
        public int transportId
        {
            get { return _transportId; }
            set { _transportId = value; }
        }

        /*运行方式名称*/
        private string _transportName;
        public string transportName
        {
            get { return _transportName; }
            set { _transportName = value; }
        }

    }
}
