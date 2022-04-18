namespace DTO;
public class PurchaseDTO{
    public DateTime datePurchase;
    public string purchase_status;
    public int payment_type;
    public String numberConfirmation = "";
    public String numberNF = "";
    public ProductDTO product;
    public StoreDTO store;
    public ClientDTO client;
}