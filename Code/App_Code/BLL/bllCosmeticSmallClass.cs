using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*���ز�����ҵ���߼���*/
    public class bllCosmeticSmallClass{
        /*������ز�����*/
        public static bool AddCosmeticSmallClass(ENTITY.CosmeticSmallClass cosmeticSmallClass)
        {
            return DAL.dalCosmeticSmallClass.AddCosmeticSmallClass(cosmeticSmallClass);
        }

        /*����smallClassId��ȡĳ�����ز������¼*/
        public static ENTITY.CosmeticSmallClass getSomeCosmeticSmallClass(int smallClassId)
        {
            return DAL.dalCosmeticSmallClass.getSomeCosmeticSmallClass(smallClassId);
        }

        /*�������ز�����*/
        public static bool EditCosmeticSmallClass(ENTITY.CosmeticSmallClass cosmeticSmallClass)
        {
            return DAL.dalCosmeticSmallClass.EditCosmeticSmallClass(cosmeticSmallClass);
        }

        /*ɾ�����ز�����*/
        public static bool DelCosmeticSmallClass(string p)
        {
            return DAL.dalCosmeticSmallClass.DelCosmeticSmallClass(p);
        }

        /*����������ҳ��ѯ���ز�����*/
        public static System.Data.DataTable GetCosmeticSmallClass(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCosmeticSmallClass.GetCosmeticSmallClass(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е����ز�����*/
        public static System.Data.DataSet getAllCosmeticSmallClass()
        {
            return DAL.dalCosmeticSmallClass.getAllCosmeticSmallClass();
        }
    }
}
