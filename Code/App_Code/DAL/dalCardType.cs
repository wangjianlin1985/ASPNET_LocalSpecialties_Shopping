using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*证件类型业务逻辑层实现*/
    public class dalCardType
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加证件类型实现*/
        public static bool AddCardType(ENTITY.CardType cardType)
        {
            string sql = "insert into CardType(cardTypeName) values(@cardTypeName)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@cardTypeName",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = cardType.cardTypeName; //证件类别名称

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据cardTypeId获取某条证件类型记录*/
        public static ENTITY.CardType getSomeCardType(int cardTypeId)
        {
            /*构建查询sql*/
            string sql = "select * from CardType where cardTypeId=" + cardTypeId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.CardType cardType = new ENTITY.CardType();
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                cardType.cardTypeId = Convert.ToInt32(DataRead["cardTypeId"]);
                cardType.cardTypeName = DataRead["cardTypeName"].ToString();
            }
            return cardType;
        }

        /*更新证件类型实现*/
        public static bool EditCardType(ENTITY.CardType cardType)
        {
            string sql = "update CardType set cardTypeName=@cardTypeName where cardTypeId=@cardTypeId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@cardTypeName",SqlDbType.VarChar),
             new SqlParameter("@cardTypeId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = cardType.cardTypeName;
            parm[1].Value = cardType.cardTypeId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除证件类型*/
        public static bool DelCardType(string p)
        {
            string sql = "delete from CardType where cardTypeId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询证件类型*/
        public static System.Data.DataTable GetCardType(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from CardType";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "cardTypeId", strShow, strSql, strWhere, " cardTypeId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllCardType()
        {
            try
            {
                string strSql = "select * from CardType";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
