using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;

namespace Model;

public class Client : Person, IValidateDataObject<Client>,IDataController<ClientDTO, Client>{
    private static Client instance;
    Guid uuid = Guid.NewGuid();
    public static Client getInstance(Address address){
        if(Client.instance == null){
            Client.instance = new Client(address);
        }
        return instance;
    }

    private Client(Address address):base(address){
        this.address = address;
    }

    public bool validateObject(Client obj)
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

     public static Client convertDTOToModel(ClientDTO obj){
        return new Client(obj.name, obj.date_of_birth, obj.document, obj.email, obj.phone, obj.login, obj.address);
    }

    public void delete(ClientDTO obj){

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

    public void update(ClientDTO obj){

    }

    public ClientDTO findById(int id){
        return new ClientDTO();
    }

    public List<ClientDTO> getAll(){
        return this.clientDTO;
    }

    public ClientDTO convertModelToDTO(){
        var clientDTO = new ClientDTO();
        clientDTO.name = this.name;
        clientDTO.date_of_birth = this.date_of_birth;
        clientDTO.document = this.document;
        clientDTO.email = this.email;
        clientDTO.phone = this.phone;
        clientDTO.login = this.login;
        clientDTO.address = this.address;
    }



}