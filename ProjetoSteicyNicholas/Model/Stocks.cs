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

    public List<StocksDTO> stocksDTO = new List<StocksDTO>();
}

public Stocks(Store store){
    this.store = store;
}
public Stocks(Product product){
    this.product = product;
}

private Store(){}

public int getQuantity()
{
    return quantity;
}

public getUnit_price()
{
    return unit_price;
}

public getStore()
{
    return store;
}

public getProduct()
{
    return product;
}

public void setQuantity(int quantity)
{
    this.quantity = quantity;
}

public void setUnit_price(double unit_price)
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
    if(this.getQuantity() == null)
    {
        return false;
    }
    if(this.getUnit_price() == null)
    {
        return false;
    }
    return true;

}


//DTO

public void delete(StockDTO obj)
{

}

public interface save()
{
    var id = 0;
    using(var context = new DaoContext())
    {
        var storeDAO = context.stores.Where(char => c.id == store).Single();
        var productDAO = product.products.Where(char => c.id == product).Single();
        var stock = new DAO.Stock{
        store = storeDAO,
        product = productDAO,
        quantity = this.quantity,
        unit_price = this.unit_price
    };
    context.stocks.Add(stock);
    context.Entry(stock.store).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
    context.Entry(stock.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
    context.SaveChanges();
    id = stock.id;
    }
    return id;
}

public void update(StockDTO obj)
{

}

public StockDTO findByID(int id)
{
    return new StoreDTO();
}

public static object getStockInfo(string store)
{
    using(var context = new DaoContext()){
//      var stockDAO = context.stocks.Include(s => s.)
        List<object> estoques = new List<object>();
        foreach(var stock in stocks){
            estoques.Add(stock);
        }
        return estoques;
    }
}

public List<StockDTO> getAll(){
    return this.stockDTO;
}

public StockDTO convertModelToDTO(){
    var stockDTO = new StockDTO();
    stockDTO.quantity = this.quantity;
    stockDTO.unit_price = this.unit_price;
    stockDTO.store = this.store.convertModelToDTO();
    // foreach(var stocksDTO in this.stocksDTO){
        
    // }

    return stockDTO;
}

public static Stock convertDTOtOmODEL(StockDTO obj){
    //var stock = new Stock(Store.convertDTOToModel(obj.store));

    var stock = new Stock();

    if(obj.store != null){
        stock.store = Store.convertDTOToModel(obj.store);
    }

    if(obj.product != null){
        stock.product = Product.convertDTOToModel(obj.product);
    }

    stock.setQuantity(obj.quantity);
    stock.setUnit_price(obj.unit_price);

    foreach(var purchase in obj.purchases){
            store.addNewPurchase(Purchase.convertDTOToModel(purchase));
    }
}