using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�û���Ϣҵ���߼���*/
    public class bllUserInfo{

        public static bool ulogin(String username,String password)
        {
            return DAL.dalUserInfo.ulogin(username, password);
        } 

        /*����û���Ϣ*/
        public static bool AddUserInfo(ENTITY.UserInfo userInfo)
        {
            return DAL.dalUserInfo.AddUserInfo(userInfo);
        }

        /*����username��ȡĳ���û���Ϣ��¼*/
        public static ENTITY.UserInfo getSomeUserInfo(string username)
        {
            return DAL.dalUserInfo.getSomeUserInfo(username);
        }

        /*�����û���Ϣ*/
        public static bool EditUserInfo(ENTITY.UserInfo userInfo)
        {
            return DAL.dalUserInfo.EditUserInfo(userInfo);
        }

        /*ɾ���û���Ϣ*/
        public static bool DelUserInfo(string p)
        {
            return DAL.dalUserInfo.DelUserInfo(p);
        }

        /*����������ҳ��ѯ�û���Ϣ*/
        public static System.Data.DataTable GetUserInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalUserInfo.GetUserInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е��û���Ϣ*/
        public static System.Data.DataSet getAllUserInfo()
        {
            return DAL.dalUserInfo.getAllUserInfo();
        }
    }
}
