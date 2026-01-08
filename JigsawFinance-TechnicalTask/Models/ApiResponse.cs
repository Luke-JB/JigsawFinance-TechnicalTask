namespace JigsawFinance_TechnicalTask.Models
{
    public class ApiResponse
    {
        public int Total { get; set; }
        public List<Product> Products { get; set; }
        public int Skip { get; set; }
        public int Limit { get; set; }
    }
}
