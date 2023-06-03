using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*���ز���Ϣҵ���߼���ʵ��*/
    public class dalCosmeticInfo
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*������ز���Ϣʵ��*/
        public static bool AddCosmeticInfo(ENTITY.CosmeticInfo cosmeticInfo)
        {
            string sql = "insert into CosmeticInfo(classObj,cosmeticName,price,totalCount,cosmeticImage,cosmeticIntroduce) values(@classObj,@cosmeticName,@price,@totalCount,@cosmeticImage,@cosmeticIntroduce)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@classObj",SqlDbType.Int),
             new SqlParameter("@cosmeticName",SqlDbType.VarChar),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@totalCount",SqlDbType.Int),
             new SqlParameter("@cosmeticImage",SqlDbType.VarChar),
             new SqlParameter("@cosmeticIntroduce",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = cosmeticInfo.classObj; //�������
            parm[1].Value = cosmeticInfo.cosmeticName; //���ز�����
            parm[2].Value = cosmeticInfo.price; //���ز��۸�
            parm[3].Value = cosmeticInfo.totalCount; //���ز�ʣ������
            parm[4].Value = cosmeticInfo.cosmeticImage; //���ز�ͼƬ
            parm[5].Value = cosmeticInfo.cosmeticIntroduce; //���ز�˵��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����cosmeticId��ȡĳ�����ز���Ϣ��¼*/
        public static ENTITY.CosmeticInfo getSomeCosmeticInfo(int cosmeticId)
        {
            /*������ѯsql*/
            string sql = "select * from CosmeticInfo where cosmeticId=" + cosmeticId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.CosmeticInfo cosmeticInfo = new ENTITY.CosmeticInfo();
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*�������ز���Ϣʵ��*/
        public static bool EditCosmeticInfo(ENTITY.CosmeticInfo cosmeticInfo)
        {
            string sql = "update CosmeticInfo set classObj=@classObj,cosmeticName=@cosmeticName,price=@price,totalCount=@totalCount,cosmeticImage=@cosmeticImage,cosmeticIntroduce=@cosmeticIntroduce where cosmeticId=@cosmeticId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@classObj",SqlDbType.Int),
             new SqlParameter("@cosmeticName",SqlDbType.VarChar),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@totalCount",SqlDbType.Int),
             new SqlParameter("@cosmeticImage",SqlDbType.VarChar),
             new SqlParameter("@cosmeticIntroduce",SqlDbType.VarChar),
             new SqlParameter("@cosmeticId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = cosmeticInfo.classObj;
            parm[1].Value = cosmeticInfo.cosmeticName;
            parm[2].Value = cosmeticInfo.price;
            parm[3].Value = cosmeticInfo.totalCount; 
            parm[4].Value = cosmeticInfo.cosmeticImage;
            parm[5].Value = cosmeticInfo.cosmeticIntroduce;
            parm[6].Value = cosmeticInfo.cosmeticId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ�����ز���Ϣ*/
        public static bool DelCosmeticInfo(string p)
        {
            string sql = "delete from CosmeticInfo where cosmeticId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ���ز���Ϣ*/
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
