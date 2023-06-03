using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*������Ϣҵ���߼���ʵ��*/
    public class dalNewInfo
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���������Ϣʵ��*/
        public static bool AddNewInfo(ENTITY.NewInfo newInfo)
        {
            string sql = "insert into NewInfo(newTitle,newBody,publishDate) values(@newTitle,@newBody,@publishDate)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@newTitle",SqlDbType.VarChar),
             new SqlParameter("@newBody",SqlDbType.VarChar),
             new SqlParameter("@publishDate",SqlDbType.DateTime)
            };
            /*��������ֵ*/
            parm[0].Value = newInfo.newTitle; //���ű���
            parm[1].Value = newInfo.newBody; //��������
            parm[2].Value = newInfo.publishDate; //��������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����newsId��ȡĳ��������Ϣ��¼*/
        public static ENTITY.NewInfo getSomeNewInfo(int newsId)
        {
            /*������ѯsql*/
            string sql = "select * from NewInfo where newsId=" + newsId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.NewInfo newInfo = new ENTITY.NewInfo();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                newInfo.newsId = Convert.ToInt32(DataRead["newsId"]);
                newInfo.newTitle = DataRead["newTitle"].ToString();
                newInfo.newBody = DataRead["newBody"].ToString();
                newInfo.publishDate = Convert.ToDateTime(DataRead["publishDate"].ToString());
            }
            return newInfo;
        }

        /*����������Ϣʵ��*/
        public static bool EditNewInfo(ENTITY.NewInfo newInfo)
        {
            string sql = "update NewInfo set newTitle=@newTitle,newBody=@newBody,publishDate=@publishDate where newsId=@newsId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@newTitle",SqlDbType.VarChar),
             new SqlParameter("@newBody",SqlDbType.VarChar),
             new SqlParameter("@publishDate",SqlDbType.DateTime),
             new SqlParameter("@newsId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = newInfo.newTitle;
            parm[1].Value = newInfo.newBody;
            parm[2].Value = newInfo.publishDate;
            parm[3].Value = newInfo.newsId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��������Ϣ*/
        public static bool DelNewInfo(string p)
        {
            string sql = "delete from NewInfo where newsId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ������Ϣ*/
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
