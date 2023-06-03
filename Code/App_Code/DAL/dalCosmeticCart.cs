using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*���ﳵҵ���߼���ʵ��*/
    public class dalCosmeticCart
    {
        /*��ִ�е�sql���*/
        public static string sql = "";



        /*�����û�����ѯ���ﳵ*/
        public static DataSet QueryGoodCartInfo(string username)
        {
            try
            {
                string strSql = "select * from cosmeticCartView where username='" + username + "'";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /*���¹��ﳵ���ز�����*/
        public static bool UpdateGoodCartInfo(int goodCartId, int goodCount)
        {
            string sql = "update CosmeticCart set count=@count where cartId=@cartId";
             SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@count",SqlDbType.Int),
             new SqlParameter("@cartId",SqlDbType.Int) };
            /*��������ֵ*/
            parm[0].Value = goodCount; //���ز�����
            parm[1].Value = goodCartId; //���ﳵ���

             /*ִ��sql���й��ﳵ����*/
             return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }



        /*��ӹ��ﳵʵ��*/
        public static bool AddCosmeticCart(ENTITY.CosmeticCart cosmeticCart)
        {
            /*��ѯ���ﳵ�����Ƿ���ڸ��û���������ز��ļ�¼*/
            string sql = "select cartId from CosmeticCart where username=@username and cosmeticId=@cosmeticId";
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@username",SqlDbType.VarChar),
             new SqlParameter("@cosmeticId",SqlDbType.Int) };
            /*��������ֵ*/
            parm[0].Value = cosmeticCart.username; //�û���
            parm[1].Value = cosmeticCart.cosmeticId; //���ز����

            if (DBHelp.ExecuteScalar(sql, parm) == null)
            {
                /*��������ھ�����һ����¼*/ 
                sql = "insert into CosmeticCart(username,cosmeticId,price,count) values(@username,@cosmeticId,@price,@count)";
                /*����sql����*/
                parm = new SqlParameter[] {
                    new SqlParameter("@username",SqlDbType.VarChar),
                    new SqlParameter("@cosmeticId",SqlDbType.Int),
                    new SqlParameter("@price",SqlDbType.Float),
                    new SqlParameter("@count",SqlDbType.Int)
                  };
                /*��������ֵ*/
                parm[0].Value = cosmeticCart.username; //�û���
                parm[1].Value = cosmeticCart.cosmeticId; //���ز����
                parm[2].Value = cosmeticCart.price; //����
                parm[3].Value = cosmeticCart.count; //��������

                /*ִ��sql�������*/
                return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
            }
            else
            {
                /*����Ѿ������ˣ��͸������ز�����*/
                sql = "update CosmeticCart set count = count + 1 where username=@username and cosmeticId=@cosmeticId";
                parm = new SqlParameter[] {
                    new SqlParameter("@username",SqlDbType.VarChar),
                    new SqlParameter("@cosmeticId",SqlDbType.Int) };
                /*��������ֵ*/
                parm[0].Value = cosmeticCart.username; //�û���
                parm[1].Value = cosmeticCart.cosmeticId; //���ز����

                /*ִ��sql���и���*/
                return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
            }



        }


        /*�����û����õ����ﳵ���ܵ����ز�����*/
        public static int GetTotalGoodCountInCart(string username)
        {
            string sqlString = "select sum(count) as totalGoodCount from [CosmeticCart] where username='" + username + "'";
            return Convert.ToInt32(DBHelp.ExecuteScalar(sqlString,null));
        }
        /*�����û����õ����ﳵ�����ز����ܼ۸�*/
        public static float GetTotalPriceInCart(string username)
        {
            float totalPrice = 0.0f;
            /*��ѯ��Ա���Ĺ��ﳵ*/
            string sqlString = "select * from [CosmeticCart] where username='" + username + "'";
            DataSet cartInfoDs = DBHelp.ExecuteDataSet(sqlString, null);
            /*�������ﳵ��ÿ�����ز����ۼ�¼�������ܵļ۸�*/
            for (int i = 0; i < cartInfoDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = cartInfoDs.Tables[0].Rows[i];
                float price = Convert.ToSingle(dr["price"]);
                int number = Convert.ToInt32(dr["count"]);
                totalPrice += (price * number);
            }
            return totalPrice;
        }



        /*����cartId��ȡĳ�����ﳵ��¼*/
        public static ENTITY.CosmeticCart getSomeCosmeticCart(int cartId)
        {
            /*������ѯsql*/
            string sql = "select * from CosmeticCart where cartId=" + cartId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.CosmeticCart cosmeticCart = new ENTITY.CosmeticCart();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                cosmeticCart.cartId = Convert.ToInt32(DataRead["cartId"]);
                cosmeticCart.username = DataRead["username"].ToString();
                cosmeticCart.cosmeticId = Convert.ToInt32(DataRead["cosmeticId"]);
                cosmeticCart.price = float.Parse(DataRead["price"].ToString());
                cosmeticCart.count = Convert.ToInt32(DataRead["count"]);
            }
            return cosmeticCart;
        }

        /*���¹��ﳵʵ��*/
        public static bool EditCosmeticCart(ENTITY.CosmeticCart cosmeticCart)
        {
            string sql = "update CosmeticCart set username=@username,cosmeticId=@cosmeticId,price=@price,count=@count where cartId=@cartId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@username",SqlDbType.VarChar),
             new SqlParameter("@cosmeticId",SqlDbType.Int),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@count",SqlDbType.Int),
             new SqlParameter("@cartId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = cosmeticCart.username;
            parm[1].Value = cosmeticCart.cosmeticId;
            parm[2].Value = cosmeticCart.price;
            parm[3].Value = cosmeticCart.count;
            parm[4].Value = cosmeticCart.cartId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ�����ﳵ*/
        public static bool DelCosmeticCart(string p)
        {
            string sql = "delete from CosmeticCart where cartId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*�����û�����չ��ﳵ*/
        public static bool DelCosmeticCartByUsername(string username)
        {

            string sql = "delete from CosmeticCart where username='" + username + "'";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }



        /*��ѯ���ﳵ*/
        public static System.Data.DataTable GetCosmeticCart(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from CosmeticCart";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "cartId", strShow, strSql, strWhere, " cartId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllCosmeticCart()
        {
            try
            {
                string strSql = "select * from CosmeticCart";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
