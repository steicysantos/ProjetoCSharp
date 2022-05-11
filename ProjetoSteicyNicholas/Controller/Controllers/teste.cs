// namespace model;
// using DAO;
// using DTO;
// using System.Collections.Generic;
// using Interfaces;
// using Microsoft.EntityFrameworkCore;

// public class Store : IValidateDataObject, IDataController<StoreDTO, Store>
// {
//     Owner owner;
//     private String name;
//     private String CNPJ;
//     private List<Purchase> purchases = new List<Purchase>();
//     List<StoreDTO> storeDTO = new List<StoreDTO>();
//     public void addNewPurchase(Purchase purchase){
//         purchases.Add(purchase);
//     }

//     public Store(Owner owner){
//         this.owner = owner;
//     }

//     private Store(){}

//     public String getName()
//     {
//         return name;
//     }

//     public String getCNPJ()
//     {
//         return CNPJ;
//     }

//     public Owner getOwner()
//     {
//         return owner;
//     }

//     public void setName(String name)
//     {
//         this.name = name;
//     }

//     public void setCNPJ(String CNPJ)
//     {
//         this.CNPJ = CNPJ;
//     }

//     public void setOwner(Owner owner)
//     {
//         this.owner = owner;
//     }

//     public bool validateObject()
//     {
//         if(this.getCNPJ() == null)
//         {
//             return false;
//         }
//         if(this.getName() == null)
//         {
//             return false;
//         }
//         return true;
//     }

//     //DTO's
//     public void delete(StoreDTO obj){

//     }

//     public int save(int owner)
//     {
//         var id = 0;

//         using(var context = new DaoContext())
//         {
//             var ownerDAO = context.owners.Where(c => c.id == owner).Single();
//             var store = new DAO.Store{
//                 owner = ownerDAO,
//                 name = this.name,
//                 CNPJ = this.CNPJ
//             };

//             context.stores.Add(store);
//             context.Entry(store.owner).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
//             context.SaveChanges();
//             id = store.id;
//         }
//          return id;
//     }

//     public void update(StoreDTO obj){

//     }

//     public StoreDTO findById(int id){



//         return new StoreDTO();
//     }

//     public static object getStoreInfo(string cnpj){
//         using(var context = new DaoContext()){
//             var storeDAO = context.stores.Include(s => s.owner).Include(s => s.owner.address).FirstOrDefault(p => p.CNPJ == cnpj);

//             return new {
//                 name = storeDAO.name,
//                 cnpj = storeDAO.CNPJ,
//                 owner = storeDAO.owner,
//             };
//         }
//     }

//     public static List<object> getStores(){
//         using (var context = new DaoContext()){
//             var stores = context.stores.Include(s => s.owner);
//             List<object> lojas = new List<object>();
//             foreach(var store in stores){
//                 lojas.Add(store);
//             }

//             return lojas;
//         }
//     }

//     public List<StoreDTO> getAll(){
//         return this.storeDTO;
//     }

//     public StoreDTO convertModelToDTO(){
//         var storeDTO = new StoreDTO();
//         storeDTO.name = this.name;
//         storeDTO.CNPJ = this.CNPJ;
//         storeDTO.owner = this.owner.convertModelToDTO();
//         foreach(var purchase in this.purchases){
//             storeDTO.purchases.Add(purchase.convertModelToDTO());
//         }

//         return storeDTO;
//     }

//      public static Store convertDTOToModel(StoreDTO obj){
//        // var store = new Store(Owner.convertDTOToModel(obj.owner));

//        var store = new Store();

//        if(obj.owner != null){
//            store.owner = Owner.convertDTOToModel(obj.owner);
//        }

//         store.setCNPJ(obj.CNPJ);
//         store.setName(obj.name);

//         foreach(var purchase in obj.purchases){
//             store.addNewPurchase(Purchase.convertDTOToModel(purchase));
//         }

//         return store;
//     }
// }