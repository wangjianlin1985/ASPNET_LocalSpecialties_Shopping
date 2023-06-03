using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*土特产分类业务逻辑层*/
    public class bllCosmeticSmallClass{
        /*添加土特产分类*/
        public static bool AddCosmeticSmallClass(ENTITY.CosmeticSmallClass cosmeticSmallClass)
        {
            return DAL.dalCosmeticSmallClass.AddCosmeticSmallClass(cosmeticSmallClass);
        }

        /*根据smallClassId获取某条土特产分类记录*/
        public static ENTITY.CosmeticSmallClass getSomeCosmeticSmallClass(int smallClassId)
        {
            return DAL.dalCosmeticSmallClass.getSomeCosmeticSmallClass(smallClassId);
        }

        /*更新土特产分类*/
        public static bool EditCosmeticSmallClass(ENTITY.CosmeticSmallClass cosmeticSmallClass)
        {
            return DAL.dalCosmeticSmallClass.EditCosmeticSmallClass(cosmeticSmallClass);
        }

        /*删除土特产分类*/
        public static bool DelCosmeticSmallClass(string p)
        {
            return DAL.dalCosmeticSmallClass.DelCosmeticSmallClass(p);
        }

        /*根据条件分页查询土特产分类*/
        public static System.Data.DataTable GetCosmeticSmallClass(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCosmeticSmallClass.GetCosmeticSmallClass(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的土特产分类*/
        public static System.Data.DataSet getAllCosmeticSmallClass()
        {
            return DAL.dalCosmeticSmallClass.getAllCosmeticSmallClass();
        }
    }
}
