using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /* ����״̬ҵ���߼���*/
    public class bllOrderState{
        /*��� ����״̬*/
        public static bool AddOrderState(ENTITY.OrderState orderState)
        {
            return DAL.dalOrderState.AddOrderState(orderState);
        }

        /*����stateId��ȡĳ�� ����״̬��¼*/
        public static ENTITY.OrderState getSomeOrderState(int stateId)
        {
            return DAL.dalOrderState.getSomeOrderState(stateId);
        }

        /*���� ����״̬*/
        public static bool EditOrderState(ENTITY.OrderState orderState)
        {
            return DAL.dalOrderState.EditOrderState(orderState);
        }

        /*ɾ�� ����״̬*/
        public static bool DelOrderState(string p)
        {
            return DAL.dalOrderState.DelOrderState(p);
        }

        /*����������ҳ��ѯ ����״̬*/
        public static System.Data.DataTable GetOrderState(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalOrderState.GetOrderState(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е� ����״̬*/
        public static System.Data.DataSet getAllOrderState()
        {
            return DAL.dalOrderState.getAllOrderState();
        }
    }
}
