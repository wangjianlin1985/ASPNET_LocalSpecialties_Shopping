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
    ///CosmeticInfo ��ժҪ˵�������ز���Ϣʵ��
    /// </summary>

    public class CosmeticInfo
    {
        /*���ز����*/
        private int _cosmeticId;
        public int cosmeticId
        {
            get { return _cosmeticId; }
            set { _cosmeticId = value; }
        }

        /*�������*/
        private int _classObj;
        public int classObj
        {
            get { return _classObj; }
            set { _classObj = value; }
        }

        /*���ز�����*/
        private string _cosmeticName;
        public string cosmeticName
        {
            get { return _cosmeticName; }
            set { _cosmeticName = value; }
        }

        /*���ز��۸�*/
        private float _price;
        public float price
        {
            get { return _price; }
            set { _price = value; }
        }

        /*���ز�ʣ������*/
        private int _totalCount;
        public int totalCount
        {
            get { return _totalCount; }
            set { _totalCount = value; }
        }
 
        

        /*���ز�ͼƬ*/
        private string _cosmeticImage;
        public string cosmeticImage
        {
            get { return _cosmeticImage; }
            set { _cosmeticImage = value; }
        }

        /*���ز�˵��*/
        private string _cosmeticIntroduce;
        public string cosmeticIntroduce
        {
            get { return _cosmeticIntroduce; }
            set { _cosmeticIntroduce = value; }
        }

    }
}
