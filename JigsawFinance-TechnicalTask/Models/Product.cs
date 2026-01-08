using System.Text.Json;

namespace JigsawFinance_TechnicalTask.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        //public string Description { get; set; }
        public string Thumbnail { get; set; }
        public List<string> Images { get; set; }
        public List<string> Tags { get; set; }
        //public string ShippingInformation { get; set; }
    }
    public class ProductDetails : Product
    {
        public string Description { get; set; }
        public string ShippingInformation { get; set; }
    }

    public class PagedResponse<T>
    {
        public int Total { get; set; }
        public List<T> Products { get; set; }
    }
}
