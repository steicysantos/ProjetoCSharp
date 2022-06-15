using System;
using Interfaces; 
using DAO;
using DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Model;

public class WishList : IValidateDataObject, IDataController<WishListDTO, WishList>
{
    private Client client;
    private List<Stocks> stocks = new List<Stocks>();

    public List<WishListDTO> wishListDTO = new List<WishListDTO>();


    public static WishList convertDTOToModel(WishListDTO obj)
    {
        var wishlist = new WishList();
        wishlist.client =  Client.convertDTOToModel(obj.client);

        foreach(var item in obj.stocks){
            wishlist.addProductToWishList(Stocks.convertDTOToModel(item));
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

    public static string delete(int id,int ClientId){
        using (var context = new DAOContext())
        {
            var wishList = context.WishList
            .FirstOrDefault(w => w.id == id && w.client.id == ClientId);
            context.WishList.Remove(wishList);
            context.SaveChanges();
            return "sucess";
        }
    }
    public int save(int stock, int client)
    {
        var id = 0;

        using (var context = new DAOContext())
        {
            var clientDAO = context.Client.FirstOrDefault(c => c.id == client);
            var stocksDAO = context.Stock.FirstOrDefault(x=> x.id == stock);

            var wishList = new DAO.WishList
            {
                client = clientDAO,
                stocks = stocksDAO
                
            };
            context.WishList.Add(wishList);
            context.Entry(wishList.client).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.Entry(wishList.stocks).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
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

        wishListDTO.client = this.client.convertModelToDTO();

        foreach(var item in this.stocks){
            wishListDTO.stocks.Add(item.convertModelToDTO());
        }

        return wishListDTO;
    }

    public void setClient(Client client)
    {
        this.client = client;
    }



    public Client getClient()
    {
        return this.client;
    }


        public static List<WishListResponseDTO> GetWishList(int IdClient){

        using(var context = new DAOContext()){
            var wishLists = context.WishList.Include(p=>p.client).Include(p=>p.stocks)
            .Include(p=>p.stocks.product).Include(p=> p.stocks.store).Where(i=> i.client.id ==IdClient);
        
            var responseproducts = new List<WishListResponseDTO>();
            foreach(var item in wishLists)
            {
                var newproduct = new WishListResponseDTO();
                newproduct.bar_code = item.stocks.product.bar_code;
                Console.WriteLine("Cjega aqui");
                newproduct.IdStocks = item.stocks.id;
                newproduct.idWishlist = item.id;
                newproduct.description = item.stocks.product.description;
                newproduct.image = item.stocks.product.image;
                newproduct.Unit_price = item.stocks.unit_price;
                Console.WriteLine("Cjega aqui 2");
                newproduct.cnpjj = item.stocks.store.CNPJ;
                newproduct.Quantity = item.stocks.quantity;
                Console.WriteLine("Cjega aqio 3");
                newproduct.name = item.stocks.product.name;
                responseproducts.Add(newproduct);
                Console.WriteLine(responseproducts[0]);
                
            }
            return responseproducts;
        }   
    }
    public List<Stocks> GetStocks() { return stocks; }
    public void addProductToWishList(Stocks stock)
    {
        if (!GetStocks().Contains(stock))
        {
            this.stocks.Add(stock);
        }
    }

}