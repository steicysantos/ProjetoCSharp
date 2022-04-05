using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
namespace Model;

public class Stocks : IValidateDataObject<Stocks>{
    public int quantity;
    private Store store;
    private Product product;

    public int getQuantity(){
        return quantity;
    }

    public Store getStore(){
        return store;
    }

    public Product getProduct(){
        return product;
    }

    public void setQuantity(int quantity){
        this.quantity = quantity;
    }

    public void setStore(Store store){
        this.store = store;
    }

    public void setProduct(Product product){
        this.product = product;
    }

    public bool validateObject(Stocks obj){
        if(obj.quantity == null)
            return false;
        else if(obj.store == null)
            return false;
        else if(obj.product == null)
            return false;
        else return true;
    }

}