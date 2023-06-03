using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*用户信息业务逻辑层实现*/
    public class dalUserInfo
    {
        /*待执行的sql语句*/
        public static string sql = "";


        public static bool ulogin(String username,String password)
        {
            string sql = @"select username from UserInfo where username =@Customername and password =@customerpwd";
            SqlParameter[] para = new SqlParameter[] { 
             new SqlParameter("@Customername",SqlDbType.VarChar),
             new SqlParameter("@customerpwd",SqlDbType.VarChar), 
           };
            para[0].Value = username;
            para[1].Value = password;
            return (DBHelp.ExecuteScalar(sql, para) != null) ? true : false;
        }




        /*添加用户信息实现*/
        public static bool AddUserInfo(ENTITY.UserInfo userInfo)
        {
            string sql = "insert into UserInfo(username,password,realName,city,cardTypeObj,cardNumber,telephone,emailAddress,userPhoto,address,postcode) values(@username,@password,@realName,@city,@cardTypeObj,@cardNumber,@telephone,@emailAddress,@userPhoto,@address,@postcode)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@username",SqlDbType.VarChar),
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@realName",SqlDbType.VarChar),
             new SqlParameter("@city",SqlDbType.VarChar),
             new SqlParameter("@cardTypeObj",SqlDbType.Int),
             new SqlParameter("@cardNumber",SqlDbType.VarChar),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@emailAddress",SqlDbType.VarChar),
             new SqlParameter("@userPhoto",SqlDbType.VarChar),
             new SqlParameter("@address",SqlDbType.VarChar),
             new SqlParameter("@postcode",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = userInfo.username; //用户名
            parm[1].Value = userInfo.password; //登陆密码
            parm[2].Value = userInfo.realName; //真实姓名
            parm[3].Value = userInfo.city; //所在城市
            parm[4].Value = userInfo.cardTypeObj; //证件类别
            parm[5].Value = userInfo.cardNumber; //证件号码
            parm[6].Value = userInfo.telephone; //联系电话
            parm[7].Value = userInfo.emailAddress; //Email
            parm[8].Value = userInfo.userPhoto; //用户头像
            parm[9].Value = userInfo.address; //联系地址
            parm[10].Value = userInfo.postcode; //邮政编码

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据username获取某条用户信息记录*/
        public static ENTITY.UserInfo getSomeUserInfo(string username)
        {
            /*构建查询sql*/
            string sql = "select * from UserInfo where username='" + username + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.UserInfo userInfo = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                userInfo = new ENTITY.UserInfo(); 
                userInfo.username = DataRead["username"].ToString();
                userInfo.password = DataRead["password"].ToString();
                userInfo.realName = DataRead["realName"].ToString();
                userInfo.city = DataRead["city"].ToString();
                userInfo.cardTypeObj = Convert.ToInt32(DataRead["cardTypeObj"]);
                userInfo.cardNumber = DataRead["cardNumber"].ToString();
                userInfo.telephone = DataRead["telephone"].ToString();
                userInfo.emailAddress = DataRead["emailAddress"].ToString();
                userInfo.userPhoto = DataRead["userPhoto"].ToString();
                userInfo.address = DataRead["address"].ToString();
                userInfo.postcode = DataRead["postcode"].ToString();
            }
            return userInfo;
        }

        /*更新用户信息实现*/
        public static bool EditUserInfo(ENTITY.UserInfo userInfo)
        {
            string sql = "update UserInfo set password=@password,realName=@realName,city=@city,cardTypeObj=@cardTypeObj,cardNumber=@cardNumber,telephone=@telephone,emailAddress=@emailAddress,userPhoto=@userPhoto,address=@address,postcode=@postcode where username=@username";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@realName",SqlDbType.VarChar),
             new SqlParameter("@city",SqlDbType.VarChar),
             new SqlParameter("@cardTypeObj",SqlDbType.Int),
             new SqlParameter("@cardNumber",SqlDbType.VarChar),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@emailAddress",SqlDbType.VarChar),
             new SqlParameter("@userPhoto",SqlDbType.VarChar),
             new SqlParameter("@address",SqlDbType.VarChar),
             new SqlParameter("@postcode",SqlDbType.VarChar),
             new SqlParameter("@username",SqlDbType.VarChar)
            };
            /*为参数赋值*/
            parm[0].Value = userInfo.password;
            parm[1].Value = userInfo.realName;
            parm[2].Value = userInfo.city;
            parm[3].Value = userInfo.cardTypeObj;
            parm[4].Value = userInfo.cardNumber;
            parm[5].Value = userInfo.telephone;
            parm[6].Value = userInfo.emailAddress;
            parm[7].Value = userInfo.userPhoto;
            parm[8].Value = userInfo.address;
            parm[9].Value = userInfo.postcode;
            parm[10].Value = userInfo.username;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除用户信息*/
        public static bool DelUserInfo(string p)
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
            sql = "delete from UserInfo where username in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询用户信息*/
        public static System.Data.DataTable GetUserInfo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from UserInfo";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "username", strShow, strSql, strWhere, " username asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllUserInfo()
        {
            try
            {
                string strSql = "select * from UserInfo";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
