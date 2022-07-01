using Microsoft.AspNetCore.Mvc;
using DTO;
using Microsoft.AspNetCore.Authorization;
namespace Controller.Controllers;

[ApiController]
[Route("stock")]

public class StockController : ControllerBase{
    [HttpPost]
    [Route("add")]
    public object addProductToStock([FromBody] StocksDTO stocks){
        var stockModel = Model.Stocks.convertDTOToModel(stocks);
        var storeId = Model.Store.findId(stockModel.getStore().getCNPJ());
        var productId = Model.Product.findId(stockModel.getProduct().getBarCode());
        
        var id = stockModel.save(storeId, productId, stockModel.getQuantity(), stockModel.getUnitPrice());

        return new{
            id = id,
            quantity = stocks.quantity,
            unit_price = stocks.unit_price,
            product = stocks.product,
            store = stocks.store
        };
    }
    [Authorize]
    [HttpPut]
    [Route("update")]
    public Object update([FromBody]StocksDTO stocksDTO){
        var stockk = new Model.Stocks();
        stockk.update(stocksDTO);
        return new{
            status = "ok",
            mensagem = "deu boa"
        };
    }   
}