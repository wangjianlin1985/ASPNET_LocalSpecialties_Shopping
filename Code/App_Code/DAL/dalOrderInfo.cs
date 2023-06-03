using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*������Ϣҵ���߼���ʵ��*/
    public class dalOrderInfo
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��Ӷ�����Ϣʵ��*/
        public static bool AddOrderInfo(ENTITY.OrderInfo orderInfo)
        {
            bool isOk = true;
            string sql = "insert into OrderInfo(orderNo,realName,telephone,address,postcode,orderTime,orderState,payWay,trasportWay,username) values(@orderNo,@realName,@telephone,@address,@postcode,@orderTime,@orderState,@payWay,@trasportWay,@username)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@orderNo",SqlDbType.VarChar),
             new SqlParameter("@realName",SqlDbType.VarChar),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@address",SqlDbType.VarChar),
             new SqlParameter("@postcode",SqlDbType.VarChar),
             new SqlParameter("@orderTime",SqlDbType.DateTime),
             new SqlParameter("@orderState",SqlDbType.Int),
             new SqlParameter("@payWay",SqlDbType.Int),
             new SqlParameter("@trasportWay",SqlDbType.Int),
             new SqlParameter("@username",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = orderInfo.orderNo; //�������
            parm[1].Value = orderInfo.realName; //��ʵ����
            parm[2].Value = orderInfo.telephone; //�ջ��˵绰
            parm[3].Value = orderInfo.address; //�ջ���ַ
            parm[4].Value = orderInfo.postcode; //��������
            parm[5].Value = orderInfo.orderTime; //�µ�ʱ��
            parm[6].Value = orderInfo.orderState; //����״̬
            parm[7].Value = orderInfo.payWay; //���ʽ
            parm[8].Value = orderInfo.trasportWay; //���ͷ�ʽ
            parm[9].Value = orderInfo.username; //�û���


            /*ִ��sql���ж�����Ϣ���*/
            isOk = DBHelp.ExecuteNonQuery(sql, parm) > 0;
            if (!isOk) return false; 


            //�����û�����ȡ�����ﳵ�е���ϸ��Ŀ
            DataSet goodCartInfoDs = BLL.bllCosmeticCart.QueryGoodCartInfo(orderInfo.username);
            for (int i = 0; i < goodCartInfoDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = goodCartInfoDs.Tables[0].Rows[i];
                ENTITY.OrderDetail orderDetail = new ENTITY.OrderDetail();
                orderDetail.orderNo = orderInfo.orderNo;
                orderDetail.userObj = orderInfo.username;
                orderDetail.cosmeticObj = Convert.ToInt32(dr["cosmeticId"]);
                orderDetail.count = Convert.ToInt32(dr["count"]);
                orderDetail.price = Convert.ToSingle(dr["price"]);
                /*�����ϸ��Ŀ��¼*/
                isOk = BLL.bllOrderDetail.AddOrderDetail(orderDetail);
                if (!isOk) return false;

                /*�������ز��Ŀ��*/
                ENTITY.CosmeticInfo cosmeticInfo = BLL.bllCosmeticInfo.getSomeCosmeticInfo(orderDetail.cosmeticObj);
                
                cosmeticInfo.totalCount = cosmeticInfo.totalCount - orderDetail.count; //������

                BLL.bllCosmeticInfo.EditCosmeticInfo(cosmeticInfo);//�������ز���Ϣ
            }

            /*��չ��ﳵ*/
            isOk = BLL.bllCosmeticCart.DelCosmeticCartByUsername(orderInfo.username);


            return isOk;

              
        }

        /*����orderNo��ȡĳ��������Ϣ��¼*/
        public static ENTITY.OrderInfo getSomeOrderInfo(string orderNo)
        {
            /*������ѯsql*/
            string sql = "select * from OrderInfo where orderNo='" + orderNo + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.OrderInfo orderInfo = new ENTITY.OrderInfo();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                orderInfo.orderNo = DataRead["orderNo"].ToString();
                orderInfo.realName = DataRead["realName"].ToString();
                orderInfo.telephone = DataRead["telephone"].ToString();
                orderInfo.address = DataRead["address"].ToString();
                orderInfo.postcode = DataRead["postcode"].ToString();
                orderInfo.orderTime = Convert.ToDateTime(DataRead["orderTime"].ToString());
                orderInfo.orderState = Convert.ToInt32(DataRead["orderState"]);
                orderInfo.payWay = Convert.ToInt32(DataRead["payWay"]);
                orderInfo.trasportWay = Convert.ToInt32(DataRead["trasportWay"]);
                orderInfo.username = DataRead["username"].ToString();
            }
            return orderInfo;
        }

        /*���¶�����Ϣʵ��*/
        public static bool EditOrderInfo(ENTITY.OrderInfo orderInfo)
        {
            string sql = "update OrderInfo set realName=@realName,telephone=@telephone,address=@address,postcode=@postcode,orderTime=@orderTime,orderState=@orderState,payWay=@payWay,trasportWay=@trasportWay,username=@username where orderNo=@orderNo";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@realName",SqlDbType.VarChar),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@address",SqlDbType.VarChar),
             new SqlParameter("@postcode",SqlDbType.VarChar),
             new SqlParameter("@orderTime",SqlDbType.DateTime),
             new SqlParameter("@orderState",SqlDbType.Int),
             new SqlParameter("@payWay",SqlDbType.Int),
             new SqlParameter("@trasportWay",SqlDbType.Int),
             new SqlParameter("@username",SqlDbType.VarChar),
             new SqlParameter("@orderNo",SqlDbType.VarChar)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = orderInfo.realName;
            parm[1].Value = orderInfo.telephone;
            parm[2].Value = orderInfo.address;
            parm[3].Value = orderInfo.postcode;
            parm[4].Value = orderInfo.orderTime;
            parm[5].Value = orderInfo.orderState;
            parm[6].Value = orderInfo.payWay;
            parm[7].Value = orderInfo.trasportWay;
            parm[8].Value = orderInfo.username;
            parm[9].Value = orderInfo.orderNo;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��������Ϣ*/
        public static bool DelOrderInfo(string p)
        {
            string sql = "";
            string[] ids = p.Split(',');
            for(int i=0;i<ids.Length;i++)
            {
                if(i != ids.Length-1)
                  sql += "'" + ids[i] + "',";
                else
                  sql += "'" + ids[i] + "'";
            }
            sql = "delete from OrderInfo where orderNo in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ������Ϣ*/
        public static System.Data.DataTable GetOrderInfo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from OrderInfo";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "orderNo", strShow, strSql, strWhere, " orderNo asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllOrderInfo()
        {
            try
            {
                string strSql = "select * from OrderInfo";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
