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
    public Object makePurchase(PurchaseDTO purchaseDTO){
        var purchase = Purchase.convertDTOToModel(purchaseDTO);
        var id = purchase.save();
        return new{
            date_purchase = purchaseDTO.date_purchase,
            purchase_value = purchaseDTO.purchase_value,
            payment_type = purchaseDTO.payment_type,
            purchase_status = purchaseDTO.purchase_status,
            number_comfirmation = purchaseDTO.number_confirmation,
            number_nf = purchaseDTO.number_nf,
            products = purchaseDTO.product,
            store = purchaseDTO.store,
            cliente = purchaseDTO.client,
            id = id
        };
    }


}
