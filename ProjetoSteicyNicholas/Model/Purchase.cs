using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;

namespace Model;
using Enums;

public class Purchase : IValidateDataObject, IDataController<PurchaseDTO, Purchase>
{
    private DateTime date_purchase;
    private int purchase_status;
    private int payment_type;
    private String number_confirmation;
    private String number_nf;
    private List<Product> product=new List<Product>();
    

    private Store store;
    private Client client;

    


    public static Purchase convertDTOToModel(PurchaseDTO obj)
    {
        var purchase = new Purchase();
        purchase.client =  Client.convertDTOToModel(obj.client);
        purchase.store =  Store.convertDTOToModel(obj.store);
        purchase.product=Product.convertDTOToModel(obj.product);
        purchase.setDate_purchase(obj.date_purchase);
        purchase.setPurchase_status(obj.purchase_status);
        purchase.setPayment_type(obj.payment_type);
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


        // using(var context = new DAOContext())
        // {
        //     var purchase = new DAO.Purchase{
        //         date_purchase = this.date_purchase,
        //         purchase_status = this.purchase_status,
        //         payment_type = this.payment_type,
        //         number_confirmation = this.number_confirmation,
        //         number_nf = this.number_nf,
        //         product = this.product,
        //         store = this.store,
        //         client = this.client
        //     };




    //         context.Purchase.Add(purchase);

    //         context.SaveChanges();

    //         id = purchase.id;

    //     }
    //      return id;
    // }

    public void update(PurchaseDTO obj)
    {

    }

    public PurchaseDTO findById(int id)
    {

        return new PurchaseDTO();
    }

    public List<PurchaseDTO> getAll()
    {        
        return this.PurchaseDTO;      
    }

   
    public PurchaseDTO convertModelToDTO()
    {
        var purchaseDTO = new PurchaseDTO();

        PurchaseDTO.date_purchase = this.date_purchase;

        PurchaseDTO.purchase_status = this.purchase_status;

        PurchaseDTO.payment_type = this.payment_type;

        PurchaseDTO.number_confirmation = this.number_confirmation;

        PurchaseDTO.number_nf = this.number_nf;


        purchaseDTO.product = this.product.convertModelToDTO();

        purchaseDTO.store = this.store.convertModelToDTO();

        purchaseDTO.client = this.client.convertModelToDTO();

        return purchaseDTO;
    }

    public void setDatePurchase(DateTime date_purchase)
    {
        this.date_purchase = date_purchase;
    }

    public void setPurchaseStatus(int purchase_status)
    {
        this.purchase_status = purchase_status;
    }

    public void setPaymentType(int payment_type)
    {
        this.payment_type = payment_type;
    }

    public void setNumberConfirmation(String number_confirmation)
    {
        this.number_confirmation = number_confirmation;
    }

    public void setNumberNF(String number_nf)
    {
        this.number_nf = number_nf;
    }
    public void setProduct(String product)
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

    public int getPurchaseStatus()
    {        
        return this.purchase_status;
    }

    public int getPaymentType()
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

    public List<Product> getProduct()
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