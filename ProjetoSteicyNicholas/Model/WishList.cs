namespace Model;

public class WishList{
    private Cliente cliente;
    List <Product> listaProdutos=new List<Product>();

    public addProductToWishList(Product product){
        listaProdutos.Add(product);
    }
}