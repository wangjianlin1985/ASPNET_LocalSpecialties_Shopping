using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*���ʽҵ���߼���*/
    public class bllPayWay{
        /*��Ӹ��ʽ*/
        public static bool AddPayWay(ENTITY.PayWay payWay)
        {
            return DAL.dalPayWay.AddPayWay(payWay);
        }

        /*����payWayId��ȡĳ�����ʽ��¼*/
        public static ENTITY.PayWay getSomePayWay(int payWayId)
        {
            return DAL.dalPayWay.getSomePayWay(payWayId);
        }

        /*���¸��ʽ*/
        public static bool EditPayWay(ENTITY.PayWay payWay)
        {
            return DAL.dalPayWay.EditPayWay(payWay);
        }

        /*ɾ�����ʽ*/
        public static bool DelPayWay(string p)
        {
            return DAL.dalPayWay.DelPayWay(p);
        }

        /*����������ҳ��ѯ���ʽ*/
        public static System.Data.DataTable GetPayWay(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalPayWay.GetPayWay(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĸ��ʽ*/
        public static System.Data.DataSet getAllPayWay()
        {
            return DAL.dalPayWay.getAllPayWay();
        }
    }
}
