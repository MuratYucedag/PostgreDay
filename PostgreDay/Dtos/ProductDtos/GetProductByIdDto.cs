namespace PostgreDay.Dtos.ProductDtos
{
    public class GetProductByIdDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }
    }
}
