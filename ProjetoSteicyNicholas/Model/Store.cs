using Interfaces;
namespace Model;
public class Store
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
}
