using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectCIS.Models
{
    public class Cart
    {
        public int id { get; set; }

       public int amount { get; set; }

        public int customerId { get; set; }

        public string purchased { get; set; }

        public bool incart { get; set; }

        public int productId { get; set; }
        public int discount { get; set; }


        public static bool addCart(int amount, int customerId,int productId, bool incart, string  purchased, int discount)
        {
            return cartController.addcart(amount, customerId, productId, incart, purchased, discount);
        }

        public static List<Cart> MarkOrder(List<Cart> carts)
        {
           return cartController.MarkOrder(carts);
        }

        public static List<Cart> getOrders(int customerId)
        {
            return cartController.getOrder(customerId);
        }

        public static bool DeleteCart(int cartId)
        {
            return cartController.DeleteCart(cartId);
        }

        public static void UpdateQuantity(int cartId, int quantity)
        {
            cartController.UpdateQuantity(cartId, quantity);
        }

        public static bool addDiscount(int amount, int customer)
        {
            return cartController.addDiscount(amount, customer);
        }

        public static Cart GetReceipt(int customer)
        {
            return cartController.GetReceipt(customer);
        }
    }
}