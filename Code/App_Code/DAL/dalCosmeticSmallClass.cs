using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*土特产分类业务逻辑层实现*/
    public class dalCosmeticSmallClass
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加土特产分类实现*/
        public static bool AddCosmeticSmallClass(ENTITY.CosmeticSmallClass cosmeticSmallClass)
        {
            string sql = "insert into CosmeticSmallClass(bigClassObj,smallClassName) values(@bigClassObj,@smallClassName)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@bigClassObj",SqlDbType.Int),
             new SqlParameter("@smallClassName",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = cosmeticSmallClass.bigClassObj; //所属大类
            parm[1].Value = cosmeticSmallClass.smallClassName; //分类名称

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据smallClassId获取某条土特产分类记录*/
        public static ENTITY.CosmeticSmallClass getSomeCosmeticSmallClass(int smallClassId)
        {
            /*构建查询sql*/
            string sql = "select * from CosmeticSmallClass where smallClassId=" + smallClassId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.CosmeticSmallClass cosmeticSmallClass = new ENTITY.CosmeticSmallClass();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                cosmeticSmallClass.smallClassId = Convert.ToInt32(DataRead["smallClassId"]);
                cosmeticSmallClass.bigClassObj = Convert.ToInt32(DataRead["bigClassObj"]);
                cosmeticSmallClass.smallClassName = DataRead["smallClassName"].ToString();
            }
            return cosmeticSmallClass;
        }

        /*更新土特产分类实现*/
        public static bool EditCosmeticSmallClass(ENTITY.CosmeticSmallClass cosmeticSmallClass)
        {
            string sql = "update CosmeticSmallClass set bigClassObj=@bigClassObj,smallClassName=@smallClassName where smallClassId=@smallClassId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@bigClassObj",SqlDbType.Int),
             new SqlParameter("@smallClassName",SqlDbType.VarChar),
             new SqlParameter("@smallClassId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = cosmeticSmallClass.bigClassObj;
            parm[1].Value = cosmeticSmallClass.smallClassName;
            parm[2].Value = cosmeticSmallClass.smallClassId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除土特产分类*/
        public static bool DelCosmeticSmallClass(string p)
        {
            string sql = "delete from CosmeticSmallClass where smallClassId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询土特产分类*/
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
