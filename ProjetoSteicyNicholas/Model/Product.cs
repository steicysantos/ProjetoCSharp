using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace Model;
public class Product: IValidateDataObject,IDataController<ProductDTO, Product>{
    private String name = "";
    private String bar_code = "";
    private string image;
    private string description;

    
    public List<ProductDTO> productDTO = new List<ProductDTO>();

    public static Product convertDTOToModel(ProductDTO obj)
    {
        var product = new Product();
        product.setName(obj.name);
        product.setBarCode(obj.bar_code);
        product.setImage(obj.image);
        product.setDescription(obj.description);
        return product;
    }

    public void delete(ProductDTO obj){

    }

    public int save()
    {
        var id = 0;

        using(var context = new DAOContext())
        {
            var product = new DAO.Product{
                name = this.name,
                bar_code = this.bar_code,
                image=this.image,
                description=this.description
            };

            context.Product.Add(product);
            context.SaveChanges();
            id = product.id;
        }
         return id;
    }

     public static void update(ProductDTO productDTO)
    {
        using (var context = new DAOContext()){
            var product = context.Product.FirstOrDefault(a => a.bar_code == productDTO.bar_code);

            if(product != null){
                if(productDTO.name != null){
                    product.name = productDTO.name;
                }
            }
            context.SaveChanges();
        }
    }

    public static int find(ProductDTO productDTO){
        using (var context = new DAOContext()){
            var produto = context.Product.FirstOrDefault(s => s.bar_code == productDTO.bar_code);

            return produto.id;
        }
    }
    public ProductDTO findById(int id){
        return new ProductDTO();
    }

    public List<ProductDTO> getAll(){
        return this.productDTO;
    }

    public ProductDTO convertModelToDTO(){
        var productDTO = new ProductDTO();
        productDTO.name = this.name;
        productDTO.bar_code = this.bar_code;
        productDTO.image = this.image;
        productDTO.description = this.description;
        return productDTO;
    }

    public String getName(){
        return name;
    }

    public String getBarCode(){
        return bar_code;
    }
    public String getImage(){
        return image;
    }
    public String getDescription(){
        return description;
    }
    public void setName(String name){
        this.name=name;
    }
    public void setBarCode(String bar_code){
        this.bar_code=bar_code;
    }
    public void setImage(String image){
        this.image=image;
    }
    public void setDescription(String description){
        this.description=description;
    }

    public bool validateObject()
    {
        if(this.name == null) return false;            
        if(this.bar_code == null) return false;               
        return true;
    }
    public static List<object> getProducts()
    {
            List<object> produtos = new List<object>();

            using(var context = new DAOContext()){

                var stocks = context.Stock.Include(s => s.product).ToList();
                foreach(var stock in stocks)
                {
                    produtos.Add(new
                    {
                        id = stock.product.id,
                        name = stock.product.name,
                        bar_code = stock.product.bar_code,
                        image = stock.product.image,
                        description = stock.product.description,
                        price = stock.unit_price,
                        IdStocks=stock.id
                    });
                }
            }
            return produtos;
        }
    public void delete()
    {
        using (var context = new DAOContext()){
            var produto = context.Product.FirstOrDefault(i => i.bar_code == this.bar_code );

            context.Product.Remove(produto);
            context.SaveChanges();
        }
    }

    public static int findId(string bar_code){
        using(var context = new DAOContext()){
            var product = context.Product.FirstOrDefault(s => s.bar_code == bar_code);
            return product.id;
        }
    }
}
