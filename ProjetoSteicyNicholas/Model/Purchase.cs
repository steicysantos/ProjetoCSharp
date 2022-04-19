using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;

namespace Model;
using Enums;

public class Purchase : IValidateDataObject, IDataController<PurchaseDTO, Purchase>
{
    private DateTime datePurchase;
    private int purchaseStatus;
    private int paymentType;
    private String numberConfirmation;
    private String numberNF;
    private List<Product> product=new List<Product>();
    private Store store;
    private Client client;


    public static Purchase convertDTOToModel(PurchaseDTO obj)
    {
        var purchase = new Purchase();
        purchase.client =  Client.convertDTOToModel(obj.client);
        purchase.store =  Store.convertDTOToModel(obj.store);
        purchase.product=Product.convertDTOToModel(obj.product);
        purchase.setDatePurchase(obj.datePurchase);
        purchase.setPurchaseStatus(obj.purchaseStatus);
        purchase.setPaymentType(obj.paymentType);
        purchase.setNumberConfirmation(obj.numberConfirmation);
        purchase.setNumberNF(obj.numberNF);

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

    //     using(var context = new DAOContext())
    //     {
    //         var purchase = new DAO.Purchase{
    //             datepurchase = this.datepurchase,
    //             purchaseStatus = this.purchaseStatus,
    //             paymentType = this.paymentType,
    //             numberConfirmation = this.numberConfirmation,
    //             numberNF = this.numberNF,
    //             product = this.product,
    //             store = this.store,
    //             client = this.client
    //         };

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

        purchaseDTO.datePurchase = this.datePurchase;

        purchaseDTO.purchaseStatus = this.purchaseStatus;

        purchaseDTO.paymentType = this.paymentType;

        purchaseDTO.numberConfirmation = this.numberConfirmation;

        purchaseDTO.numberNF = this.numberNF;

        purchaseDTO.product = this.product.convertModelToDTO();

        purchaseDTO.store = this.store.convertModelToDTO();

        purchaseDTO.client = this.client.convertModelToDTO();

        return purchaseDTO;
    }

    public void setDatePurchase(DateTime datepurchase)
    {
        this.datePurchase = datePurchase;
    }

    public void setPurchaseStatus(String purchaseStatus)
    {
        this.purchaseStatus = purchaseStatus;
    }

    public void setPaymentType(String paymentType)
    {
        this.paymentType = paymentType;
    }

    public void setNumberConfirmation(String numberConfirmation)
    {
        this.numberConfirmation = numberConfirmation;
    }

    public void setNumberNF(String numberNF)
    {
        this.numberNF = numberNF;
    }
    public void setProduct(String product)
    {
        this.product = product;
    }

    public void setStore(String store)
    {
        this.store = store;
    }
    public void setClient(String client)
    {
        this.client = client;
    }

    public DateTime getDatePurchase()
    {
        return this.datePurchase;
    }

    public int getPurchaseStatus()
    {        
        return this.purchaseStatus;
    }

    public int getPaymentType()
    {
        return this.paymentType;
    }

    public String getNumberConfirmation()
    {
        return this.numberConfirmation;
    }

    public String getNumberNF()
    {
        return this.numberNF;
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