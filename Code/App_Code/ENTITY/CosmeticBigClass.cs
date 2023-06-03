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
    ///CosmeticBigClass 的摘要说明：土特产大类别实体
    /// </summary>

    public class CosmeticBigClass
    {
        /*土特产类别编号*/
        private int _bigClassId;
        public int bigClassId
        {
            get { return _bigClassId; }
            set { _bigClassId = value; }
        }

        /*土特产类别名称*/
        private string _bigClassName;
        public string bigClassName
        {
            get { return _bigClassName; }
            set { _bigClassName = value; }
        }

    }
}
