using Microsoft.AspNetCore.Mvc;
using Model;
using DTO;
namespace Controller.Controllers;


[ApiController]
[Route("[controller]")]

public class StockController : ControllerBase{
    [HttpPost]
    [Route("register")]
    public object addProductToStock(StocksDTO stocks)
    {
        var stockModel = Stock.convertDTOToModel(stocks);
        var storeId = storeId.findId(stockModel.getStore().getCNPJ());
        var productId = Product.findId(stockModel.gsetProduct().getCNPJ());
        var id = stockModel.save(storeId, productId, stockModel.getQuantity(), stockModel.getUnit_price());
        return new
        {
            id = id,
            quantity = stocks.quantity,
            unit_price = stocks.unit_price,
            product = stocks.product,
            store = stocks.store
        };
    }

    [HttpPut]
    [Route("update")]
    public void updateStock(Object request){

    }

    [HttpDelete]
    [Route("delete")]
    public void deleteStock([FromBody] StocksDTO stocks)
    {
        var stockModel = stocks.convertDTOToModel(stocks);
        stockModel.delete();
    }
}
