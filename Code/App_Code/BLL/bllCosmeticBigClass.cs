using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*土特产大类别业务逻辑层*/
    public class bllCosmeticBigClass{
        /*添加土特产大类别*/
        public static bool AddCosmeticBigClass(ENTITY.CosmeticBigClass cosmeticBigClass)
        {
            return DAL.dalCosmeticBigClass.AddCosmeticBigClass(cosmeticBigClass);
        }

        /*根据bigClassId获取某条土特产大类别记录*/
        public static ENTITY.CosmeticBigClass getSomeCosmeticBigClass(int bigClassId)
        {
            return DAL.dalCosmeticBigClass.getSomeCosmeticBigClass(bigClassId);
        }

        /*更新土特产大类别*/
        public static bool EditCosmeticBigClass(ENTITY.CosmeticBigClass cosmeticBigClass)
        {
            return DAL.dalCosmeticBigClass.EditCosmeticBigClass(cosmeticBigClass);
        }

        /*删除土特产大类别*/
        public static bool DelCosmeticBigClass(string p)
        {
            return DAL.dalCosmeticBigClass.DelCosmeticBigClass(p);
        }

        /*根据条件分页查询土特产大类别*/
        public static System.Data.DataTable GetCosmeticBigClass(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCosmeticBigClass.GetCosmeticBigClass(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的土特产大类别*/
        public static System.Data.DataSet getAllCosmeticBigClass()
        {
            return DAL.dalCosmeticBigClass.getAllCosmeticBigClass();
        }
    }
}
