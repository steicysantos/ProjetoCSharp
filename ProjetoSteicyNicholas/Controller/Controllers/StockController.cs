using Microsoft.AspNetCore.Mvc;
using Model;
using DTO;
namespace Controller.Controllers;


[ApiController]
[Route("stock")]
public class StockController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public object registerOwner(StocksDTO stocks)
    {
        var stockk=Model.Stocks.convertDTOToModel(stocks);
        var id=stockk.save(1,1,1,1);
        return new{
            quantity = stocks.quantity,
            unit_price = stocks.unit_price,
            store = stocks.store,
            product = stocks.product,
            id=id
        };
    }
    // [HttpGet(Name = "getInformations")]
    // public void getInformations()
    // {
    // } ""
}