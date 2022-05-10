// using System;
// using Interfaces; 
// using DAO;
// using DTO;
// using System.Collections.Generic;
// using Microsoft.EntityFrameworkCore;

// namespace Model;

// public class Stocks : IValidateDataObject, IDataController<StocksDTO, Stocks>
// {
//     private int quantity;

//     private Double unit_price;

//     private Store store;

//     private Product product;

//     public List<StocksDTO> stocksDTO = new List<StocksDTO>();

//     public static Stocks convertDTOToModel(StocksDTO obj)
//     {
        
//         var stocks = new Stocks();
//         stocks.setQuantity(obj.quantity);
//         stocks.setUnitPrice(obj.unit_price);
//         stocks.store =  Store.convertDTOToModel(obj.store);
//         stocks.product=Product.convertDTOToModel(obj.product);

//         return stocks;
        
//     }


//     public Boolean validateObject()
//     {
//         return true;
//     }

//     public void delete(StocksDTO obj)
//     {

//     }

//     // public int save()
//     // {
//     //     var id = 0;

//     //     using(var context = new DAOContext())
//     //     {
//     //         var stocks = new DAO.stocks{
//     //             quantity = this.quantity,
//     //             unitPrice = this.unit_price,
//     //             store = this.store,
//     //             product = this.product
//     //         };

//     //         context.Stocks.Add(stocks);

//     //         context.SaveChanges();

//     //         id = stocks.id;

//     //     }
//     //      return id;
//     // }
//     public int save(int store, int product, int qtd, double unit_price)
//     {
//         var id = 0;

//         using(var context = new DAOContext())
//         {

//             var storeDAO = context.Store.FirstOrDefault(c => c.id == store);
//             var productDAO = context.Product.FirstOrDefault(c => c.id == product);

//             var stocks = new DAO.Stocks{
//                 quantity = qtd,
//                 unit_price = unit_price,
//                 store = storeDAO,
//                 product = productDAO
//             };
//             context.Stock.Add(stocks);
//             context.SaveChanges();
//             id = stocks.id;
//         }
//          return id;
//     }

//     public void update(StocksDTO obj)
//     {

//     }

//     public StocksDTO findById(int id)
//     {

//         return new StocksDTO();
//     }

//     public List<StocksDTO> getAll()
//     {        
//         return this.stocksDTO;      
//     }

   
//     public StocksDTO convertModelToDTO()
//     {
//         var stocksDTO = new StocksDTO();

//         stocksDTO.quantity = this.quantity;

//         stocksDTO.unit_price = this.unit_price;

//         stocksDTO.store = this.store.convertModelToDTO();

//         stocksDTO.product = this.product.convertModelToDTO();

//         return stocksDTO;
//     }

//     public void setQuantity(int quantity)
//     {
//         this.quantity = quantity;
//     }

//     public void setUnitPrice(Double unit_price)
//     {
//         this.unit_price = unit_price;
//     }

//     public void setStore(Store store)
//     {
//         this.store = store;
//     }

//     public void setProduct(Product product)
//     {
//         this.product = product;
//     }


//     public int getQuantity()
//     {
//         return this.quantity;
//     }

//     public Double getUnitPrice()
//     {        
//         return this.unit_price;
//     }

//     public Store getStore()
//     {
//         return this.store;
//     }

//     public Product getProduct()
//     {
//         return this.product;
//     }
// }


namespace model;
using DTO;
using DAO;
using System.Collections.Generic;
using Interfaces;
using Microsoft.EntityFrameworkCore;

public class Stocks : IValidateDataObject, IDataController<StocksDTO, Stocks>
{
    private int quantity;
    private Double unit_price;
    private Store store;
    private Product product;

    // public List<StocksDTO> stocksDTO = new List<StocksDTO>();


// public Stocks(Store store){
//     this.store = store;
// }
// public Stocks(Product product){
//     this.product = product;
// }


// GET SET
public int getQuantity()
{
    return quantity;
}

public Double getUnit_price()
{
    return unit_price;
}

public Store getStore()
{
    return store;
}

public Product getProduct()
{
    return product;
}

public void setQuantity(int quantity)
{
    this.quantity = quantity;
}

public void setUnit_price(Double unit_price)
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


public bool validateObject()
{
    if(this.quantity == 0)
    {
        return false;
    }
    if(this.unit_price == 0)
    {
        return false;
    }
    if(this.product == null)
    {
        return false;
    }
    if(this.store == null)
    {
        return false;
    }
    return true;

}


//DTO

public StockDTO convertModelToDTO(){
    return new StockDTO
    {
        quantity = this.quantity,
        unit_price = this.unit_price,
        store = this.store.convertModelToDTO(),
        product = this.product.convertModelToDTO()
    };
}

public static Stock convertDTOToModel(StockDTO stocks){
    return new Stock
    {
        quantity = stocks.quantity,
        unit_price = stocks.unit_price,
        product = Product.convertDTOToModel(stocks.product),
        store = Store.convertDTOToModel(stocks.store)
    };
}

 public static Stock convertDAOToModel(DAO.Stock stocks)
    {
        return new Stock
        {
            quantity = (int)stocks.quantity,
            unit_price = stocks.unit_price,
            product = Product.convertDAOToModel(stocks.product),
            store = Store.convertDAOToModel(stocks.store)
        };
    }
////parei aqui

public int save(int storeId, int productId, int quantity, double unit_price)
{
    int id;
    using (var context = new DAOContext())
    {
        var storeDAO = context.Store.FirstOrDefault(s => s.id == storeId);
        var productDAO = context.Product.FirstOrDefault(p => p.id == productId);

        if(storeDAO == null || productDAO == null)
        {
            return -1;
        }
        DAO.Stock stocks = new DAO.Stock
        {
            quantity = quantity,
            unit_price = unit_price,
            product = productDAO,
            store = storeDAO
        };

        if(context.Stock.FirstOrDefault( s => s.store == stocks.store && s.product == stocks.product) != null)
        {
            return -1;
        }

        context.Stock.Add(stock);
        context.Entry(stocks.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchaged;
        context.Entry(stock.store).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
        context.SaveChanges();

        id = stock.id;
    }

    return id;
}


public void delete()
{
    using (var context = new DAOContext())
        {
            var thisDAO = this.FindDao();
            if (thisDAO == null)
                return;
            context.Stock.Remove(thisDAO);
            context.SaveChanges();
        };
}
public void update(StockDTO obj)
{

}

public StockDTO findById()
{
    return new StockDTO();
}

public List<StockDTO> getAll()
{
    List<StockDTO> stocks = new List<StockDTO>();
    return stocks;
}

public DAO.Stock? FindDao()
{
    using (var context = new DAOContext())
    {
        var stock = context.Stock.FirstOrDefault(i => Stock.convertDAOToModel(i) == this);
        return stock;
    };
}
}
