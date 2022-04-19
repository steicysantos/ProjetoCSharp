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
        List<Product> listanova = new List<Product>();
        wishlist.client =  Client.convertDTOToModel(obj.client);
        var lista = Product.convertDTOToModel(obj.products);
        for (int i=0;i<lista.Count;i++){
            listanova.Add(lista[i]);
        }
        wishlist.listaProdutos=listanova;
        return wishlist;
    }


    public Boolean validateObject()
    {
        return true;
    }

    public void delete(WishListDTO obj)
    {

    }

    public int save()
    {
        var id = 0;

        using(var context = new DAOContext())
        {
            var wishList = new DAO.WishList{
                client = this.client,
                listaProdutos = this.listaProdutos
            };

            context.WishList.Add(wishList);

            context.SaveChanges();

            id = wishList.id;

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

        wishListDTO.client = this.client;

        wishListDTO.listaProdutos = this.listaProdutos;

        return wishListDTO;
    }

    public void setClient(String client)
    {
        this.client = client;
    }

    public void setListaProdutos(List<Product> listaProdutos)
    {
        this.listaProdutos = listaProdutos;
    }


    public String getClient()
    {
        return this.client;
    }

    public List<Product> getListaProdutos()
    {        
        return this.listaProdutos;
    }

}