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
    ///CosmeticBigClass ��ժҪ˵�������ز������ʵ��
    /// </summary>

    public class CosmeticBigClass
    {
        /*���ز������*/
        private int _bigClassId;
        public int bigClassId
        {
            get { return _bigClassId; }
            set { _bigClassId = value; }
        }

        /*���ز��������*/
        private string _bigClassName;
        public string bigClassName
        {
            get { return _bigClassName; }
            set { _bigClassName = value; }
        }

    }
}
