using Microsoft.AspNetCore.Mvc;
using Model;
using DTO;
namespace Controller.Controllers;

[ApiController]
[Route("purchase")]
public class PurchaseController : ControllerBase
{

    // [HttpGet(Name = "getClientPurchase")]
    // public Client getClientPurchase(int clientId){

    // }

    // [HttpGet(Name = "getStorePurchase")]
    // public Store getStorePurchase(int clientId){
        
    // }

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
