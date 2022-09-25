namespace WebApplication1.Data.Models
{
    public class ShopCartItem
    {

        public int Id { get; set; }

        public Car Car { get; set; }

        public uint price { get; set; }

        public string ShopCartId { get; set; }
    }
}
