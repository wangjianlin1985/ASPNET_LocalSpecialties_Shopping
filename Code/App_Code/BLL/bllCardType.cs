using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*֤������ҵ���߼���*/
    public class bllCardType{
        /*���֤������*/
        public static bool AddCardType(ENTITY.CardType cardType)
        {
            return DAL.dalCardType.AddCardType(cardType);
        }

        /*����cardTypeId��ȡĳ��֤�����ͼ�¼*/
        public static ENTITY.CardType getSomeCardType(int cardTypeId)
        {
            return DAL.dalCardType.getSomeCardType(cardTypeId);
        }

        /*����֤������*/
        public static bool EditCardType(ENTITY.CardType cardType)
        {
            return DAL.dalCardType.EditCardType(cardType);
        }

        /*ɾ��֤������*/
        public static bool DelCardType(string p)
        {
            return DAL.dalCardType.DelCardType(p);
        }

        /*����������ҳ��ѯ֤������*/
        public static System.Data.DataTable GetCardType(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCardType.GetCardType(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�֤������*/
        public static System.Data.DataSet getAllCardType()
        {
            return DAL.dalCardType.getAllCardType();
        }
    }
}
