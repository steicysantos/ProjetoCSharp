namespace Model;

public class WishList{
    private Cliente cliente;
    List <Product> listaProdutos=new List<Product>();

    public void addProductToWishList(Product product){
        listaProdutos.Add(product);
    }
}