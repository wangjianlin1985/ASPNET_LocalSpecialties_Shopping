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
    ///CosmeticSmallClass 的摘要说明：土特产分类实体
    /// </summary>

    public class CosmeticSmallClass
    {
        /*小类编号*/
        private int _smallClassId;
        public int smallClassId
        {
            get { return _smallClassId; }
            set { _smallClassId = value; }
        }

        /*所属大类*/
        private int _bigClassObj;
        public int bigClassObj
        {
            get { return _bigClassObj; }
            set { _bigClassObj = value; }
        }

        /*分类名称*/
        private string _smallClassName;
        public string smallClassName
        {
            get { return _smallClassName; }
            set { _smallClassName = value; }
        }

    }
}
