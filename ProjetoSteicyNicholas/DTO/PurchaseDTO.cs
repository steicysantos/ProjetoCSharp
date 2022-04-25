namespace DTO;
public class PurchaseDTO{
    public DateTime date_purchase;
    public string purchase_status;
    public int payment_type;
    public String number_confirmation;
    public String number_nf;
    public List<ProductDTO> product = new List<ProductDTO>();
    public List<StoreDTO> store = new List<StoreDTO>();
    public ClientDTO client;
}