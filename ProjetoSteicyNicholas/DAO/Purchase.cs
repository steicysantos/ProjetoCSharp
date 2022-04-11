namespace DAO;
public class Purchase{
    public int id;
    public DateTime datePurchase;
    public string purchase_status;
    public int payment_type;
    public String numberConfirmation = "";
    public String numberNF = "";
    public Product product;
    public Store store;
    public Client client;
}