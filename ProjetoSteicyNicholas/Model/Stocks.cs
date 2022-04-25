using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;

namespace Model;

public class Stocks : IValidateDataObject, IDataController<StocksDTO, Stocks>
{
    private int quantity;

    private Double unit_price;

    private Store store;

    private Product product;

    public List<StocksDTO> stocksDTO = new List<StocksDTO>();

    public static Stocks convertDTOToModel(StocksDTO obj)
    {
        
        var stocks = new Stocks();
        stocks.setQuantity(obj.quantity);
        stocks.setUnitPrice(obj.unit_price);
        stocks.store =  Store.convertDTOToModel(obj.store);
        stocks.product=Product.convertDTOToModel(obj.product);

        return stocks;
        
    }


    public Boolean validateObject()
    {
        return true;
    }

    public void delete(StocksDTO obj)
    {

    }

    // public int save()
    // {
    //     var id = 0;

    //     using(var context = new DAOContext())
    //     {
    //         var stocks = new DAO.stocks{
    //             quantity = this.quantity,
    //             unitPrice = this.unit_price,
    //             store = this.store,
    //             product = this.product
    //         };

    //         context.Stocks.Add(stocks);

    //         context.SaveChanges();

    //         id = stocks.id;

    //     }
    //      return id;
    // }
    public int save(int store, int product, int qtd, double unit_price)
    {
        var id = 0;

        using(var context = new DAOContext())
        {
            var stocks = new DAO.Stocks{
                quantity = quantity,
                unit_price = unit_price,
                store = context.Store.Where(c => c.id == store).Single(),
                product = context.Product.Where(c => c.id == product).Single()
            };

            context.Stock.Add(stocks);
            context.Entry(stocks.store).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.Entry(stocks.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.SaveChanges();
            id = stocks.id;
        }
         return id;
    }

    public void update(StocksDTO obj)
    {

    }

    public StocksDTO findById(int id)
    {

        return new StocksDTO();
    }

    public List<StocksDTO> getAll()
    {        
        return this.stocksDTO;      
    }

   
    public StocksDTO convertModelToDTO()
    {
        var stocksDTO = new StocksDTO();

        stocksDTO.quantity = this.quantity;

        stocksDTO.unit_price = this.unit_price;

        stocksDTO.store = this.store.convertModelToDTO();

        stocksDTO.product = this.product.convertModelToDTO();

        return stocksDTO;
    }

    public void setQuantity(int quantity)
    {
        this.quantity = quantity;
    }

    public void setUnitPrice(Double unit_price)
    {
        this.unit_price = unit_price;
    }

    public void setStore(Store store)
    {
        this.store = store;
    }

    public void setProduct(Product product)
    {
        this.product = product;
    }


    public int getQuantity()
    {
        return this.quantity;
    }

    public Double getUnitPrice()
    {        
        return this.unit_price;
    }

    public Store getStore()
    {
        return this.store;
    }

    public Product getProduct()
    {
        return this.product;
    }
}