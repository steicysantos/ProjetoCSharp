using DTO;
using Enums;

namespace DTO;
public class PurchaseRequestDTO{
    public int idClient;
    public int idStore;
    public int idProduct;

    public DateTime date_purchase;

    public double purchase_value;

    public PaymentEnum payment_type;

    public PurchaseStatusEnum purchase_status;

    public String number_confirmation;

    public String number_nf;
}