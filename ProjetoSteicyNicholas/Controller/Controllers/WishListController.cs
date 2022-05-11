using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;
namespace Controller.Controllers;

[ApiController]
[Route("wishlist")]
public class WishListController : ControllerBase
{
    [HttpPost]
    [Route("register")]
        public object addProductToWishList([FromBody]WishListDTO wishList){
            var wishListModel = Model.WishList.convertDTOToModel(wishList);
            var id = 0;
            foreach(var product in wishList.products){
                    var idProduto = Model.Product.find(product);

                    id = wishListModel.save(wishList.client.document, idProduto);
            }
            return new {
                    id = id,
                    client = wishList.client.document,
                    produto = wishList.products
            };
        }

    [HttpDelete]
    [Route("delete")]
    public object removeProductToWishList([FromBody]WishListDTO wishListDTO){
            Model.WishList.convertDTOToModel(wishListDTO).delete();
            return new {
                    status = "ok",
                    mensagem = "excluido"
            };
    }
}
