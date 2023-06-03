using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*付款方式业务逻辑层实现*/
    public class dalPayWay
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加付款方式实现*/
        public static bool AddPayWay(ENTITY.PayWay payWay)
        {
            string sql = "insert into PayWay(payWayName) values(@payWayName)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@payWayName",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = payWay.payWayName; //付款方式名称

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据payWayId获取某条付款方式记录*/
        public static ENTITY.PayWay getSomePayWay(int payWayId)
        {
            /*构建查询sql*/
            string sql = "select * from PayWay where payWayId=" + payWayId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.PayWay payWay = new ENTITY.PayWay();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                payWay.payWayId = Convert.ToInt32(DataRead["payWayId"]);
                payWay.payWayName = DataRead["payWayName"].ToString();
            }
            return payWay;
        }

        /*更新付款方式实现*/
        public static bool EditPayWay(ENTITY.PayWay payWay)
        {
            string sql = "update PayWay set payWayName=@payWayName where payWayId=@payWayId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@payWayName",SqlDbType.VarChar),
             new SqlParameter("@payWayId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = payWay.payWayName;
            parm[1].Value = payWay.payWayId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除付款方式*/
        public static bool DelPayWay(string p)
        {
            string sql = "delete from PayWay where payWayId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询付款方式*/
        public static System.Data.DataTable GetPayWay(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from PayWay";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "payWayId", strShow, strSql, strWhere, " payWayId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllPayWay()
        {
            try
            {
                string strSql = "select * from PayWay";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
