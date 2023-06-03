using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*新闻信息业务逻辑层*/
    public class bllNewInfo{
        /*添加新闻信息*/
        public static bool AddNewInfo(ENTITY.NewInfo newInfo)
        {
            return DAL.dalNewInfo.AddNewInfo(newInfo);
        }

        /*根据newsId获取某条新闻信息记录*/
        public static ENTITY.NewInfo getSomeNewInfo(int newsId)
        {
            return DAL.dalNewInfo.getSomeNewInfo(newsId);
        }

        /*更新新闻信息*/
        public static bool EditNewInfo(ENTITY.NewInfo newInfo)
        {
            return DAL.dalNewInfo.EditNewInfo(newInfo);
        }

        /*删除新闻信息*/
        public static bool DelNewInfo(string p)
        {
            return DAL.dalNewInfo.DelNewInfo(p);
        }

        /*根据条件分页查询新闻信息*/
        public static System.Data.DataTable GetNewInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalNewInfo.GetNewInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的新闻信息*/
        public static System.Data.DataSet getAllNewInfo()
        {
            return DAL.dalNewInfo.getAllNewInfo();
        }
    }
}
