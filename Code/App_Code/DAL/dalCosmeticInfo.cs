using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*土特产信息业务逻辑层实现*/
    public class dalCosmeticInfo
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加土特产信息实现*/
        public static bool AddCosmeticInfo(ENTITY.CosmeticInfo cosmeticInfo)
        {
            string sql = "insert into CosmeticInfo(classObj,cosmeticName,price,totalCount,cosmeticImage,cosmeticIntroduce) values(@classObj,@cosmeticName,@price,@totalCount,@cosmeticImage,@cosmeticIntroduce)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@classObj",SqlDbType.Int),
             new SqlParameter("@cosmeticName",SqlDbType.VarChar),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@totalCount",SqlDbType.Int),
             new SqlParameter("@cosmeticImage",SqlDbType.VarChar),
             new SqlParameter("@cosmeticIntroduce",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = cosmeticInfo.classObj; //所属类别
            parm[1].Value = cosmeticInfo.cosmeticName; //土特产名称
            parm[2].Value = cosmeticInfo.price; //土特产价格
            parm[3].Value = cosmeticInfo.totalCount; //土特产剩余总量
            parm[4].Value = cosmeticInfo.cosmeticImage; //土特产图片
            parm[5].Value = cosmeticInfo.cosmeticIntroduce; //土特产说明

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据cosmeticId获取某条土特产信息记录*/
        public static ENTITY.CosmeticInfo getSomeCosmeticInfo(int cosmeticId)
        {
            /*构建查询sql*/
            string sql = "select * from CosmeticInfo where cosmeticId=" + cosmeticId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.CosmeticInfo cosmeticInfo = new ENTITY.CosmeticInfo();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                cosmeticInfo.cosmeticId = Convert.ToInt32(DataRead["cosmeticId"]);
                cosmeticInfo.classObj = Convert.ToInt32(DataRead["classObj"]);
                cosmeticInfo.cosmeticName = DataRead["cosmeticName"].ToString();
                cosmeticInfo.price = float.Parse(DataRead["price"].ToString());
                cosmeticInfo.totalCount = Convert.ToInt32(DataRead["totalCount"]);
                cosmeticInfo.cosmeticImage = DataRead["cosmeticImage"].ToString();
                cosmeticInfo.cosmeticIntroduce = DataRead["cosmeticIntroduce"].ToString();
            }
            return cosmeticInfo;
        }

        /*更新土特产信息实现*/
        public static bool EditCosmeticInfo(ENTITY.CosmeticInfo cosmeticInfo)
        {
            string sql = "update CosmeticInfo set classObj=@classObj,cosmeticName=@cosmeticName,price=@price,totalCount=@totalCount,cosmeticImage=@cosmeticImage,cosmeticIntroduce=@cosmeticIntroduce where cosmeticId=@cosmeticId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@classObj",SqlDbType.Int),
             new SqlParameter("@cosmeticName",SqlDbType.VarChar),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@totalCount",SqlDbType.Int),
             new SqlParameter("@cosmeticImage",SqlDbType.VarChar),
             new SqlParameter("@cosmeticIntroduce",SqlDbType.VarChar),
             new SqlParameter("@cosmeticId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = cosmeticInfo.classObj;
            parm[1].Value = cosmeticInfo.cosmeticName;
            parm[2].Value = cosmeticInfo.price;
            parm[3].Value = cosmeticInfo.totalCount; 
            parm[4].Value = cosmeticInfo.cosmeticImage;
            parm[5].Value = cosmeticInfo.cosmeticIntroduce;
            parm[6].Value = cosmeticInfo.cosmeticId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除土特产信息*/
        public static bool DelCosmeticInfo(string p)
        {
            string sql = "delete from CosmeticInfo where cosmeticId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询土特产信息*/
        public static System.Data.DataTable GetCosmeticInfo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from CosmeticInfo";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "cosmeticId", strShow, strSql, strWhere, " cosmeticId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllCosmeticInfo()
        {
            try
            {
                string strSql = "select * from CosmeticInfo";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
