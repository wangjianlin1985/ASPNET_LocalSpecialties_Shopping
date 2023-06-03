using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*购物车业务逻辑层实现*/
    public class dalCosmeticCart
    {
        /*待执行的sql语句*/
        public static string sql = "";



        /*根据用户名查询购物车*/
        public static DataSet QueryGoodCartInfo(string username)
        {
            try
            {
                string strSql = "select * from cosmeticCartView where username='" + username + "'";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /*更新购物车土特产数量*/
        public static bool UpdateGoodCartInfo(int goodCartId, int goodCount)
        {
            string sql = "update CosmeticCart set count=@count where cartId=@cartId";
             SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@count",SqlDbType.Int),
             new SqlParameter("@cartId",SqlDbType.Int) };
            /*给参数赋值*/
            parm[0].Value = goodCount; //土特产数量
            parm[1].Value = goodCartId; //购物车编号

             /*执行sql进行购物车更新*/
             return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }



        /*添加购物车实现*/
        public static bool AddCosmeticCart(ENTITY.CosmeticCart cosmeticCart)
        {
            /*查询购物车表中是否存在该用户购买该土特产的记录*/
            string sql = "select cartId from CosmeticCart where username=@username and cosmeticId=@cosmeticId";
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@username",SqlDbType.VarChar),
             new SqlParameter("@cosmeticId",SqlDbType.Int) };
            /*给参数赋值*/
            parm[0].Value = cosmeticCart.username; //用户名
            parm[1].Value = cosmeticCart.cosmeticId; //土特产编号

            if (DBHelp.ExecuteScalar(sql, parm) == null)
            {
                /*如果不存在就增加一条记录*/ 
                sql = "insert into CosmeticCart(username,cosmeticId,price,count) values(@username,@cosmeticId,@price,@count)";
                /*构建sql参数*/
                parm = new SqlParameter[] {
                    new SqlParameter("@username",SqlDbType.VarChar),
                    new SqlParameter("@cosmeticId",SqlDbType.Int),
                    new SqlParameter("@price",SqlDbType.Float),
                    new SqlParameter("@count",SqlDbType.Int)
                  };
                /*给参数赋值*/
                parm[0].Value = cosmeticCart.username; //用户名
                parm[1].Value = cosmeticCart.cosmeticId; //土特产编号
                parm[2].Value = cosmeticCart.price; //单价
                parm[3].Value = cosmeticCart.count; //购买数量

                /*执行sql进行添加*/
                return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
            }
            else
            {
                /*如果已经存在了，就更新土特产数量*/
                sql = "update CosmeticCart set count = count + 1 where username=@username and cosmeticId=@cosmeticId";
                parm = new SqlParameter[] {
                    new SqlParameter("@username",SqlDbType.VarChar),
                    new SqlParameter("@cosmeticId",SqlDbType.Int) };
                /*给参数赋值*/
                parm[0].Value = cosmeticCart.username; //用户名
                parm[1].Value = cosmeticCart.cosmeticId; //土特产编号

                /*执行sql进行更新*/
                return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
            }



        }


        /*根据用户名得到购物车中总的土特产数量*/
        public static int GetTotalGoodCountInCart(string username)
        {
            string sqlString = "select sum(count) as totalGoodCount from [CosmeticCart] where username='" + username + "'";
            return Convert.ToInt32(DBHelp.ExecuteScalar(sqlString,null));
        }
        /*根据用户名得到购物车中土特产的总价格*/
        public static float GetTotalPriceInCart(string username)
        {
            float totalPrice = 0.0f;
            /*查询该员工的购物车*/
            string sqlString = "select * from [CosmeticCart] where username='" + username + "'";
            DataSet cartInfoDs = DBHelp.ExecuteDataSet(sqlString, null);
            /*遍历购物车中每条土特产销售记录并计算总的价格*/
            for (int i = 0; i < cartInfoDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = cartInfoDs.Tables[0].Rows[i];
                float price = Convert.ToSingle(dr["price"]);
                int number = Convert.ToInt32(dr["count"]);
                totalPrice += (price * number);
            }
            return totalPrice;
        }



        /*根据cartId获取某条购物车记录*/
        public static ENTITY.CosmeticCart getSomeCosmeticCart(int cartId)
        {
            /*构建查询sql*/
            string sql = "select * from CosmeticCart where cartId=" + cartId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.CosmeticCart cosmeticCart = new ENTITY.CosmeticCart();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                cosmeticCart.cartId = Convert.ToInt32(DataRead["cartId"]);
                cosmeticCart.username = DataRead["username"].ToString();
                cosmeticCart.cosmeticId = Convert.ToInt32(DataRead["cosmeticId"]);
                cosmeticCart.price = float.Parse(DataRead["price"].ToString());
                cosmeticCart.count = Convert.ToInt32(DataRead["count"]);
            }
            return cosmeticCart;
        }

        /*更新购物车实现*/
        public static bool EditCosmeticCart(ENTITY.CosmeticCart cosmeticCart)
        {
            string sql = "update CosmeticCart set username=@username,cosmeticId=@cosmeticId,price=@price,count=@count where cartId=@cartId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@username",SqlDbType.VarChar),
             new SqlParameter("@cosmeticId",SqlDbType.Int),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@count",SqlDbType.Int),
             new SqlParameter("@cartId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = cosmeticCart.username;
            parm[1].Value = cosmeticCart.cosmeticId;
            parm[2].Value = cosmeticCart.price;
            parm[3].Value = cosmeticCart.count;
            parm[4].Value = cosmeticCart.cartId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除购物车*/
        public static bool DelCosmeticCart(string p)
        {
            string sql = "delete from CosmeticCart where cartId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*根据用户名清空购物车*/
        public static bool DelCosmeticCartByUsername(string username)
        {

            string sql = "delete from CosmeticCart where username='" + username + "'";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }



        /*查询购物车*/
        public static System.Data.DataTable GetCosmeticCart(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from CosmeticCart";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "cartId", strShow, strSql, strWhere, " cartId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllCosmeticCart()
        {
            try
            {
                string strSql = "select * from CosmeticCart";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
