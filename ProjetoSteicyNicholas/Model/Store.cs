using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;
namespace Model;

public class Store : IValidateDataObject, IDataController<StoreDTO, Store>
{
    private String name;
    private String CNPJ;
    private Owner owner;
    private List<Purchase> purchase=new List<Purchase>();
    public List<StoreDTO> storeDTO = new List<StoreDTO>();
    List<Purchase> purchases = new List<Purchase>();
    public Store(Owner owner){this.owner=owner;}
    public void addNewPurchase(Purchase purchase){
        purchases.Add(purchase);
    }

    public static Store convertDTOToModel(StoreDTO obj)
    {
        var store = new Store(Owner.convertDTOToModel(obj.owner));
        store.setName(obj.name);
        store.setCNPJ(obj.CNPJ);        
        foreach(var item in obj.purchase){
            store.purchase.Add(Purchase.convertDTOToModel(item));
        }
        
        return  store;
    }
    public void delete(StoreDTO obj)
    {

    }
    public int save(int owner)
    {
        var id = 0;

        using(var context = new DAOContext())
        {
            var ownerDAO = context.Owner.Where(c => c.id == owner).Single();
            var store = new DAO.Store{
                owner = ownerDAO,
                Name = this.name,
                CNPJ = this.CNPJ
                //lista de purchase
            };

            context.Store.Add(store);
            context.Entry(store.owner).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.SaveChanges();
            id = store.id;
        }
         return id;
    }

    public void update(StoreDTO obj)
    {

    }

    public StoreDTO findById(int id)
    {

        return new StoreDTO();
    }

    public List<StoreDTO> getAll()
    {        
        return this.storeDTO;      
    }

   
    public StoreDTO convertModelToDTO()
    {
        var storeDTO = new StoreDTO();

        storeDTO.name = this.name;

        storeDTO.CNPJ = this.CNPJ;

        storeDTO.owner = this.owner.convertModelToDTO();

        foreach(var item in this.purchases){
            storeDTO.purchase.Add(item.convertModelToDTO());
        }

        return storeDTO;
    }

    public String getName(){
        return name;
    }
    public String getCNPJ(){
        return CNPJ;
    }
    public Owner getOwner(){
        return owner;
    }
    public List<Purchase> getPurchase(){
        return purchase;
    }

    public void setName(String name){
        this.name=name;
    }
    public void setCNPJ(String CNPJ){
        this.CNPJ=CNPJ;
    }
    public void setOwner(Owner owner){
        this.owner=owner;
    }
    public void setPurchase(List<Purchase> purchase){
        this.purchase=purchase;
    }
    public bool validateObject()
    {
        if(this.name == null) return false;
        if(this.CNPJ == null) return false;            
        if(this.owner == null) return false;             
        if(this.purchase == null) return false;      
        return true;
    }
}
