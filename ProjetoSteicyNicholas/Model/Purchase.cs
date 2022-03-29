namespace Model;

public class Purchase{
    private DateTime datePurchase;
    private String payment = "";
    private String numberConfirmation = "";
    private String numberNF = "";
    private Product product;
    private Store store;
    private Client cliente;


    public DateTime getDatePurchase(){
        return datePurchase;
    }
    public String getPayment(){
        return payment;
    }
    public String getNumberConfirmation(){
        return numberConfirmation;
    }
    public String getNumberNF(){
        return numberNF;
    }
    public Product getProduct(){
        return product;
    }
    public Store getStore(){
        return store;
    }
    public Client getClient(){
        return cliente;
    }
    public void setDatePurchase(DateTime datePurchase){
        this.datePurchase=datePurchase;
    }
    public void setPayment(String payment){
        this.payment=payment;
    }
    public void setNumberConfirmation(String numberConfirmation){
        this.numberConfirmation=numberConfirmation;
    }
    public void setNumberNF(String numberNF){
        this.numberNF=numberNF;
    }
    public void setProduct(Product product){
        this.product=product;
    }
    public void setStore(Store store){
        this.store=store;
    }
    public void setClient(Client cliente){
        this.cliente=cliente;
    }

}