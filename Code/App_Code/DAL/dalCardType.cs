using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*֤������ҵ���߼���ʵ��*/
    public class dalCardType
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���֤������ʵ��*/
        public static bool AddCardType(ENTITY.CardType cardType)
        {
            string sql = "insert into CardType(cardTypeName) values(@cardTypeName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@cardTypeName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = cardType.cardTypeName; //֤���������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����cardTypeId��ȡĳ��֤�����ͼ�¼*/
        public static ENTITY.CardType getSomeCardType(int cardTypeId)
        {
            /*������ѯsql*/
            string sql = "select * from CardType where cardTypeId=" + cardTypeId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.CardType cardType = new ENTITY.CardType();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                cardType.cardTypeId = Convert.ToInt32(DataRead["cardTypeId"]);
                cardType.cardTypeName = DataRead["cardTypeName"].ToString();
            }
            return cardType;
        }

        /*����֤������ʵ��*/
        public static bool EditCardType(ENTITY.CardType cardType)
        {
            string sql = "update CardType set cardTypeName=@cardTypeName where cardTypeId=@cardTypeId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@cardTypeName",SqlDbType.VarChar),
             new SqlParameter("@cardTypeId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = cardType.cardTypeName;
            parm[1].Value = cardType.cardTypeId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��֤������*/
        public static bool DelCardType(string p)
        {
            string sql = "delete from CardType where cardTypeId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ֤������*/
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
