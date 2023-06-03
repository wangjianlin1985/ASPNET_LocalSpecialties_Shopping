using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*���ز�����ҵ���߼���ʵ��*/
    public class dalCosmeticSmallClass
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*������ز�����ʵ��*/
        public static bool AddCosmeticSmallClass(ENTITY.CosmeticSmallClass cosmeticSmallClass)
        {
            string sql = "insert into CosmeticSmallClass(bigClassObj,smallClassName) values(@bigClassObj,@smallClassName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@bigClassObj",SqlDbType.Int),
             new SqlParameter("@smallClassName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = cosmeticSmallClass.bigClassObj; //��������
            parm[1].Value = cosmeticSmallClass.smallClassName; //��������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����smallClassId��ȡĳ�����ز������¼*/
        public static ENTITY.CosmeticSmallClass getSomeCosmeticSmallClass(int smallClassId)
        {
            /*������ѯsql*/
            string sql = "select * from CosmeticSmallClass where smallClassId=" + smallClassId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.CosmeticSmallClass cosmeticSmallClass = new ENTITY.CosmeticSmallClass();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                cosmeticSmallClass.smallClassId = Convert.ToInt32(DataRead["smallClassId"]);
                cosmeticSmallClass.bigClassObj = Convert.ToInt32(DataRead["bigClassObj"]);
                cosmeticSmallClass.smallClassName = DataRead["smallClassName"].ToString();
            }
            return cosmeticSmallClass;
        }

        /*�������ز�����ʵ��*/
        public static bool EditCosmeticSmallClass(ENTITY.CosmeticSmallClass cosmeticSmallClass)
        {
            string sql = "update CosmeticSmallClass set bigClassObj=@bigClassObj,smallClassName=@smallClassName where smallClassId=@smallClassId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@bigClassObj",SqlDbType.Int),
             new SqlParameter("@smallClassName",SqlDbType.VarChar),
             new SqlParameter("@smallClassId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = cosmeticSmallClass.bigClassObj;
            parm[1].Value = cosmeticSmallClass.smallClassName;
            parm[2].Value = cosmeticSmallClass.smallClassId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ�����ز�����*/
        public static bool DelCosmeticSmallClass(string p)
        {
            string sql = "delete from CosmeticSmallClass where smallClassId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ���ز�����*/
        public static System.Data.DataTable GetCosmeticSmallClass(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from CosmeticSmallClass";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "smallClassId", strShow, strSql, strWhere, " smallClassId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllCosmeticSmallClass()
        {
            try
            {
                string strSql = "select * from CosmeticSmallClass";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
