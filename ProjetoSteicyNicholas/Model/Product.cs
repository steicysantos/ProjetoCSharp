using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;
namespace Model;
public class Product: IValidateDataObject,IDataController<ProductDTO, Product>{
    private String name = "";
    private String bar_code = "";
    private Store store;
    
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

    // public int save()
    // {
    //     var id = 0;

    //     using(var context = new DAOContext())
    //     {
    //         var product = new DAO.Product{
    //             name = this.name,
    //             barCode = this.barCode,
    //             store = this.store
    //         };

    //         context.Product.Add(product);
    //         context.SaveChanges();
    //         id = product.id;

    //     }
    //      return id;
    // }

    public void update(ProductDTO obj){

    }

    public ProductDTO findById(int id){
        return new ProductDTO();
    }

    public List<ProductDTO> getAll(){
        return this.ProductDTO;
    }

    public ProductDTO convertModelToDTO(){
        var productDTO = new ProductDTO();
        productDTO.name = this.name;
        productDTO.bar_code = this.bar_code;
        productDTO.store = this.store.convertModelToDTO();
        return productDTO;
    }

    public String getName(){
        return name;
    }
    public String getBarCode(){
        return bar_code;
    }
    public Store getStore(){
        return store;
    }
    public void setName(String name){
        this.name=name;
    }
    public void setBarCode(String bar_code){
        this.bar_code=bar_code;
    }
    public void setStore(Store store){
        this.store=store;
    }

    public bool validateObject()
    {
        if(this.name == null) return false;            
        if(this.bar_code == null) return false;             
        if(this.store == null) return false;      
        return true;
    }
}
