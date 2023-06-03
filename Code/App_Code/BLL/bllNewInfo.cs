using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*������Ϣҵ���߼���*/
    public class bllNewInfo{
        /*���������Ϣ*/
        public static bool AddNewInfo(ENTITY.NewInfo newInfo)
        {
            return DAL.dalNewInfo.AddNewInfo(newInfo);
        }

        /*����newsId��ȡĳ��������Ϣ��¼*/
        public static ENTITY.NewInfo getSomeNewInfo(int newsId)
        {
            return DAL.dalNewInfo.getSomeNewInfo(newsId);
        }

        /*����������Ϣ*/
        public static bool EditNewInfo(ENTITY.NewInfo newInfo)
        {
            return DAL.dalNewInfo.EditNewInfo(newInfo);
        }

        /*ɾ��������Ϣ*/
        public static bool DelNewInfo(string p)
        {
            return DAL.dalNewInfo.DelNewInfo(p);
        }

        /*����������ҳ��ѯ������Ϣ*/
        public static System.Data.DataTable GetNewInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalNewInfo.GetNewInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�������Ϣ*/
        public static System.Data.DataSet getAllNewInfo()
        {
            return DAL.dalNewInfo.getAllNewInfo();
        }
    }
}
