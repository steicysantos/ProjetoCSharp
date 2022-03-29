namespace Model;
public class Store
{
    private String name = "";
    private String CNPJ = "";
    private Owner owner;
    private Purchase purchase;

    List<Purchase> purchases = new List<Purchase>();

    public void addNewPurchase(Purchase purchase){
        purchases.Add(purchase);
    }

}
