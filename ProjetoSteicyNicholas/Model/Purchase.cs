using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model;
using Enums;

public class Purchase : IValidateDataObject<Purchase>{
    private DateTime datePurchase;
    private int purchase_status;
    private int payment_type;
    private String numberConfirmation = "";
    private String numberNF = "";
    private List<Product> product=new List<Product>();
    private Store store;
    private Client client;



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
        return client;
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
    public void setClient(Client client){
        this.client=client;
    }
    public void setPaymentType(PaymentEnum payment_type){
        this.payment_type=(int)payment_type;
    }
    public void setPurchaseStatus(PurchaseStatusEnum purchase_status){
        this.purchase_status=(int)purchase_status;
    }

    public bool validateObject(Purchase obj){
        if(datePurchase == null)
            return false;
        else if(purchase_status ==  null)
            return false;
        else if(payment_type == null)
            return false;
        else if(numberConfirmation == null)
            return false;
        else if(numberNF == null)
            return false;
        else if(product == null)
            return false;
        else if(store == null)
            return false;
        else if(client == null)
            return false;
        else return true;
    }

}