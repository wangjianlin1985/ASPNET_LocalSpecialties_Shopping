using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /* ����״̬ҵ���߼���ʵ��*/
    public class dalOrderState
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��� ����״̬ʵ��*/
        public static bool AddOrderState(ENTITY.OrderState orderState)
        {
            string sql = "insert into OrderState(stateName) values(@stateName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@stateName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = orderState.stateName; //״̬����

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����stateId��ȡĳ�� ����״̬��¼*/
        public static ENTITY.OrderState getSomeOrderState(int stateId)
        {
            /*������ѯsql*/
            string sql = "select * from OrderState where stateId=" + stateId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.OrderState orderState = new ENTITY.OrderState();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                orderState.stateId = Convert.ToInt32(DataRead["stateId"]);
                orderState.stateName = DataRead["stateName"].ToString();
            }
            return orderState;
        }

        /*���� ����״̬ʵ��*/
        public static bool EditOrderState(ENTITY.OrderState orderState)
        {
            string sql = "update OrderState set stateName=@stateName where stateId=@stateId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@stateName",SqlDbType.VarChar),
             new SqlParameter("@stateId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = orderState.stateName;
            parm[1].Value = orderState.stateId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ�� ����״̬*/
        public static bool DelOrderState(string p)
        {
            string sql = "delete from OrderState where stateId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ ����״̬*/
        public static System.Data.DataTable GetOrderState(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from OrderState";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "stateId", strShow, strSql, strWhere, " stateId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllOrderState()
        {
            try
            {
                string strSql = "select * from OrderState";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
