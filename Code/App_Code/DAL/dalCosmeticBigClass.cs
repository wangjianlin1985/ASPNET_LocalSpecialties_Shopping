using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*���ز������ҵ���߼���ʵ��*/
    public class dalCosmeticBigClass
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*������ز������ʵ��*/
        public static bool AddCosmeticBigClass(ENTITY.CosmeticBigClass cosmeticBigClass)
        {
            string sql = "insert into CosmeticBigClass(bigClassName) values(@bigClassName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@bigClassName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = cosmeticBigClass.bigClassName; //���ز��������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����bigClassId��ȡĳ�����ز�������¼*/
        public static ENTITY.CosmeticBigClass getSomeCosmeticBigClass(int bigClassId)
        {
            /*������ѯsql*/
            string sql = "select * from CosmeticBigClass where bigClassId=" + bigClassId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.CosmeticBigClass cosmeticBigClass = new ENTITY.CosmeticBigClass();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                cosmeticBigClass.bigClassId = Convert.ToInt32(DataRead["bigClassId"]);
                cosmeticBigClass.bigClassName = DataRead["bigClassName"].ToString();
            }
            return cosmeticBigClass;
        }

        /*�������ز������ʵ��*/
        public static bool EditCosmeticBigClass(ENTITY.CosmeticBigClass cosmeticBigClass)
        {
            string sql = "update CosmeticBigClass set bigClassName=@bigClassName where bigClassId=@bigClassId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@bigClassName",SqlDbType.VarChar),
             new SqlParameter("@bigClassId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = cosmeticBigClass.bigClassName;
            parm[1].Value = cosmeticBigClass.bigClassId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ�����ز������*/
        public static bool DelCosmeticBigClass(string p)
        {
            string sql = "delete from CosmeticBigClass where bigClassId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ���ز������*/
        public static System.Data.DataTable GetCosmeticBigClass(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from CosmeticBigClass";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "bigClassId", strShow, strSql, strWhere, " bigClassId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllCosmeticBigClass()
        {
            try
            {
                string strSql = "select * from CosmeticBigClass";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
