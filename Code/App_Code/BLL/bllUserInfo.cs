using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*用户信息业务逻辑层*/
    public class bllUserInfo{

        public static bool ulogin(String username,String password)
        {
            return DAL.dalUserInfo.ulogin(username, password);
        } 

        /*添加用户信息*/
        public static bool AddUserInfo(ENTITY.UserInfo userInfo)
        {
            return DAL.dalUserInfo.AddUserInfo(userInfo);
        }

        /*根据username获取某条用户信息记录*/
        public static ENTITY.UserInfo getSomeUserInfo(string username)
        {
            return DAL.dalUserInfo.getSomeUserInfo(username);
        }

        /*更新用户信息*/
        public static bool EditUserInfo(ENTITY.UserInfo userInfo)
        {
            return DAL.dalUserInfo.EditUserInfo(userInfo);
        }

        /*删除用户信息*/
        public static bool DelUserInfo(string p)
        {
            return DAL.dalUserInfo.DelUserInfo(p);
        }

        /*根据条件分页查询用户信息*/
        public static System.Data.DataTable GetUserInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalUserInfo.GetUserInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的用户信息*/
        public static System.Data.DataSet getAllUserInfo()
        {
            return DAL.dalUserInfo.getAllUserInfo();
        }
    }
}
