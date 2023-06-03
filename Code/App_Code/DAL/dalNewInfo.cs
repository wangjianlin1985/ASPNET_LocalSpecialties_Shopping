using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*新闻信息业务逻辑层实现*/
    public class dalNewInfo
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加新闻信息实现*/
        public static bool AddNewInfo(ENTITY.NewInfo newInfo)
        {
            string sql = "insert into NewInfo(newTitle,newBody,publishDate) values(@newTitle,@newBody,@publishDate)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@newTitle",SqlDbType.VarChar),
             new SqlParameter("@newBody",SqlDbType.VarChar),
             new SqlParameter("@publishDate",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = newInfo.newTitle; //新闻标题
            parm[1].Value = newInfo.newBody; //新闻内容
            parm[2].Value = newInfo.publishDate; //发布日期

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据newsId获取某条新闻信息记录*/
        public static ENTITY.NewInfo getSomeNewInfo(int newsId)
        {
            /*构建查询sql*/
            string sql = "select * from NewInfo where newsId=" + newsId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.NewInfo newInfo = new ENTITY.NewInfo();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                newInfo.newsId = Convert.ToInt32(DataRead["newsId"]);
                newInfo.newTitle = DataRead["newTitle"].ToString();
                newInfo.newBody = DataRead["newBody"].ToString();
                newInfo.publishDate = Convert.ToDateTime(DataRead["publishDate"].ToString());
            }
            return newInfo;
        }

        /*更新新闻信息实现*/
        public static bool EditNewInfo(ENTITY.NewInfo newInfo)
        {
            string sql = "update NewInfo set newTitle=@newTitle,newBody=@newBody,publishDate=@publishDate where newsId=@newsId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@newTitle",SqlDbType.VarChar),
             new SqlParameter("@newBody",SqlDbType.VarChar),
             new SqlParameter("@publishDate",SqlDbType.DateTime),
             new SqlParameter("@newsId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = newInfo.newTitle;
            parm[1].Value = newInfo.newBody;
            parm[2].Value = newInfo.publishDate;
            parm[3].Value = newInfo.newsId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除新闻信息*/
        public static bool DelNewInfo(string p)
        {
            string sql = "delete from NewInfo where newsId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询新闻信息*/
        public static System.Data.DataTable GetNewInfo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from NewInfo";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "newsId", strShow, strSql, strWhere, " newsId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllNewInfo()
        {
            try
            {
                string strSql = "select * from NewInfo";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
