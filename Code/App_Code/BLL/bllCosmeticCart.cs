using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*购物车业务逻辑层*/
    public class bllCosmeticCart{


        /*根据用户名查询购物车*/
        public static System.Data.DataSet QueryGoodCartInfo(string username)
        {
            return DAL.dalCosmeticCart.QueryGoodCartInfo(username);
        }

        /*更新购物车土特产数量*/
        public static bool UpdateGoodCartInfo(int goodCartId, int goodCount)
        {
            return DAL.dalCosmeticCart.UpdateGoodCartInfo(goodCartId, goodCount);
        }

        /*添加购物车*/
        public static bool AddCosmeticCart(ENTITY.CosmeticCart cosmeticCart)
        {
            return DAL.dalCosmeticCart.AddCosmeticCart(cosmeticCart);
        }

        
        /*根据用户名得到购物车中总的土特产数量*/
        public static int GetTotalGoodCountInCart(string username)
        {
            return DAL.dalCosmeticCart.GetTotalGoodCountInCart(username);
        }

        /*根据用户名得到购物车中土特产的总价格*/
        public static float GetTotalPriceInCart(string username)
        {
            return DAL.dalCosmeticCart.GetTotalPriceInCart(username);
        }


        /*根据cartId获取某条购物车记录*/
        public static ENTITY.CosmeticCart getSomeCosmeticCart(int cartId)
        {
            return DAL.dalCosmeticCart.getSomeCosmeticCart(cartId);
        }

        /*更新购物车*/
        public static bool EditCosmeticCart(ENTITY.CosmeticCart cosmeticCart)
        {
            return DAL.dalCosmeticCart.EditCosmeticCart(cosmeticCart);
        }

        /*删除购物车*/
        public static bool DelCosmeticCart(string p)
        {
            return DAL.dalCosmeticCart.DelCosmeticCart(p);
        }

        /*根据用户名清空购物车*/
        public static bool DelCosmeticCartByUsername(string username)
        {
            return DAL.dalCosmeticCart.DelCosmeticCartByUsername(username);
        }

        /*根据条件分页查询购物车*/
        public static System.Data.DataTable GetCosmeticCart(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCosmeticCart.GetCosmeticCart(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的购物车*/
        public static System.Data.DataSet getAllCosmeticCart()
        {
            return DAL.dalCosmeticCart.getAllCosmeticCart();
        }
    }
}
