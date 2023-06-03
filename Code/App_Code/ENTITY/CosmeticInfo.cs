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
    ///CosmeticInfo 的摘要说明：土特产信息实体
    /// </summary>

    public class CosmeticInfo
    {
        /*土特产编号*/
        private int _cosmeticId;
        public int cosmeticId
        {
            get { return _cosmeticId; }
            set { _cosmeticId = value; }
        }

        /*所属类别*/
        private int _classObj;
        public int classObj
        {
            get { return _classObj; }
            set { _classObj = value; }
        }

        /*土特产名称*/
        private string _cosmeticName;
        public string cosmeticName
        {
            get { return _cosmeticName; }
            set { _cosmeticName = value; }
        }

        /*土特产价格*/
        private float _price;
        public float price
        {
            get { return _price; }
            set { _price = value; }
        }

        /*土特产剩余总量*/
        private int _totalCount;
        public int totalCount
        {
            get { return _totalCount; }
            set { _totalCount = value; }
        }
 
        

        /*土特产图片*/
        private string _cosmeticImage;
        public string cosmeticImage
        {
            get { return _cosmeticImage; }
            set { _cosmeticImage = value; }
        }

        /*土特产说明*/
        private string _cosmeticIntroduce;
        public string cosmeticIntroduce
        {
            get { return _cosmeticIntroduce; }
            set { _cosmeticIntroduce = value; }
        }

    }
}
