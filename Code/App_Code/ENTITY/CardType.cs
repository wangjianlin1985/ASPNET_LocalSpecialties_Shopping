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
    ///CardType ��ժҪ˵����֤������ʵ��
    /// </summary>

    public class CardType
    {
        /*֤�����ͱ��*/
        private int _cardTypeId;
        public int cardTypeId
        {
            get { return _cardTypeId; }
            set { _cardTypeId = value; }
        }

        /*֤���������*/
        private string _cardTypeName;
        public string cardTypeName
        {
            get { return _cardTypeName; }
            set { _cardTypeName = value; }
        }

    }
}
