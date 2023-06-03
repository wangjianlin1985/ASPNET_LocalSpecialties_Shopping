using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*运送方式业务逻辑层*/
    public class bllTransportWay{
        /*添加运送方式*/
        public static bool AddTransportWay(ENTITY.TransportWay transportWay)
        {
            return DAL.dalTransportWay.AddTransportWay(transportWay);
        }

        /*根据transportId获取某条运送方式记录*/
        public static ENTITY.TransportWay getSomeTransportWay(int transportId)
        {
            return DAL.dalTransportWay.getSomeTransportWay(transportId);
        }

        /*更新运送方式*/
        public static bool EditTransportWay(ENTITY.TransportWay transportWay)
        {
            return DAL.dalTransportWay.EditTransportWay(transportWay);
        }

        /*删除运送方式*/
        public static bool DelTransportWay(string p)
        {
            return DAL.dalTransportWay.DelTransportWay(p);
        }

        /*根据条件分页查询运送方式*/
        public static System.Data.DataTable GetTransportWay(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalTransportWay.GetTransportWay(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的运送方式*/
        public static System.Data.DataSet getAllTransportWay()
        {
            return DAL.dalTransportWay.getAllTransportWay();
        }
    }
}
