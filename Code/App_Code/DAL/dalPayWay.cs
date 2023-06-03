using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*���ʽҵ���߼���ʵ��*/
    public class dalPayWay
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��Ӹ��ʽʵ��*/
        public static bool AddPayWay(ENTITY.PayWay payWay)
        {
            string sql = "insert into PayWay(payWayName) values(@payWayName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@payWayName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = payWay.payWayName; //���ʽ����

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����payWayId��ȡĳ�����ʽ��¼*/
        public static ENTITY.PayWay getSomePayWay(int payWayId)
        {
            /*������ѯsql*/
            string sql = "select * from PayWay where payWayId=" + payWayId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.PayWay payWay = new ENTITY.PayWay();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                payWay.payWayId = Convert.ToInt32(DataRead["payWayId"]);
                payWay.payWayName = DataRead["payWayName"].ToString();
            }
            return payWay;
        }

        /*���¸��ʽʵ��*/
        public static bool EditPayWay(ENTITY.PayWay payWay)
        {
            string sql = "update PayWay set payWayName=@payWayName where payWayId=@payWayId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@payWayName",SqlDbType.VarChar),
             new SqlParameter("@payWayId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = payWay.payWayName;
            parm[1].Value = payWay.payWayId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ�����ʽ*/
        public static bool DelPayWay(string p)
        {
            string sql = "delete from PayWay where payWayId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ���ʽ*/
        public static System.Data.DataTable GetPayWay(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from PayWay";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "payWayId", strShow, strSql, strWhere, " payWayId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllPayWay()
        {
            try
            {
                string strSql = "select * from PayWay";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
