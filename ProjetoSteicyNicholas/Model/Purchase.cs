namespace Model;
using Enums;

public class Purchase{
    private DateTime datePurchase;
    private int purchase_status;
    private int payment_type;
    private String numberConfirmation = "";
    private String numberNF = "";
    private List<Product> product=new List<Product>();
    private Store store;
    private Client cliente;



    public DateTime getDatePurchase(){
        return datePurchase;
    }
    public int getPaymentType(){
        return payment_type;
    }
    public String getNumberConfirmation(){
        return numberConfirmation;
    }
    public String getNumberNf(){
        return numberNF;
    }
    public List<Product> getProducts(){
        return product;
    }
    public Store getStore(){
        return store;
    }
    public Client getClient(){
        return cliente;
    }
    public int getPurchaseStatus(){
        return purchase_status;
    }
    public void setDataPurchase(DateTime datePurchase){
        this.datePurchase=datePurchase;
    }
    public void setNumberConfirmation(String numberConfirmation){
        this.numberConfirmation=numberConfirmation;
    }
    public void setNumberNf(String numberNF){
        this.numberNF=numberNF;
    }
    public void setProducts(List<Product> product){
        this.product=product;
    }
    public void setStore(Store store){
        this.store=store;
    }
    public void setClient(Client cliente){
        this.cliente=cliente;
    }
    public void setPaymentType(PaymentEnum payment_type){
        this.payment_type=(int)payment_type;
    }
    public void setPurchaseStatus(PurchaseStatusEnum purchase_status){
        this.purchase_status=(int)purchase_status;
    }

}