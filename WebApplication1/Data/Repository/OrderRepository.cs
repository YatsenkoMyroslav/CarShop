using WebApplication1.Data.Interaces;
using WebApplication1.Data.Models;

namespace WebApplication1.Data.Repository
{
    public class OrderRepository : IAllOrders
    {
        private readonly AppDbContent appDbContent;
        private readonly ShopCart shopCart;

        public OrderRepository(AppDbContent appDbContent, ShopCart shopCart)
        {
            this.appDbContent = appDbContent;
            this.shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.Created= DateTime.Now;
            appDbContent.Order.Add(order);
            appDbContent.SaveChanges();

            var items = shopCart.ListShopItems;

            foreach (var item in items) {
                OrderDetail detail = new OrderDetail() {
                    CarId = item.Car.Id,
                    OrderId = order.Id,
                    Price= item.Car.Price
                };
                appDbContent.OrderDetails.Add(detail);
            }
            appDbContent.SaveChanges();
        }
    }
}