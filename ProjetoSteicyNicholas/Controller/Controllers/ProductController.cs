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
        public object allProduct(){
                var produtos = Model.Product.getProducts();
                return produtos; 
        }
}