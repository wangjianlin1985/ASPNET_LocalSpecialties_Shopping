using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*���ͷ�ʽҵ���߼���*/
    public class bllTransportWay{
        /*������ͷ�ʽ*/
        public static bool AddTransportWay(ENTITY.TransportWay transportWay)
        {
            return DAL.dalTransportWay.AddTransportWay(transportWay);
        }

        /*����transportId��ȡĳ�����ͷ�ʽ��¼*/
        public static ENTITY.TransportWay getSomeTransportWay(int transportId)
        {
            return DAL.dalTransportWay.getSomeTransportWay(transportId);
        }

        /*�������ͷ�ʽ*/
        public static bool EditTransportWay(ENTITY.TransportWay transportWay)
        {
            return DAL.dalTransportWay.EditTransportWay(transportWay);
        }

        /*ɾ�����ͷ�ʽ*/
        public static bool DelTransportWay(string p)
        {
            return DAL.dalTransportWay.DelTransportWay(p);
        }

        /*����������ҳ��ѯ���ͷ�ʽ*/
        public static System.Data.DataTable GetTransportWay(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalTransportWay.GetTransportWay(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е����ͷ�ʽ*/
        public static System.Data.DataSet getAllTransportWay()
        {
            return DAL.dalTransportWay.getAllTransportWay();
        }
    }
}
