namespace DTO;
public class PurchaseDTO{
    public DateTime datePurchase;
    public string purchaseStatus;
    public int paymentType;
    public String numberConfirmation;
    public String numberNF;
    public List<ProductDTO> product = new List<ProductDTO>();
    public List<StoreDTO> store = new List<StoreDTO>();
    public ClientDTO client;
}