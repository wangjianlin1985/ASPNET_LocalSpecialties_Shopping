using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*土特产大类别业务逻辑层实现*/
    public class dalCosmeticBigClass
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加土特产大类别实现*/
        public static bool AddCosmeticBigClass(ENTITY.CosmeticBigClass cosmeticBigClass)
        {
            string sql = "insert into CosmeticBigClass(bigClassName) values(@bigClassName)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@bigClassName",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = cosmeticBigClass.bigClassName; //土特产类别名称

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据bigClassId获取某条土特产大类别记录*/
        public static ENTITY.CosmeticBigClass getSomeCosmeticBigClass(int bigClassId)
        {
            /*构建查询sql*/
            string sql = "select * from CosmeticBigClass where bigClassId=" + bigClassId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.CosmeticBigClass cosmeticBigClass = new ENTITY.CosmeticBigClass();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                cosmeticBigClass.bigClassId = Convert.ToInt32(DataRead["bigClassId"]);
                cosmeticBigClass.bigClassName = DataRead["bigClassName"].ToString();
            }
            return cosmeticBigClass;
        }

        /*更新土特产大类别实现*/
        public static bool EditCosmeticBigClass(ENTITY.CosmeticBigClass cosmeticBigClass)
        {
            string sql = "update CosmeticBigClass set bigClassName=@bigClassName where bigClassId=@bigClassId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@bigClassName",SqlDbType.VarChar),
             new SqlParameter("@bigClassId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = cosmeticBigClass.bigClassName;
            parm[1].Value = cosmeticBigClass.bigClassId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除土特产大类别*/
        public static bool DelCosmeticBigClass(string p)
        {
            string sql = "delete from CosmeticBigClass where bigClassId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询土特产大类别*/
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
