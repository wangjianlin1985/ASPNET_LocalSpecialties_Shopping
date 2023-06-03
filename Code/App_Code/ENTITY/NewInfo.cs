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
    ///NewInfo 的摘要说明：新闻信息实体
    /// </summary>

    public class NewInfo
    {
        /*新闻编号*/
        private int _newsId;
        public int newsId
        {
            get { return _newsId; }
            set { _newsId = value; }
        }

        /*新闻标题*/
        private string _newTitle;
        public string newTitle
        {
            get { return _newTitle; }
            set { _newTitle = value; }
        }

        /*新闻内容*/
        private string _newBody;
        public string newBody
        {
            get { return _newBody; }
            set { _newBody = value; }
        }

        /*发布日期*/
        private DateTime _publishDate;
        public DateTime publishDate
        {
            get { return _publishDate; }
            set { _publishDate = value; }
        }

    }
}
