using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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
    public List<ClientDTO> clientDTO = new List<ClientDTO>();
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
            client.setPasswd(obj.passwd);
            
            return client;
    }

    public void delete(ClientDTO obj){

    }

    public int save()
    {
        var id = 0;

        using(var context = new DAOContext())
        {
            
            var addressDAO = new DAO.Address{
                    street = this.address.getStreet(),
                    city = this.address.getCity(),
                    state = this.address.getState(),
                    country = this.address.getCountry(),
                    postal_code = this.address.getPostalCode(),
                };
            var client = new DAO.Client();
                client.name = this.name;
                client.date_of_birth = this.date_of_birth;
                client.document = this.document;
                client.email = this.email;
                client.phone = this.phone;
                client.login = this.login;
                client.address=addressDAO;
                client.passwd = this.getPasswd();

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

    public static object find(int id){
        using (var context = new DAOContext()){

            var ClientDAO=context.Client.Include(i=>i.address).FirstOrDefault(e=>e.id==id);

            return new {
                name=ClientDAO.name,
                email=ClientDAO.email,
                passwd=ClientDAO.passwd,
                date_of_birth=ClientDAO.date_of_birth,
                document=ClientDAO.document,
                phone=ClientDAO.phone,
                login=ClientDAO.login,
                address=ClientDAO.address,
            };
        }
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

    public static DAO.Client findByUser(String login, string password)
    {
        using (var context = new DAOContext())
        {
            var clientDAO = context.Client.FirstOrDefault(o => o.login == login && o.passwd==password);

            if(clientDAO != null){

                return clientDAO;
            }

            return null;
        }
    }
    // public static Client convertDAOToModel(DAO.Client obj){
    //     var client = new Client();
        
    //     client.setDocument(obj.document);
    //     client.setName(obj.name);
    //     client.setDateOfBirth(obj.date_of_birth);
    //     client.setEmail(obj.email);
    //     client.setPhone(obj.phone);
    //     client.setLogin(obj.login);
    //     client.setPassword(obj.password);
    //     client.address = Address.convertDAOToModel(obj.address);

    //     return client;
    // }

}