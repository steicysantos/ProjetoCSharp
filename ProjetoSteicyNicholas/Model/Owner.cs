using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;
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

    public bool validateObject(Owner obj)
    {
        if (obj.name == null)
            return false;
        else if (obj.age == null)
            return false;
        else if (obj.document == null)
            return false;
        else if (obj.email == null)
            return false;
        else if (obj.phone == null)
            return false;
        else if(obj.login==null)
            return false;
        else return true;

    }
    public static Owner convertDTOToModel(OwnerDTO obj){
        return new Client(obj.name, obj.date_of_birth, obj.document, obj.email, obj.phone, obj.login, obj.address);
    }

    public void delete(OwnerDTO obj){

    }

    public int save()
    {
        var id = 0;

        using(var context = new DAOContext())
        {
            var client = new DAO.Client{
                name = this.name,
                date_of_birth = this.date_of_birth,
                document = this.document,
                email = this.email,
                phone = this.phone,
                login = this.login,
                address = this.address
            };

            context.Client.Add(client);
            context.SaveChanges();
            id = client.id;

        }
         return id;
    }

    public void update(OwnerDTO obj){

    }

    public OwnerDTO findById(int id){
        return new OwnerDTO();
    }

    public List<OwnerDTO> getAll(){
        return this.ownerDTO;
    }

    public OwnerDTO convertModelToDTO(){
        var ownerDTO = new OwnerDTO();
        OwnerDTO.name = this.name;
        OwnerDTO.date_of_birth = this.date_of_birth;
        OwnerDTO.document = this.document;
        OwnerDTO.email = this.email;
        OwnerDTO.phone = this.phone;
        OwnerDTO.login = this.login;
        OwnerDTO.address = this.address;
    }

}

