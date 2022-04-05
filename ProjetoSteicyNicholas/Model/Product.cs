using Interfaces;
namespace Model;
public class Product: IValidateDataObject<Product>{
    private String name = "";
    private Double unitPrice;
    private String barCode = "";
    private Store store;
    
    public String getName(){
        return name;
    }
    public Double getUnitprice(){
        return unitPrice;
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
    public void setUnitPrice(Double unitPrice){
        this.unitPrice=unitPrice;
    }
    public void setBarCode(String barCode){
        this.barCode=barCode;
    }
    public void setStore(Store store){
        this.store=store;
    }

    public Boolean validateObject(Product obj)
        {
            if (obj.name == null)
                return false;
            if (obj.unitPrice == null)
                return false;
            if (obj.barCode == null)
                return false;
            return true;
        }
}
