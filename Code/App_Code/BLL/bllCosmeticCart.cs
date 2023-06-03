using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*���ﳵҵ���߼���*/
    public class bllCosmeticCart{


        /*�����û�����ѯ���ﳵ*/
        public static System.Data.DataSet QueryGoodCartInfo(string username)
        {
            return DAL.dalCosmeticCart.QueryGoodCartInfo(username);
        }

        /*���¹��ﳵ���ز�����*/
        public static bool UpdateGoodCartInfo(int goodCartId, int goodCount)
        {
            return DAL.dalCosmeticCart.UpdateGoodCartInfo(goodCartId, goodCount);
        }

        /*��ӹ��ﳵ*/
        public static bool AddCosmeticCart(ENTITY.CosmeticCart cosmeticCart)
        {
            return DAL.dalCosmeticCart.AddCosmeticCart(cosmeticCart);
        }

        
        /*�����û����õ����ﳵ���ܵ����ز�����*/
        public static int GetTotalGoodCountInCart(string username)
        {
            return DAL.dalCosmeticCart.GetTotalGoodCountInCart(username);
        }

        /*�����û����õ����ﳵ�����ز����ܼ۸�*/
        public static float GetTotalPriceInCart(string username)
        {
            return DAL.dalCosmeticCart.GetTotalPriceInCart(username);
        }


        /*����cartId��ȡĳ�����ﳵ��¼*/
        public static ENTITY.CosmeticCart getSomeCosmeticCart(int cartId)
        {
            return DAL.dalCosmeticCart.getSomeCosmeticCart(cartId);
        }

        /*���¹��ﳵ*/
        public static bool EditCosmeticCart(ENTITY.CosmeticCart cosmeticCart)
        {
            return DAL.dalCosmeticCart.EditCosmeticCart(cosmeticCart);
        }

        /*ɾ�����ﳵ*/
        public static bool DelCosmeticCart(string p)
        {
            return DAL.dalCosmeticCart.DelCosmeticCart(p);
        }

        /*�����û�����չ��ﳵ*/
        public static bool DelCosmeticCartByUsername(string username)
        {
            return DAL.dalCosmeticCart.DelCosmeticCartByUsername(username);
        }

        /*����������ҳ��ѯ���ﳵ*/
        public static System.Data.DataTable GetCosmeticCart(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCosmeticCart.GetCosmeticCart(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĹ��ﳵ*/
        public static System.Data.DataSet getAllCosmeticCart()
        {
            return DAL.dalCosmeticCart.getAllCosmeticCart();
        }
    }
}
