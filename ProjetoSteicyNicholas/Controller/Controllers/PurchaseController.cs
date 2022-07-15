using Microsoft.AspNetCore.Mvc;
using Model;
using DTO;
using Microsoft.AspNetCore.Authorization;
namespace Controller.Controllers;

[ApiController]
[Route("purchase")]
public class PurchaseController : ControllerBase
{
    [Authorize]
    [HttpGet]
    [Route("getClient")]
    public IActionResult getClientPurchase(){
        var ClientId = Lib.GetIdFromRequest( Request.Headers["Authorization"].ToString());
        var clientPurchase = Model.Purchase.getClientPurchases(ClientId);
         var result = new ObjectResult(clientPurchase);
                return result;
    }
    [Authorize]
    [HttpGet]
    [Route("getStore")]
    public object getStorePurchase(){
        var ownerId = Lib.GetIdFromRequest( Request.Headers["Authorization"].ToString());
        var storeID=Model.Store.getStoreID(ownerId);
        var storePurchase = Model.Purchase.getStorePurchases(storeID);
        return storePurchase;
    }
    [Authorize]
    [HttpPost]
    [Route("make")]
    public void makePurchase(PurchaseRequestDTO purchaseDTO){
        DateTime time = DateTime.Now;              // Use current time
        string format = "yyyy-MM-dd HH:mm:ss"; 
        var ClientId = Lib.GetIdFromRequest( Request.Headers["Authorization"].ToString());
        var purchaseModel = new Model.Purchase();
        var requests=purchaseModel.save(ClientId,purchaseDTO.idStore,purchaseDTO.idProduct,purchaseDTO.date_purchase, purchaseDTO.payment_type, purchaseDTO.purchase_status, purchaseDTO.number_confirmation, purchaseDTO.number_nf );

        
        
    }


}
