namespace usingMinimalApi
{

    public record GetProductsResponseDto(int Id, string Name, decimal? Price);
    public record CreateProductRequest(string Name, decimal? Price);
    public class ProductService
    {

        private List<GetProductsResponseDto> _products = new List<GetProductsResponseDto>()
            {
                new(1,"Ürün A", 100),
                new(2,"Ürün B", 100),
                new(3,"Ürün C", 100),

            };
        public IEnumerable<GetProductsResponseDto> GetProducts()
        {
            return _products;
        }

        public IEnumerable<GetProductsResponseDto> SearchByName(string name)
        {
            return _products.Where(p => p.Name.Contains(name));
        }

        public GetProductsResponseDto? GetById(int id) => _products.SingleOrDefault(p => p.Id == id);

        public int Create(CreateProductRequest request)
        {
            var lastId = _products.Last().Id + 1;
            GetProductsResponseDto getProductsResponseDto = new GetProductsResponseDto(lastId, request.Name, request.Price);

            _products.Add(getProductsResponseDto);
            return lastId;
        }
    }
}
