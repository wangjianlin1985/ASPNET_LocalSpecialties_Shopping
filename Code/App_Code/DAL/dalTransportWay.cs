using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*运送方式业务逻辑层实现*/
    public class dalTransportWay
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加运送方式实现*/
        public static bool AddTransportWay(ENTITY.TransportWay transportWay)
        {
            string sql = "insert into TransportWay(transportName) values(@transportName)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@transportName",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = transportWay.transportName; //运行方式名称

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据transportId获取某条运送方式记录*/
        public static ENTITY.TransportWay getSomeTransportWay(int transportId)
        {
            /*构建查询sql*/
            string sql = "select * from TransportWay where transportId=" + transportId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.TransportWay transportWay = new ENTITY.TransportWay();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                transportWay.transportId = Convert.ToInt32(DataRead["transportId"]);
                transportWay.transportName = DataRead["transportName"].ToString();
            }
            return transportWay;
        }

        /*更新运送方式实现*/
        public static bool EditTransportWay(ENTITY.TransportWay transportWay)
        {
            string sql = "update TransportWay set transportName=@transportName where transportId=@transportId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@transportName",SqlDbType.VarChar),
             new SqlParameter("@transportId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = transportWay.transportName;
            parm[1].Value = transportWay.transportId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除运送方式*/
        public static bool DelTransportWay(string p)
        {
            string sql = "delete from TransportWay where transportId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询运送方式*/
        public static System.Data.DataTable GetTransportWay(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from TransportWay";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "transportId", strShow, strSql, strWhere, " transportId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllTransportWay()
        {
            try
            {
                string strSql = "select * from TransportWay";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
