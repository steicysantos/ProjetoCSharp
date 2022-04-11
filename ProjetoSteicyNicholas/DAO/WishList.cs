namespace DAO;

public class WishList{
    public Client cliente;
    List <Product> listaProdutos=new List<Product>();
    public void addProductToWishList(Product product){
        listaProdutos.Add(product);
    }
    
    }