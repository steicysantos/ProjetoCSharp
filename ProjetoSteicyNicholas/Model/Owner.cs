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

    public static int update(OwnerDTO ownerDTO, int id){
        using (var context = new DAOContext()){
            var owner = context.Owner.FirstOrDefault(a => a.id == id);

            if(owner != null){
                if(ownerDTO.name != null){
                    owner.name = ownerDTO.name;
                }
                if(ownerDTO.date_of_birth !=null){
                    owner.date_of_birth = ownerDTO.date_of_birth;
                }
                if(ownerDTO.document!=null){
                     owner.document = ownerDTO.document;
                }
                if(ownerDTO.email!=null){
                     owner.email = ownerDTO.email;
                }
                if(ownerDTO.phone!=null){
                    owner.phone=ownerDTO.phone;
                }
                if(ownerDTO.login!=null){
                    owner.login=ownerDTO.login;
                }
            }
            context.SaveChanges();
        }
        return 1;

    }

    public OwnerDTO findById(int id){
        return new OwnerDTO();
    }

    public List<OwnerDTO> getAll(){
        return this.ownerDTO;
    }

    public static object find(int id){
        using (var context = new DAOContext()){

            var OwnerDAO=context.Owner.Include(i=>i.address).FirstOrDefault(e=>e.id==id);

            return new {
                name=OwnerDAO.name,
                email=OwnerDAO.email,
                passwd=OwnerDAO.passwd,
                date_of_birth=OwnerDAO.date_of_birth,
                document=OwnerDAO.document,
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

    public static DAO.Owner findByUser(String login, string password)
    {
        using (var context = new DAOContext())
        {
            var ownerDAO = context.Owner.FirstOrDefault(o => o.login == login && o.passwd==password);

            if(ownerDAO != null){

                return ownerDAO;
            }

            return null;
        }
    }

}

