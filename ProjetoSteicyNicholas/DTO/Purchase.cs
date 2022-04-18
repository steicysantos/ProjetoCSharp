namespace DTO;
public class PurchaseDTO{
    public DateTime datePurchase;
    public string purchase_status;
    public int payment_type;
    public String numberConfirmation = "";
    public String numberNF = "";
    public List<ProductDTO> product = new List<ProductDTO>();
    public StoreDTO store;
    public ClientDTO client;
}