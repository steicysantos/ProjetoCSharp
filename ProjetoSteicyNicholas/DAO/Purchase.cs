namespace DAO;
public class Purchase{
    public DateTime datePurchase;
    public int purchase_status;
    public int payment_type;
    public String numberConfirmation = "";
    public String numberNF = "";
    public List<Product> product=new List<Product>();
    public Store store;
    public Client client;
}