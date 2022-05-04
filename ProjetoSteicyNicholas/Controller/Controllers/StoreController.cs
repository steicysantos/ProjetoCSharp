// using Microsoft.AspNetCore.Mvc;

// namespace Controller.Controllers;

// [ApiController]
// [Route("[controller]")]
// public class ProductController : ControllerBase
// {
//     [HttpGet(Name = "getAllStore")]
//     public void getAllProducts(){

//     }

//     [HttpPatch(Name = "registerStore")]
//     public Store registerStore(StoreDTO store){

//     }

//     [HttpGet(Name = "getStoreInformation")]
//     public Store registerStore(StoreDTO store){

//     }
// }


using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("store")]
public class StoreController : ControllerBase{
    [HttpPost]
    [Route("register")]
    public object registerStore(StoreDTO store){
        var storeModel = Model.Store.convertDTOToModel(store);
        var id = storeModel.save(1);
        return new{
            name = store.name,
            cnpj = store.CNPJ,
            listPurchase = store.purchase,
            owner = store.owner,
            id = id
        };
    }

    [HttpGet]
    [Route("getStore/{CNPJ}")]
    public static object getStoreInfo(string CNPJ){
        var store=Model.Store.find(CNPJ);
        return store;
    }
}
