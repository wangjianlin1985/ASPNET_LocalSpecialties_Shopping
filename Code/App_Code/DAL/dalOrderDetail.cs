using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*订单详细项目业务逻辑层实现*/
    public class dalOrderDetail
    {
        /*待执行的sql语句*/
        public static string sql = "";


        /*根据订单编号查询详细类目信息*/
        public static System.Data.DataSet QueryOrderDetailByOrderNo(string orderNo)
        {
            try
            {
                string strSql = "select * from orderDetailView where orderNo='" + orderNo + "'";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /*根据订单号获取总的土特产数量*/
        public static int GetTotalGoodCountByOrderNo(string orderNo)
        {
            string sqlString = "select sum(count) as totalGoodCount from [OrderDetail] where orderNo='" + orderNo + "'";
            return Convert.ToInt32(DBHelp.ExecuteScalar(sqlString, null));
        }
        /*根据订单号获取土特产的总价格*/
        public static float GetTotalPriceByOrderNo(string orderNo)
        {
            float totalPrice = 0.0f;
            /*查询该订单号的所有土特产清单*/
            string sqlString = "select * from [OrderDetail] where orderNo='" + orderNo + "'";
            DataSet orderDetailDs = DBHelp.ExecuteDataSet(sqlString, null);
            /*遍历该订单土特产清单记录并计算总的价格*/
            for (int i = 0; i < orderDetailDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = orderDetailDs.Tables[0].Rows[i];
                float price = Convert.ToSingle(dr["price"]);
                int number = Convert.ToInt32(dr["count"]);
                totalPrice += (price * number);
            }
            return totalPrice;
        }



        /*添加订单详细项目实现*/
        public static bool AddOrderDetail(ENTITY.OrderDetail orderDetail)
        {
            string sql = "insert into OrderDetail(orderNo,userObj,cosmeticObj,count,price) values(@orderNo,@userObj,@cosmeticObj,@count,@price)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@orderNo",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@cosmeticObj",SqlDbType.Int),
             new SqlParameter("@count",SqlDbType.Int),
             new SqlParameter("@price",SqlDbType.Float)
            };
            /*给参数赋值*/
            parm[0].Value = orderDetail.orderNo; //所属订单
            parm[1].Value = orderDetail.userObj; //所属客户
            parm[2].Value = orderDetail.cosmeticObj; //所属土特产
            parm[3].Value = orderDetail.count; //购买数量
            parm[4].Value = orderDetail.price; //购买单价

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据detailId获取某条订单详细项目记录*/
        public static ENTITY.OrderDetail getSomeOrderDetail(int detailId)
        {
            /*构建查询sql*/
            string sql = "select * from OrderDetail where detailId=" + detailId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.OrderDetail orderDetail = new ENTITY.OrderDetail();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                orderDetail.detailId = Convert.ToInt32(DataRead["detailId"]);
                orderDetail.orderNo = DataRead["orderNo"].ToString();
                orderDetail.userObj = DataRead["userObj"].ToString();
                orderDetail.cosmeticObj = Convert.ToInt32(DataRead["cosmeticObj"]);
                orderDetail.count = Convert.ToInt32(DataRead["count"]);
                orderDetail.price = float.Parse(DataRead["price"].ToString());
            }
            return orderDetail;
        }

        /*更新订单详细项目实现*/
        public static bool EditOrderDetail(ENTITY.OrderDetail orderDetail)
        {
            string sql = "update OrderDetail set orderNo=@orderNo,userObj=@userObj,cosmeticObj=@cosmeticObj,count=@count,price=@price where detailId=@detailId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@orderNo",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@cosmeticObj",SqlDbType.Int),
             new SqlParameter("@count",SqlDbType.Int),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@detailId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = orderDetail.orderNo;
            parm[1].Value = orderDetail.userObj;
            parm[2].Value = orderDetail.cosmeticObj;
            parm[3].Value = orderDetail.count;
            parm[4].Value = orderDetail.price;
            parm[5].Value = orderDetail.detailId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除订单详细项目*/
        public static bool DelOrderDetail(string p)
        {
            string sql = "delete from OrderDetail where detailId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询订单详细项目*/
        public static System.Data.DataTable GetOrderDetail(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from OrderDetail";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "detailId", strShow, strSql, strWhere, " detailId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllOrderDetail()
        {
            try
            {
                string strSql = "select * from OrderDetail";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
