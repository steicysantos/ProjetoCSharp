// using Microsoft.AspNetCore.Mvc;

// namespace Controller.Controllers;

// [ApiController]
// [Route("[controller]")]
// public class WishListController : ControllerBase
// {
//     [HttpPost]
//     [Route("register")]
//         public object addProductToWishList([FromBody]WishListDTO wishList){
//                 var wishListModel = model.WishList.convertDTOToModel(wishList);
//                 var id = 0;
//                 foreach(var product in wishList.products){
//                         var idProduto = model.Product.find(product);

//                         id = wishListModel.save(wishList.client.document, idProduto);
//                 }
//                 return new {
//                         id = id,
//                         client = wishList.client.document,
//                         produto = wishList.products
//                 };
//         }

//     [HttpDelete(Name = "deleteProductToWishList")]
//     public WishList deleteProductToWishList(object request){

//     }
// }
