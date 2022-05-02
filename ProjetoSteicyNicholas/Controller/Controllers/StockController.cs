// using System;
// using Model;
// using DTO;
// using Microsoft.AspNetCore.Mvc;

// namespace Controller.Controllers;

// [ApiController]
// [Route("store")]
// public class StoreController : ControllerBase{
//     [HttpPost]
//     [Route("register")]
//     public object registerStore(StoreDTO store){
//         var storeModel = Model.Store.convertDTOToModel(store);
//         var id = storeModel.save();
//         return new{
//             name = store.name,
//             cnpj = store.CNPJ,
//             listPurchase = store.purchase,
//             owner = store.owner,
//             id = id
//         };
//     }
// }