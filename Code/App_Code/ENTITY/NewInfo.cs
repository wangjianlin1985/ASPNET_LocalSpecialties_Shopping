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
    ///NewInfo ��ժҪ˵����������Ϣʵ��
    /// </summary>

    public class NewInfo
    {
        /*���ű��*/
        private int _newsId;
        public int newsId
        {
            get { return _newsId; }
            set { _newsId = value; }
        }

        /*���ű���*/
        private string _newTitle;
        public string newTitle
        {
            get { return _newTitle; }
            set { _newTitle = value; }
        }

        /*��������*/
        private string _newBody;
        public string newBody
        {
            get { return _newBody; }
            set { _newBody = value; }
        }

        /*��������*/
        private DateTime _publishDate;
        public DateTime publishDate
        {
            get { return _publishDate; }
            set { _publishDate = value; }
        }

    }
}
