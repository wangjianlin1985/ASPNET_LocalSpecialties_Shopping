using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*������Ϣҵ���߼���*/
    public class bllOrderInfo{
        /*��Ӷ�����Ϣ*/
        public static bool AddOrderInfo(ENTITY.OrderInfo orderInfo)
        {
            return DAL.dalOrderInfo.AddOrderInfo(orderInfo);
        }

        /*����orderNo��ȡĳ��������Ϣ��¼*/
        public static ENTITY.OrderInfo getSomeOrderInfo(string orderNo)
        {
            return DAL.dalOrderInfo.getSomeOrderInfo(orderNo);
        }

        /*���¶�����Ϣ*/
        public static bool EditOrderInfo(ENTITY.OrderInfo orderInfo)
        {
            return DAL.dalOrderInfo.EditOrderInfo(orderInfo);
        }

        /*ɾ��������Ϣ*/
        public static bool DelOrderInfo(string p)
        {
            return DAL.dalOrderInfo.DelOrderInfo(p);
        }

        /*����������ҳ��ѯ������Ϣ*/
        public static System.Data.DataTable GetOrderInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalOrderInfo.GetOrderInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĶ�����Ϣ*/
        public static System.Data.DataSet getAllOrderInfo()
        {
            return DAL.dalOrderInfo.getAllOrderInfo();
        }
    }
}
