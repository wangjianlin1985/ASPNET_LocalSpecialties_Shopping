using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*������ϸ��Ŀҵ���߼���ʵ��*/
    public class dalOrderDetail
    {
        /*��ִ�е�sql���*/
        public static string sql = "";


        /*���ݶ�����Ų�ѯ��ϸ��Ŀ��Ϣ*/
        public static System.Data.DataSet QueryOrderDetailByOrderNo(string orderNo)
        {
            try
            {
                string strSql = "select * from orderDetailView where orderNo='" + orderNo + "'";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /*���ݶ����Ż�ȡ�ܵ����ز�����*/
        public static int GetTotalGoodCountByOrderNo(string orderNo)
        {
            string sqlString = "select sum(count) as totalGoodCount from [OrderDetail] where orderNo='" + orderNo + "'";
            return Convert.ToInt32(DBHelp.ExecuteScalar(sqlString, null));
        }
        /*���ݶ����Ż�ȡ���ز����ܼ۸�*/
        public static float GetTotalPriceByOrderNo(string orderNo)
        {
            float totalPrice = 0.0f;
            /*��ѯ�ö����ŵ��������ز��嵥*/
            string sqlString = "select * from [OrderDetail] where orderNo='" + orderNo + "'";
            DataSet orderDetailDs = DBHelp.ExecuteDataSet(sqlString, null);
            /*�����ö������ز��嵥��¼�������ܵļ۸�*/
            for (int i = 0; i < orderDetailDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = orderDetailDs.Tables[0].Rows[i];
                float price = Convert.ToSingle(dr["price"]);
                int number = Convert.ToInt32(dr["count"]);
                totalPrice += (price * number);
            }
            return totalPrice;
        }



        /*��Ӷ�����ϸ��Ŀʵ��*/
        public static bool AddOrderDetail(ENTITY.OrderDetail orderDetail)
        {
            string sql = "insert into OrderDetail(orderNo,userObj,cosmeticObj,count,price) values(@orderNo,@userObj,@cosmeticObj,@count,@price)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@orderNo",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@cosmeticObj",SqlDbType.Int),
             new SqlParameter("@count",SqlDbType.Int),
             new SqlParameter("@price",SqlDbType.Float)
            };
            /*��������ֵ*/
            parm[0].Value = orderDetail.orderNo; //��������
            parm[1].Value = orderDetail.userObj; //�����ͻ�
            parm[2].Value = orderDetail.cosmeticObj; //�������ز�
            parm[3].Value = orderDetail.count; //��������
            parm[4].Value = orderDetail.price; //���򵥼�

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����detailId��ȡĳ��������ϸ��Ŀ��¼*/
        public static ENTITY.OrderDetail getSomeOrderDetail(int detailId)
        {
            /*������ѯsql*/
            string sql = "select * from OrderDetail where detailId=" + detailId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.OrderDetail orderDetail = new ENTITY.OrderDetail();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                orderDetail.detailId = Convert.ToInt32(DataRead["detailId"]);
                orderDetail.orderNo = DataRead["orderNo"].ToString();
                orderDetail.userObj = DataRead["userObj"].ToString();
                orderDetail.cosmeticObj = Convert.ToInt32(DataRead["cosmeticObj"]);
                orderDetail.count = Convert.ToInt32(DataRead["count"]);
                orderDetail.price = float.Parse(DataRead["price"].ToString());
            }
            return orderDetail;
        }

        /*���¶�����ϸ��Ŀʵ��*/
        public static bool EditOrderDetail(ENTITY.OrderDetail orderDetail)
        {
            string sql = "update OrderDetail set orderNo=@orderNo,userObj=@userObj,cosmeticObj=@cosmeticObj,count=@count,price=@price where detailId=@detailId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@orderNo",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@cosmeticObj",SqlDbType.Int),
             new SqlParameter("@count",SqlDbType.Int),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@detailId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = orderDetail.orderNo;
            parm[1].Value = orderDetail.userObj;
            parm[2].Value = orderDetail.cosmeticObj;
            parm[3].Value = orderDetail.count;
            parm[4].Value = orderDetail.price;
            parm[5].Value = orderDetail.detailId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��������ϸ��Ŀ*/
        public static bool DelOrderDetail(string p)
        {
            string sql = "delete from OrderDetail where detailId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ������ϸ��Ŀ*/
        public static System.Data.DataTable GetOrderDetail(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from OrderDetail";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "detailId", strShow, strSql, strWhere, " detailId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllOrderDetail()
        {
            try
            {
                string strSql = "select * from OrderDetail";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
