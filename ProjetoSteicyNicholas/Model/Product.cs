using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;
namespace Model;
public class Product: IValidateDataObject,IDataController<ProductDTO, Product>{
    private String name = "";
    private String bar_code = "";

    
    public List<ProductDTO> productDTO = new List<ProductDTO>();

    public static Product convertDTOToModel(ProductDTO obj)
    {
        var product = new Product();
        product.setName(obj.name);
        product.setBarCode(obj.bar_code);
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
                bar_code = this.bar_code
            };

            context.Product.Add(product);
            context.SaveChanges();
            id = product.id;
        }
         return id;
    }

    public void update(ProductDTO obj){

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
        return productDTO;
    }

    public String getName(){
        return name;
    }

    public String getBarCode(){
        return bar_code;
    }
    public void setName(String name){
        this.name=name;
    }
    public void setBarCode(String bar_code){
        this.bar_code=bar_code;
    }

    public bool validateObject()
    {
        if(this.name == null) return false;            
        if(this.bar_code == null) return false;               
        return true;
    }
    public static List<object> getProducts()
    {
        using(var context = new DAOContext()){
            var products = context.Product;

            List<object> produtos = new List<object>();
            foreach(var product in products){
                produtos.Add(product);
            }

            return produtos;
        }
    }
    public void delete()
    {
        using (var context = new DAOContext()){
            var produto = context.Product.FirstOrDefault(i => i.bar_code == this.bar_code );

            context.Product.Remove(produto);
            context.SaveChanges();
        }
    }
}
