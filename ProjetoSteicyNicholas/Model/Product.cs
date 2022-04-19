using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;
namespace Model;
public class Product: IValidateDataObject,IDataController<ProductDTO, Product>{
    private String name = "";
    private String barCode = "";
    private Store store;
    

    public Product(String name,String barCode, Store store){
        this.name =  name;
        this.barCode = barCode;
        this.store = store;
    }

    public static Product convertDTOToModel(ProductDTO obj)
    {
        return new Product(obj.name, obj.barCode, obj.store);
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
                barCode = this.barCode,
                store = this.store
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
        return this.ProductDTO;
    }

    public ProductDTO convertModelToDTO(){
        var ProductDTO = new ProductDTO();
        ProductDTO.name = this.name;
        ProductDTO.barCode = this.barCode;
        ProductDTO.store = this.store;
    }

    public String getName(){
        return name;
    }
    public String getBarCode(){
        return barCode;
    }
    public Store getStore(){
        return store;
    }
    public void setName(String name){
        this.name=name;
    }
    public void setBarCode(String barCode){
        this.barCode=barCode;
    }
    public void setStore(Store store){
        this.store=store;
    }

    public bool validateObject()
    {
        if(this.name == null) return false;            
        if(this.barCode == null) return false;             
        if(this.store == null) return false;      
        return true;
    }
}
