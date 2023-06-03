using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*���ز������ҵ���߼���*/
    public class bllCosmeticBigClass{
        /*������ز������*/
        public static bool AddCosmeticBigClass(ENTITY.CosmeticBigClass cosmeticBigClass)
        {
            return DAL.dalCosmeticBigClass.AddCosmeticBigClass(cosmeticBigClass);
        }

        /*����bigClassId��ȡĳ�����ز�������¼*/
        public static ENTITY.CosmeticBigClass getSomeCosmeticBigClass(int bigClassId)
        {
            return DAL.dalCosmeticBigClass.getSomeCosmeticBigClass(bigClassId);
        }

        /*�������ز������*/
        public static bool EditCosmeticBigClass(ENTITY.CosmeticBigClass cosmeticBigClass)
        {
            return DAL.dalCosmeticBigClass.EditCosmeticBigClass(cosmeticBigClass);
        }

        /*ɾ�����ز������*/
        public static bool DelCosmeticBigClass(string p)
        {
            return DAL.dalCosmeticBigClass.DelCosmeticBigClass(p);
        }

        /*����������ҳ��ѯ���ز������*/
        public static System.Data.DataTable GetCosmeticBigClass(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCosmeticBigClass.GetCosmeticBigClass(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е����ز������*/
        public static System.Data.DataSet getAllCosmeticBigClass()
        {
            return DAL.dalCosmeticBigClass.getAllCosmeticBigClass();
        }
    }
}
