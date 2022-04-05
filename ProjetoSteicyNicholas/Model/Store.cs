using System;
using Interfaces;
using Model;

namespace Model;

public class Store : IValidateDataObject<Store>
{
    private String name = "";
    private String CNPJ = "";
    private Owner owner;
    private Purchase purchase;

    List<Purchase> purchases = new List<Purchase>();
    public Store(Owner owner){this.owner=owner;}
    public void addNewPurchase(Purchase purchase){
        purchases.Add(purchase);
    }

    public String getName(){
        return name;
    }
    public String getCNPJ(){
        return CNPJ;
    }
    public Owner getOwner(){
        return owner;
    }
    public Purchase getPurchase(){
        return purchase;
    }

    public void setName(String name){
        this.name=name;
    }
    public void setCNPJ(String CNPJ){
        this.CNPJ=CNPJ;
    }
    public void setOwner(Owner owner){
        this.owner=owner;
    }
    public void setPurchase(Purchase purchase){
        this.purchase=purchase;
    }
    public bool validateObject(Store obj)
    {
        if (obj.name == null)
            return false;
        else if (obj.CNPJ == null)
            return false;
        else if (obj.owner == null)
            return false;
        else if (obj.purchase == null)
            return false;
        else return true;

    }
}
