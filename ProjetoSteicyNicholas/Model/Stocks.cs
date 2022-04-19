using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;

namespace Model;

public class Stocks : IValidateDataObject, IDataController<StocksDTO, Stocks>
{
    private int quantity;

    private Double unitPrice;

    private Store store;

    private Product product;


    public static Stocks convertDTOToModel(StocksDTO obj)
    {
        
        var stocks = new Stocks();
        stocks.quantity(obj.quantity);
        stocks.unitPrice(obj.unitPrice);
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

    public int save()
    {
        var id = 0;

        using(var context = new DAOContext())
        {
            var stocks = new DAO.stocks{
                quantity = this.quantity,
                unitPrice = this.unitPrice,
                store = this.store,
                product = this.product
            };

            context.Stocks.Add(stocks);

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

        stocksDTO.unitPrice = this.unitPrice;

        stocksDTO.store = this.store;

        stocksDTO.product = this.product;

        return stocksDTO;
    }

    public void setQuantity(String quantity)
    {
        this.quantity = quantity;
    }

    public void setUnitPrice(String unitPrice)
    {
        this.unitPrice = unitPrice;
    }

    public void setStore(String store)
    {
        this.store = store;
    }

    public void setProduct(String product)
    {
        this.product = product;
    }


    public String getQuantity()
    {
        return this.quantity;
    }

    public String getUnitPrice()
    {        
        return this.unitPrice;
    }

    public String getStore()
    {
        return this.store;
    }

    public String getProduct()
    {
        return this.product;
    }
}