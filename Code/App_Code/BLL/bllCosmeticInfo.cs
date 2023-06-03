using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*土特产信息业务逻辑层*/
    public class bllCosmeticInfo{
        /*添加土特产信息*/
        public static bool AddCosmeticInfo(ENTITY.CosmeticInfo cosmeticInfo)
        {
            return DAL.dalCosmeticInfo.AddCosmeticInfo(cosmeticInfo);
        }

        /*根据cosmeticId获取某条土特产信息记录*/
        public static ENTITY.CosmeticInfo getSomeCosmeticInfo(int cosmeticId)
        {
            return DAL.dalCosmeticInfo.getSomeCosmeticInfo(cosmeticId);
        }

        /*更新土特产信息*/
        public static bool EditCosmeticInfo(ENTITY.CosmeticInfo cosmeticInfo)
        {
            return DAL.dalCosmeticInfo.EditCosmeticInfo(cosmeticInfo);
        }

        /*删除土特产信息*/
        public static bool DelCosmeticInfo(string p)
        {
            return DAL.dalCosmeticInfo.DelCosmeticInfo(p);
        }

        /*根据条件分页查询土特产信息*/
        public static System.Data.DataTable GetCosmeticInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCosmeticInfo.GetCosmeticInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的土特产信息*/
        public static System.Data.DataSet getAllCosmeticInfo()
        {
            return DAL.dalCosmeticInfo.getAllCosmeticInfo();
        }
    }
}
