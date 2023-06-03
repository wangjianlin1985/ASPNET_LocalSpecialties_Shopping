using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*���ز���Ϣҵ���߼���*/
    public class bllCosmeticInfo{
        /*������ز���Ϣ*/
        public static bool AddCosmeticInfo(ENTITY.CosmeticInfo cosmeticInfo)
        {
            return DAL.dalCosmeticInfo.AddCosmeticInfo(cosmeticInfo);
        }

        /*����cosmeticId��ȡĳ�����ز���Ϣ��¼*/
        public static ENTITY.CosmeticInfo getSomeCosmeticInfo(int cosmeticId)
        {
            return DAL.dalCosmeticInfo.getSomeCosmeticInfo(cosmeticId);
        }

        /*�������ز���Ϣ*/
        public static bool EditCosmeticInfo(ENTITY.CosmeticInfo cosmeticInfo)
        {
            return DAL.dalCosmeticInfo.EditCosmeticInfo(cosmeticInfo);
        }

        /*ɾ�����ز���Ϣ*/
        public static bool DelCosmeticInfo(string p)
        {
            return DAL.dalCosmeticInfo.DelCosmeticInfo(p);
        }

        /*����������ҳ��ѯ���ز���Ϣ*/
        public static System.Data.DataTable GetCosmeticInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCosmeticInfo.GetCosmeticInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е����ز���Ϣ*/
        public static System.Data.DataSet getAllCosmeticInfo()
        {
            return DAL.dalCosmeticInfo.getAllCosmeticInfo();
        }
    }
}
