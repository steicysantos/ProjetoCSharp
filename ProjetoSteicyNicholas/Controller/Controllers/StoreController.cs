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
using Microsoft.AspNetCore.Authorization;

namespace Controller.Controllers;

[ApiController]
[Route("store")]
public class StoreController : ControllerBase{
    [Authorize]
    [HttpPost]
    [Route("register")]
    public object registerStore(StoreDTO store){
        var ownerId = Lib.GetIdFromRequest( Request.Headers["Authorization"].ToString());
        var storeModel = Model.Store.convertDTOToModel(store);
        var id = storeModel.save(ownerId);
        return new{
            name = store.name,
            cnpj = store.CNPJ,
            owner = store.owner,
            id = id
        };
    }
    [Authorize]
    [HttpGet]
    [Route("getAll")]
    public object getAllStores(){
        var stores=Model.Store.getStores();
        return stores;
    }
    [Authorize]
    [HttpGet]
    [Route("getStore/{CNPJ}")]
    public object getStoreInformation(string CNPJ){
        var store=Model.Store.getStoreInfo(CNPJ);
        return store;
    }
    [Authorize]
    [HttpGet]
    [Route("getStores")]
    public IActionResult getStoreInformations(){
        var ownerId = Lib.GetIdFromRequest( Request.Headers["Authorization"].ToString());
        Console.WriteLine(ownerId);
        var store=Model.Store.getStoreInfoID(ownerId);
        var result = new ObjectResult(store);
        return result;
    }

    [HttpGet]
    [Route("getStoreID")]
    public int getStoreID(){
        var ownerId = Lib.GetIdFromRequest( Request.Headers["Authorization"].ToString());
        var id=Model.Store.getStoreID(ownerId);
        return id;
    }
}
