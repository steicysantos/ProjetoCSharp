using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace Controller.Controllers;

[ApiController]
[Route("wishlist")]
public class WishListController : ControllerBase
{      
        [Authorize]
        [HttpPost]
        [Route("register")]
                public object addProductToWishList([FromBody]StocksRequestDTO stocksDTO){
                var ClientId = Lib.GetIdFromRequest( Request.Headers["Authorization"].ToString());
                var wishlist = new Model.WishList();
                wishlist.save(stocksDTO.id, ClientId);
        return new
        {
                response = "salvou no banco"
        };
                }
        [Authorize]
        [HttpDelete]
        [Route("delete/{idwishlist}")]
        public string removeProductToWishList(int idwishlist){
                var ClientId = Lib.GetIdFromRequest( Request.Headers["Authorization"].ToString());
                var response = Model.WishList.delete(idwishlist,ClientId);
                return response;
        }
        [Authorize]
        [HttpGet]
        [Route("getwishlist")]
        public IActionResult GetWishList(){
        var ClientId = Lib.GetIdFromRequest( Request.Headers["Authorization"].ToString());
                var tabela=Model.WishList.GetWishList(ClientId);
                var result = new ObjectResult(tabela);
                return result;
        }
        [Authorize]
        [HttpGet]
        [Route("getproduct")]
        public IActionResult getproduct(){
                var ClientId = Lib.GetIdFromRequest( Request.Headers["Authorization"].ToString());
                var tabela=Model.WishList.getProduct(ClientId);
                var result = new ObjectResult(tabela);
                return result;
        }

        [Authorize]
        [HttpDelete]
        [Route("deleteStock/{idstock}")]
        public string removeProductFromWishList(int idstock){
                var ClientId = Lib.GetIdFromRequest( Request.Headers["Authorization"].ToString());
                var response = Model.WishList.deleteFromStock(idstock,ClientId);
                return response;
        }

        
}
