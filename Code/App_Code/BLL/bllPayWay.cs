using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*付款方式业务逻辑层*/
    public class bllPayWay{
        /*添加付款方式*/
        public static bool AddPayWay(ENTITY.PayWay payWay)
        {
            return DAL.dalPayWay.AddPayWay(payWay);
        }

        /*根据payWayId获取某条付款方式记录*/
        public static ENTITY.PayWay getSomePayWay(int payWayId)
        {
            return DAL.dalPayWay.getSomePayWay(payWayId);
        }

        /*更新付款方式*/
        public static bool EditPayWay(ENTITY.PayWay payWay)
        {
            return DAL.dalPayWay.EditPayWay(payWay);
        }

        /*删除付款方式*/
        public static bool DelPayWay(string p)
        {
            return DAL.dalPayWay.DelPayWay(p);
        }

        /*根据条件分页查询付款方式*/
        public static System.Data.DataTable GetPayWay(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalPayWay.GetPayWay(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的付款方式*/
        public static System.Data.DataSet getAllPayWay()
        {
            return DAL.dalPayWay.getAllPayWay();
        }
    }
}
