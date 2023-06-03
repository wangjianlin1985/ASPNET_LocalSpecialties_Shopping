using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*订单信息业务逻辑层实现*/
    public class dalOrderInfo
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加订单信息实现*/
        public static bool AddOrderInfo(ENTITY.OrderInfo orderInfo)
        {
            bool isOk = true;
            string sql = "insert into OrderInfo(orderNo,realName,telephone,address,postcode,orderTime,orderState,payWay,trasportWay,username) values(@orderNo,@realName,@telephone,@address,@postcode,@orderTime,@orderState,@payWay,@trasportWay,@username)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@orderNo",SqlDbType.VarChar),
             new SqlParameter("@realName",SqlDbType.VarChar),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@address",SqlDbType.VarChar),
             new SqlParameter("@postcode",SqlDbType.VarChar),
             new SqlParameter("@orderTime",SqlDbType.DateTime),
             new SqlParameter("@orderState",SqlDbType.Int),
             new SqlParameter("@payWay",SqlDbType.Int),
             new SqlParameter("@trasportWay",SqlDbType.Int),
             new SqlParameter("@username",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = orderInfo.orderNo; //订单编号
            parm[1].Value = orderInfo.realName; //真实姓名
            parm[2].Value = orderInfo.telephone; //收货人电话
            parm[3].Value = orderInfo.address; //收货地址
            parm[4].Value = orderInfo.postcode; //邮政编码
            parm[5].Value = orderInfo.orderTime; //下单时间
            parm[6].Value = orderInfo.orderState; //订单状态
            parm[7].Value = orderInfo.payWay; //付款方式
            parm[8].Value = orderInfo.trasportWay; //运送方式
            parm[9].Value = orderInfo.username; //用户名


            /*执行sql进行订单信息添加*/
            isOk = DBHelp.ExecuteNonQuery(sql, parm) > 0;
            if (!isOk) return false; 


            //根据用户名获取到购物车中的详细类目
            DataSet goodCartInfoDs = BLL.bllCosmeticCart.QueryGoodCartInfo(orderInfo.username);
            for (int i = 0; i < goodCartInfoDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = goodCartInfoDs.Tables[0].Rows[i];
                ENTITY.OrderDetail orderDetail = new ENTITY.OrderDetail();
                orderDetail.orderNo = orderInfo.orderNo;
                orderDetail.userObj = orderInfo.username;
                orderDetail.cosmeticObj = Convert.ToInt32(dr["cosmeticId"]);
                orderDetail.count = Convert.ToInt32(dr["count"]);
                orderDetail.price = Convert.ToSingle(dr["price"]);
                /*添加详细类目记录*/
                isOk = BLL.bllOrderDetail.AddOrderDetail(orderDetail);
                if (!isOk) return false;

                /*更新土特产的库存*/
                ENTITY.CosmeticInfo cosmeticInfo = BLL.bllCosmeticInfo.getSomeCosmeticInfo(orderDetail.cosmeticObj);
                
                cosmeticInfo.totalCount = cosmeticInfo.totalCount - orderDetail.count; //库存减少

                BLL.bllCosmeticInfo.EditCosmeticInfo(cosmeticInfo);//更新土特产信息
            }

            /*清空购物车*/
            isOk = BLL.bllCosmeticCart.DelCosmeticCartByUsername(orderInfo.username);


            return isOk;

              
        }

        /*根据orderNo获取某条订单信息记录*/
        public static ENTITY.OrderInfo getSomeOrderInfo(string orderNo)
        {
            /*构建查询sql*/
            string sql = "select * from OrderInfo where orderNo='" + orderNo + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.OrderInfo orderInfo = new ENTITY.OrderInfo();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                orderInfo.orderNo = DataRead["orderNo"].ToString();
                orderInfo.realName = DataRead["realName"].ToString();
                orderInfo.telephone = DataRead["telephone"].ToString();
                orderInfo.address = DataRead["address"].ToString();
                orderInfo.postcode = DataRead["postcode"].ToString();
                orderInfo.orderTime = Convert.ToDateTime(DataRead["orderTime"].ToString());
                orderInfo.orderState = Convert.ToInt32(DataRead["orderState"]);
                orderInfo.payWay = Convert.ToInt32(DataRead["payWay"]);
                orderInfo.trasportWay = Convert.ToInt32(DataRead["trasportWay"]);
                orderInfo.username = DataRead["username"].ToString();
            }
            return orderInfo;
        }

        /*更新订单信息实现*/
        public static bool EditOrderInfo(ENTITY.OrderInfo orderInfo)
        {
            string sql = "update OrderInfo set realName=@realName,telephone=@telephone,address=@address,postcode=@postcode,orderTime=@orderTime,orderState=@orderState,payWay=@payWay,trasportWay=@trasportWay,username=@username where orderNo=@orderNo";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@realName",SqlDbType.VarChar),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@address",SqlDbType.VarChar),
             new SqlParameter("@postcode",SqlDbType.VarChar),
             new SqlParameter("@orderTime",SqlDbType.DateTime),
             new SqlParameter("@orderState",SqlDbType.Int),
             new SqlParameter("@payWay",SqlDbType.Int),
             new SqlParameter("@trasportWay",SqlDbType.Int),
             new SqlParameter("@username",SqlDbType.VarChar),
             new SqlParameter("@orderNo",SqlDbType.VarChar)
            };
            /*为参数赋值*/
            parm[0].Value = orderInfo.realName;
            parm[1].Value = orderInfo.telephone;
            parm[2].Value = orderInfo.address;
            parm[3].Value = orderInfo.postcode;
            parm[4].Value = orderInfo.orderTime;
            parm[5].Value = orderInfo.orderState;
            parm[6].Value = orderInfo.payWay;
            parm[7].Value = orderInfo.trasportWay;
            parm[8].Value = orderInfo.username;
            parm[9].Value = orderInfo.orderNo;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除订单信息*/
        public static bool DelOrderInfo(string p)
        {
            string sql = "";
            string[] ids = p.Split(',');
            for(int i=0;i<ids.Length;i++)
            {
                if(i != ids.Length-1)
                  sql += "'" + ids[i] + "',";
                else
                  sql += "'" + ids[i] + "'";
            }
            sql = "delete from OrderInfo where orderNo in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询订单信息*/
        public static System.Data.DataTable GetOrderInfo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from OrderInfo";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "orderNo", strShow, strSql, strWhere, " orderNo asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllOrderInfo()
        {
            try
            {
                string strSql = "select * from OrderInfo";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
