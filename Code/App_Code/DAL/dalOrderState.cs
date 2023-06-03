using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /* 订单状态业务逻辑层实现*/
    public class dalOrderState
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加 订单状态实现*/
        public static bool AddOrderState(ENTITY.OrderState orderState)
        {
            string sql = "insert into OrderState(stateName) values(@stateName)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@stateName",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = orderState.stateName; //状态名称

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据stateId获取某条 订单状态记录*/
        public static ENTITY.OrderState getSomeOrderState(int stateId)
        {
            /*构建查询sql*/
            string sql = "select * from OrderState where stateId=" + stateId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.OrderState orderState = new ENTITY.OrderState();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                orderState.stateId = Convert.ToInt32(DataRead["stateId"]);
                orderState.stateName = DataRead["stateName"].ToString();
            }
            return orderState;
        }

        /*更新 订单状态实现*/
        public static bool EditOrderState(ENTITY.OrderState orderState)
        {
            string sql = "update OrderState set stateName=@stateName where stateId=@stateId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@stateName",SqlDbType.VarChar),
             new SqlParameter("@stateId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = orderState.stateName;
            parm[1].Value = orderState.stateId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除 订单状态*/
        public static bool DelOrderState(string p)
        {
            string sql = "delete from OrderState where stateId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询 订单状态*/
        public static System.Data.DataTable GetOrderState(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from OrderState";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "stateId", strShow, strSql, strWhere, " stateId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllOrderState()
        {
            try
            {
                string strSql = "select * from OrderState";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
