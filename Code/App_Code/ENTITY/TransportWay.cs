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
    ///TransportWay ��ժҪ˵�������ͷ�ʽʵ��
    /// </summary>

    public class TransportWay
    {
        /*���ͷ�ʽ���*/
        private int _transportId;
        public int transportId
        {
            get { return _transportId; }
            set { _transportId = value; }
        }

        /*���з�ʽ����*/
        private string _transportName;
        public string transportName
        {
            get { return _transportName; }
            set { _transportName = value; }
        }

    }
}
