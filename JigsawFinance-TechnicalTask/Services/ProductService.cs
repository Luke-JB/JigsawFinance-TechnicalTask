using JigsawFinance_TechnicalTask.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace JigsawFinance_TechnicalTask.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<PagedResponse<Product>> GetPagedProductsAsync(int skip, int limit)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://dummyjson.com/products?skip={skip}&limit={limit}");
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<ApiResponse>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (apiResponse?.Products == null)
                {
                    Console.WriteLine("Products are null in the API response.");
                }

                return new PagedResponse<Product>
                {
                    Total = apiResponse.Total,
                    Products = apiResponse.Products ?? new List<Product>()
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching products: {ex.Message}");
                throw;
            }
        }

        public async Task<ProductDetails> GetProductDetailsAsync(int productId)
        {
            var response = await _httpClient.GetAsync($"https://dummyjson.com/products/{productId}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ProductDetails>(content);
        }
    }
}
