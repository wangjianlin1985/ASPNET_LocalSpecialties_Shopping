using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*证件类型业务逻辑层*/
    public class bllCardType{
        /*添加证件类型*/
        public static bool AddCardType(ENTITY.CardType cardType)
        {
            return DAL.dalCardType.AddCardType(cardType);
        }

        /*根据cardTypeId获取某条证件类型记录*/
        public static ENTITY.CardType getSomeCardType(int cardTypeId)
        {
            return DAL.dalCardType.getSomeCardType(cardTypeId);
        }

        /*更新证件类型*/
        public static bool EditCardType(ENTITY.CardType cardType)
        {
            return DAL.dalCardType.EditCardType(cardType);
        }

        /*删除证件类型*/
        public static bool DelCardType(string p)
        {
            return DAL.dalCardType.DelCardType(p);
        }

        /*根据条件分页查询证件类型*/
        public static System.Data.DataTable GetCardType(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCardType.GetCardType(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的证件类型*/
        public static System.Data.DataSet getAllCardType()
        {
            return DAL.dalCardType.getAllCardType();
        }
    }
}
