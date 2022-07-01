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
    [Route("getClient/{clientID}")]
    public object getClientPurchase(int clientID){
        var clientPurchase = Model.Purchase.getClientPurchases(clientID);
        return clientPurchase;
    }
    [Authorize]
    [HttpGet]
    [Route("getStore/{storeID}")]
    public object getStorePurchase(int storeID){
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
