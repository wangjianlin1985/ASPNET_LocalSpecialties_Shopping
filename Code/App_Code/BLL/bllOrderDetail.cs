using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*������ϸ��Ŀҵ���߼���*/
    public class bllOrderDetail{



        /*���ݶ�����Ų�ѯ��ϸ��Ŀ��Ϣ*/
        public static System.Data.DataSet QueryOrderDetailByOrderNo(string orderNo)
        {
            return DAL.dalOrderDetail.QueryOrderDetailByOrderNo(orderNo);
        }



        /*���ݶ����ŵõ��ܵ����ز�����*/
        public static int GetTotalGoodCountByOrderNo(string orderNo)
        {
            return DAL.dalOrderDetail.GetTotalGoodCountByOrderNo(orderNo);
        }

        /*���ݶ����Ż�ȡ���ز����ܼ۸�*/
        public static float GetTotalPriceByOrderNo(string orderNo)
        {
            return DAL.dalOrderDetail.GetTotalPriceByOrderNo(orderNo);
        }


        /*��Ӷ�����ϸ��Ŀ*/
        public static bool AddOrderDetail(ENTITY.OrderDetail orderDetail)
        {
            return DAL.dalOrderDetail.AddOrderDetail(orderDetail);
        }

        /*����detailId��ȡĳ��������ϸ��Ŀ��¼*/
        public static ENTITY.OrderDetail getSomeOrderDetail(int detailId)
        {
            return DAL.dalOrderDetail.getSomeOrderDetail(detailId);
        }

        /*���¶�����ϸ��Ŀ*/
        public static bool EditOrderDetail(ENTITY.OrderDetail orderDetail)
        {
            return DAL.dalOrderDetail.EditOrderDetail(orderDetail);
        }

        /*ɾ��������ϸ��Ŀ*/
        public static bool DelOrderDetail(string p)
        {
            return DAL.dalOrderDetail.DelOrderDetail(p);
        }

        /*����������ҳ��ѯ������ϸ��Ŀ*/
        public static System.Data.DataTable GetOrderDetail(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalOrderDetail.GetOrderDetail(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĶ�����ϸ��Ŀ*/
        public static System.Data.DataSet getAllOrderDetail()
        {
            return DAL.dalOrderDetail.getAllOrderDetail();
        }
    }
}
