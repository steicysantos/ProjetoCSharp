using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;

namespace Model;

public class Client : Person, IValidateDataObject,IDataController<ClientDTO, Client>{
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

     public static Client convertDTOToModel(ClientDTO obj){
        var client = new Client(Address.convertDTOToModel(obj.address));
            client.setDocument(obj.document);
            client.setName(obj.name);
            client.setDate_of_birth(obj.date_of_birth);
            client.setEmail(obj.email);
            client.setPhone(obj.phone);
            client.setLogin(obj.login);
            
            return client;
    }

    public void delete(ClientDTO obj){

    }

    // public int save()
    // {
    //     var id = 0;

    //     using(var context = new DAOContext())
    //     {
    //         var client = new DAO.Client{
    //             name = this.name,
    //             date_of_birth = this.date_of_birth,
    //             document = this.document,
    //             email = this.email,
    //             phone = this.phone,
    //             login = this.login,
    //             address = this.address
    //         };

    //         context.Client.Add(client);
    //         context.SaveChanges();
    //         id = client.id;

    //     }
    //      return id;
    // }

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
        clientDTO.address = this.address.convertModelToDTO();
        return clientDTO;
    }



}