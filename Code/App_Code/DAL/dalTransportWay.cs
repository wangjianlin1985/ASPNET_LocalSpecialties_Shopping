using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*���ͷ�ʽҵ���߼���ʵ��*/
    public class dalTransportWay
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*������ͷ�ʽʵ��*/
        public static bool AddTransportWay(ENTITY.TransportWay transportWay)
        {
            string sql = "insert into TransportWay(transportName) values(@transportName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@transportName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = transportWay.transportName; //���з�ʽ����

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����transportId��ȡĳ�����ͷ�ʽ��¼*/
        public static ENTITY.TransportWay getSomeTransportWay(int transportId)
        {
            /*������ѯsql*/
            string sql = "select * from TransportWay where transportId=" + transportId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.TransportWay transportWay = new ENTITY.TransportWay();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                transportWay.transportId = Convert.ToInt32(DataRead["transportId"]);
                transportWay.transportName = DataRead["transportName"].ToString();
            }
            return transportWay;
        }

        /*�������ͷ�ʽʵ��*/
        public static bool EditTransportWay(ENTITY.TransportWay transportWay)
        {
            string sql = "update TransportWay set transportName=@transportName where transportId=@transportId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@transportName",SqlDbType.VarChar),
             new SqlParameter("@transportId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = transportWay.transportName;
            parm[1].Value = transportWay.transportId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ�����ͷ�ʽ*/
        public static bool DelTransportWay(string p)
        {
            string sql = "delete from TransportWay where transportId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ���ͷ�ʽ*/
        public static System.Data.DataTable GetTransportWay(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from TransportWay";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "transportId", strShow, strSql, strWhere, " transportId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllTransportWay()
        {
            try
            {
                string strSql = "select * from TransportWay";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
