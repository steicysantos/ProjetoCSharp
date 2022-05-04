using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace Model;

public class Owner : Person,IValidateDataObject,IDataController<OwnerDTO, Owner>{

    public List<OwnerDTO> ownerDTO = new List<OwnerDTO>();
    private static Owner instance;
    Guid uuid = Guid.NewGuid();
    public static Owner getInstance(Address address){
        if(instance == null){
            instance = new Owner(address);

   
        }
        return instance;
    }

    private Owner(Address address):base(address){
        this.address = address;
    }

    public bool validateObject()
    {
        if(this.date_of_birth > DateTime.Now || DateTime.Compare(this.date_of_birth,new DateTime(1900,1,1)) < 0) return false;
        if(this.email == null) return false;
        if(this.document == null) return false;
        if(this.name == null) return false;            
        if(this.phone == null) return false;             
        if(this.login == null) return false;      
        return true;
    }
    public static Owner convertDTOToModel(OwnerDTO obj){
        var owner = new Owner(Address.convertDTOToModel(obj.address));
            owner.setDocument(obj.document);
            owner.setName(obj.name);
            owner.setDate_of_birth(obj.date_of_birth);
            owner.setEmail(obj.email);
            owner.setPhone(obj.phone);
            owner.setLogin(obj.login);
            owner.passwd=obj.passwd;
            
            return owner;
    }

    public void delete(OwnerDTO obj){

    }

    public int save()
    {
        var id = 0;

        using(var context = new DAOContext())
        {
            var owner = new DAO.Owner{
                name = this.name,
                date_of_birth = this.date_of_birth,
                document = this.document,
                email = this.email,
                phone = this.phone,
                login = this.login,
                address = new DAO.Address{
                    street = address.getStreet(),
                    city = address.getCity(),
                    state = address.getState(),
                    country = address.getCountry(),
                    postal_code = address.getPostalCode()
                },
                passwd = this.passwd
            };

            context.Owner.Add(owner);
            context.SaveChanges();
            id = owner.id;
        }
         return id;
    }
    // public int save(int owner)
    // {
    //     var id = 0;

    //     using(var context = new DAOContext())
    //     {
          
    //         var ownerDAO = context.Owner.Where(c => c.id == owner).Single();

    //         var store = new DAO.Store{
    //             Name = this.name,
    //             CNPJ = this.CNPJ,
    //             owner = ownerDAO
    //         };

    //         context.Store.Add(store);
    //         context.Entry(store.owner).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
    //         context.SaveChanges();

    //         id = store.id;

    //     }
    //      return id;
    // }

    public void update(OwnerDTO obj){

    }

    public OwnerDTO findById(int id){
        return new OwnerDTO();
    }

    public List<OwnerDTO> getAll(){
        return this.ownerDTO;
    }

    public static object find(String document){
        using (var context = new DAOContext()){

            var OwnerDAO=context.Owner.Include(i=>i.address).FirstOrDefault(e=>e.document==document);

            return new {
                name=OwnerDAO.name,
                email=OwnerDAO.email,
                passwd=OwnerDAO.passwd,
                date_of_birth=OwnerDAO.date_of_birth,
                phone=OwnerDAO.phone,
                login=OwnerDAO.login,
                address=OwnerDAO.address,
            };
        }
    }

    public OwnerDTO convertModelToDTO(){
        var ownerDTO = new OwnerDTO();
        ownerDTO.name = this.name;
        ownerDTO.date_of_birth = this.date_of_birth;
        ownerDTO.document = this.document;
        ownerDTO.email = this.email;
        ownerDTO.phone = this.phone;
        ownerDTO.login = this.login;
        ownerDTO.address = this.address.convertModelToDTO();
        return ownerDTO;
    }

}

