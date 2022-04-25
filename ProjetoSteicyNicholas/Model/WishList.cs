using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;

namespace Model;

public class WishList : IValidateDataObject, IDataController<WishListDTO, WishList>
{
    private Client client;
    List <Product> listaProdutos=new List<Product>();

    public List<WishListDTO> wishListDTO = new List<WishListDTO>();

    public void addProductToWishList(Product product){
        listaProdutos.Add(product);
    }

    public static WishList convertDTOToModel(WishListDTO obj)
    {
        var wishlist = new WishList();
        wishlist.client =  Client.convertDTOToModel(obj.client);

        foreach(var item in obj.products){
            wishlist.listaProdutos.Add(Product.convertDTOToModel(item));
        }
        return wishlist;
    }
    public WishList(Client client){
        this.client = client;
    }
    public WishList(){
    }

    public Boolean validateObject()
    {
        return true;
    }

    public void delete(WishListDTO obj)
    {

    }

    // public int save()
    // {
    //     var id = 0;

    //     using(var context = new DAOContext())
    //     {
            
    //         var client = new DAO.Client
    //         {
    //             name = this.client.getName(),
    //             date_of_birth = this.client.getDate_of_birth(),
    //             document = this.client.getDocument(),
    //             email = this.client.getEmail(),
    //             phone = this.client.getPhone(),
    //             passwd = this.client.getPasswd(),
    //             login = this.client.getLogin(),
    //             address = this.client.getAddress()
    //         };
    //         var wishList = new DAO.WishList{
    //             client = this.client,
    //             product = this.listaProdutos
    //         };

    //         context.WishList.Add(wishList);

    //         context.SaveChanges();

    //         id = wishList.id;

    //     }
    //      return id;
    // }
     public int save(string clientDoc, int prod)
    {
        var id = 0;

        using(var context = new DAOContext())
        {
             var clientDAO = context.Client.Where(c => c.document == clientDoc).Single();
            var wl = new DAO.WishList{
                client = clientDAO
            };

            context.WishList.Add(wl);
            context.Entry(wl.client).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.SaveChanges();
            id = wl.id;
        }
         return id;
    }

    public void update(WishListDTO obj)
    {

    }

    public WishListDTO findById(int id)
    {

        return new WishListDTO();
    }

    public List<WishListDTO> getAll()
    {        
        return this.wishListDTO;      
    }

   
    public WishListDTO convertModelToDTO()
    {
        var wishListDTO = new WishListDTO();

        wishListDTO.client = this.client.convertModelToDTO();

        foreach(var item in this.listaProdutos){
            wishListDTO.products.Add(item.convertModelToDTO());
        }

        return wishListDTO;
    }

    public void setClient(Client client)
    {
        this.client = client;
    }

    public void setListaProdutos(List<Product> listaProdutos)
    {
        this.listaProdutos = listaProdutos;
    }


    public Client getClient()
    {
        return this.client;
    }

    public List<Product> getProducts()
    {        
        return this.listaProdutos;
    }

}