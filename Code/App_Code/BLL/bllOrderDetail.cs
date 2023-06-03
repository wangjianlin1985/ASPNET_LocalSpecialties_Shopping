using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*订单详细项目业务逻辑层*/
    public class bllOrderDetail{



        /*根据订单编号查询详细类目信息*/
        public static System.Data.DataSet QueryOrderDetailByOrderNo(string orderNo)
        {
            return DAL.dalOrderDetail.QueryOrderDetailByOrderNo(orderNo);
        }



        /*根据订单号得到总的土特产数量*/
        public static int GetTotalGoodCountByOrderNo(string orderNo)
        {
            return DAL.dalOrderDetail.GetTotalGoodCountByOrderNo(orderNo);
        }

        /*根据订单号获取土特产的总价格*/
        public static float GetTotalPriceByOrderNo(string orderNo)
        {
            return DAL.dalOrderDetail.GetTotalPriceByOrderNo(orderNo);
        }


        /*添加订单详细项目*/
        public static bool AddOrderDetail(ENTITY.OrderDetail orderDetail)
        {
            return DAL.dalOrderDetail.AddOrderDetail(orderDetail);
        }

        /*根据detailId获取某条订单详细项目记录*/
        public static ENTITY.OrderDetail getSomeOrderDetail(int detailId)
        {
            return DAL.dalOrderDetail.getSomeOrderDetail(detailId);
        }

        /*更新订单详细项目*/
        public static bool EditOrderDetail(ENTITY.OrderDetail orderDetail)
        {
            return DAL.dalOrderDetail.EditOrderDetail(orderDetail);
        }

        /*删除订单详细项目*/
        public static bool DelOrderDetail(string p)
        {
            return DAL.dalOrderDetail.DelOrderDetail(p);
        }

        /*根据条件分页查询订单详细项目*/
        public static System.Data.DataTable GetOrderDetail(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalOrderDetail.GetOrderDetail(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的订单详细项目*/
        public static System.Data.DataSet getAllOrderDetail()
        {
            return DAL.dalOrderDetail.getAllOrderDetail();
        }
    }
}
