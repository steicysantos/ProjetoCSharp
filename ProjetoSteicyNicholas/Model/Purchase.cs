using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model;
using Enums;

public class Purchase : IValidateDataObject, IDataController<PurchaseDTO, Purchase>
{
    private DateTime date_purchase;
    private PaymentEnum payment_type;
    private PurchaseStatusEnum purchase_status;
    private String number_confirmation;
    private String number_nf;
    private List<Product> product=new List<Product>();
    

    private Store store;
    private Client client;

    public List<PurchaseDTO> purchaseDTO = new List<PurchaseDTO>();
    


    public static Purchase convertDTOToModel(PurchaseDTO obj)
    {
        var purchase = new Purchase();
        purchase.client =  Client.convertDTOToModel(obj.client);
        purchase.setDate_purchase(obj.date_purchase);
        purchase.setPurchase_status(obj.purchase_status);
        purchase.payment_type=obj.payment_type;
        purchase.setNumber_confirmation(obj.number_confirmation);
        purchase.setNumber_nf(obj.number_nf);

        return purchase;
    }


    public Boolean validateObject()
    {
        return true;
    }

    public void delete(PurchaseDTO obj)
    {

    }

    // public int save()
    // {
    //     var id = 0;
    //     using (var context = new DAOContext())
    //     {
    //         var clientDAO =  context.Client.FirstOrDefault(c => c.id == 1);
    //         var storeDAO = context.stores.FirstOrDefault(s =>s.id ==1);
    //         var productsDAO = context.products.Where(p => p.id == 1).Single();
            
    //         var purchase = new DAO.Purchase {
    //             date_purchase = this.date_purchase,
    //             payment_type = this.payment_type,
    //             purchase_status = this.purchase_status,
    //             purchase_values = this.purchase_value,
    //             number_confirmation = this.getNumberConfirmation(),
    //             number_nf = this.getNumberNf(),
    //             client = clientDAO,
    //             store = storeDAO,
    //             product = productsDAO
    //         };

    //         context.purchases.Add(purchase);
    //         context.Entry(purchase.client).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
    //         context.Entry(purchase.store).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
    //         context.Entry(purchase.product).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
    //         context.SaveChanges();
    //         id = purchase.id;
            
            
    //     };
    //     return id;
    // }
    public int save(int client, int store, int product, DateTime data, PaymentEnum paymenttype, PurchaseStatusEnum status, string numberconf, string nf)
    {
        var id = 0;

        using(var context = new DAOContext())
        {
            var clientDAO =  context.Client.FirstOrDefault(c => c.id == client);
            var storeDAO = context.Store.FirstOrDefault(s =>s.id == store);
            var productsDAO = context.Product.Where(p => p.id == product).Single();


            var purchase = new DAO.Purchase{
                date_purchase = data,
                number_confirmation = numberconf,
                number_nf = nf,
                payment_type = paymenttype,
                purchase_status = status,
                store=storeDAO,
                client=clientDAO,
                product=productsDAO
            };

            context.Purchase.Add(purchase);
            context.SaveChanges();
            id = purchase.id;
        }
         return id;
    }

    public void update(PurchaseDTO obj)
    {

    }

    public static List<object> getStorePurchases(int storeID){
        using(var context = new DAOContext()){
            var storePurchase = context.Purchase
            .Include(s => s.store)
            .Include(o => o.store.owner)
            .Include(a => a.store.owner.address)
            .Include(p => p.product)
            .Include(c => c.client)
            .Include(a => a.client.address)
            .Where(p => p.store.id == storeID);
             List<object> compras = new List<object>();
             foreach(var compra in storePurchase){
                 compras.Add(compra);
             }
            return compras;
        }
    }

     public static List<object> getClientPurchases(int clientID){
        using(var context = new DAOContext()){
            var storePurchase = context.Purchase
            .Include(s => s.store)
            .Include(o => o.store.owner)
            .Include(a => a.store.owner.address)
            .Include(p => p.product)
            .Include(a => a.client.address)
            .Where(p => p.client.id == clientID);
             List<object> compras = new List<object>();
             foreach(var compra in storePurchase){
                 compras.Add(compra);
             }
            return compras;
        }
    }

    public PurchaseDTO findById(int id)
    {

        return new PurchaseDTO();
    }

    public List<PurchaseDTO> getAll()
    {        
        return this.purchaseDTO;      
    }

   
    public PurchaseDTO convertModelToDTO()
    {
        var purchaseDTO = new PurchaseDTO();

        purchaseDTO.date_purchase = this.date_purchase;

        purchaseDTO.purchase_status = this.purchase_status;

        purchaseDTO.payment_type = this.payment_type;

        purchaseDTO.number_confirmation = this.number_confirmation;

        purchaseDTO.number_nf = this.number_nf;

        foreach(var item in this.product){
            purchaseDTO.product.Add(item.convertModelToDTO());
        }

        // purchaseDTO.store = this.store.convertModelToDTO();

        purchaseDTO.client = this.client.convertModelToDTO();

        return purchaseDTO;
    }

    public void setDate_purchase(DateTime date_purchase)
    {
        this.date_purchase = date_purchase;
    }

    public void setPurchase_status(PurchaseStatusEnum purchase_status)
    {
        this.purchase_status = purchase_status;
    }

    public void setPayment_type(PaymentEnum payment_type)
    {
        this.payment_type = payment_type;
    }

    public void setNumber_confirmation(String number_confirmation)
    {
        this.number_confirmation = number_confirmation;
    }

    public void setNumber_nf(String number_nf)
    {
        this.number_nf = number_nf;
    }
    public void setProducts(List<Product> product)
    {
        this.product = product;
    }

    public void setStore(Store store)
    {
        this.store = store;
    }
    public void setClient(Client client)
    {
        this.client = client;
    }

    public DateTime getDatePurchase()
    {
        return this.date_purchase;
    }

    public PurchaseStatusEnum getPurchaseStatus()
    {        
        return this.purchase_status;
    }

    public PaymentEnum getPaymentType()
    {
        return this.payment_type;
    }

    public String getNumberConfirmation()
    {
        return this.number_confirmation;
    }

    public String getNumberNF()
    {
        return this.number_nf;
    }

    public List<Product> getProducts()
    {
        return this.product;
    }

    public Store getStore()
    {
        return this.store;
    }

    public Client getClient()
    {
        return this.client;
    }

}