
namespace Model;

public class Stocks{
    public int quantity;
    private Store store;
    private Product product;

    public int getQuantity(){
        return quantity;
    }

    public Store getStore(){
        return store;
    }

    public Product getProduct(){
        return product;
    }

    public void setQuantity(int quantity){
        this.quantity = quantity;
    }

    public void setStore(Store store){
        this.store = store;
    }

    public void setProduct(Product product){
        this.product = product;
    }
}