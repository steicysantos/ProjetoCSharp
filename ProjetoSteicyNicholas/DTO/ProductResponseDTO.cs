namespace DTO
{
    public class ProductResponseDTO: ProductDTO
    {
        public int Id;
        public int Quantity;
        public double Unit_price;   
        public string CNPJ;
        public int IdStocks;
    }
}