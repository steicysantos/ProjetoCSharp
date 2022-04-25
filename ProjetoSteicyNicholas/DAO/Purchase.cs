namespace DAO;
public class Purchase{
    public int id;
    public DateTime date_purchase;
    public string purchase_status;
    public int payment_type;
    public String number_confirmation = "";
    public String number_nf = "";
    public Product product;
    public Store store;
    public Client client;
}