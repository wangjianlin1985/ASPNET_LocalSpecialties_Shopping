using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*订单信息业务逻辑层*/
    public class bllOrderInfo{
        /*添加订单信息*/
        public static bool AddOrderInfo(ENTITY.OrderInfo orderInfo)
        {
            return DAL.dalOrderInfo.AddOrderInfo(orderInfo);
        }

        /*根据orderNo获取某条订单信息记录*/
        public static ENTITY.OrderInfo getSomeOrderInfo(string orderNo)
        {
            return DAL.dalOrderInfo.getSomeOrderInfo(orderNo);
        }

        /*更新订单信息*/
        public static bool EditOrderInfo(ENTITY.OrderInfo orderInfo)
        {
            return DAL.dalOrderInfo.EditOrderInfo(orderInfo);
        }

        /*删除订单信息*/
        public static bool DelOrderInfo(string p)
        {
            return DAL.dalOrderInfo.DelOrderInfo(p);
        }

        /*根据条件分页查询订单信息*/
        public static System.Data.DataTable GetOrderInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalOrderInfo.GetOrderInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的订单信息*/
        public static System.Data.DataSet getAllOrderInfo()
        {
            return DAL.dalOrderInfo.getAllOrderInfo();
        }
    }
}
