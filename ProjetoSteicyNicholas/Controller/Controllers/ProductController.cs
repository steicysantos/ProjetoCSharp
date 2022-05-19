using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace Controller.Controllers;

[ApiController]
[Route("product")]
public class ProductController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public object registerProduct(ProductDTO product){
        var productModel = Model.Product.convertDTOToModel(product);
        var id = productModel.save();
        return new{
            nome = product.name,
            codigoBarra = product.bar_code,
            id = id
        };
    }

    [HttpGet]
        [Route("getAll")]
        public IActionResult allProduct(){
                var produtos = Model.Product.getProducts();
                var result = new ObjectResult(produtos);
                Response.Headers.Add("Access-Control-Allow-Origin", "*");
                return result; 
        }
    //     [HttpGet]
    // [Route("get/{id}")]
    // public IActionResult getProductById(int id){
    //     var prod = Model.Product.find(id);
    //      var result = new ObjectResult(prod);
    //      Response.Headers.Add("Access-Control-Allow-Origin", "*");
    //     return result;
    // }
    [HttpDelete]
    [Route("delete")]
    public object deleteProduct([FromBody]ProductDTO productDTO){
            var produto = Model.Product.convertDTOToModel(productDTO);
            produto.delete();

            return new {
                    status = "ok",
                    mensagem = "excluido"
            };
    }
    [HttpPut]
    [Route("update")]
    public Object updateProduct([FromBody] ProductDTO productDTO){
        Model.Product.update(productDTO);
        return new{
                status = "ok",
                mensagem = "deu boa"
        };
        }
}