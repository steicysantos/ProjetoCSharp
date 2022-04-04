namespace Model;

public class WishList{
    private Client cliente;
    List <Product> listaProdutos=new List<Product>();

    public void addProductToWishList(Product product){
        listaProdutos.Add(product);
    }

    public WishList(Client cliente){
        this.cliente=cliente;
    }
    public Client getClient(){
        return cliente;
    }
    public List<Product> getProducts(){
        return listaProdutos;
    }
    public void setClient(Client cliente){
        this.cliente=cliente;
    }
}