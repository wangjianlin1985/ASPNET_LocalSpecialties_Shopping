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
    ///OrderState ��ժҪ˵���� ����״̬ʵ��
    /// </summary>

    public class OrderState
    {
        /*״̬���*/
        private int _stateId;
        public int stateId
        {
            get { return _stateId; }
            set { _stateId = value; }
        }

        /*״̬����*/
        private string _stateName;
        public string stateName
        {
            get { return _stateName; }
            set { _stateName = value; }
        }

    }
}
