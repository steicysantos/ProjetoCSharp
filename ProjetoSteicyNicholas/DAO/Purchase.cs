namespace DAO;
using Enums;
public class Purchase{
    public int id;
    public DateTime date_purchase;
    public PaymentEnum payment_type;
    public PurchaseStatusEnum purchase_status;
    public String number_confirmation = "";
    public String number_nf = "";
    public Product product;
    public Store store;
    public Client client;
}