using System;
using Interfaces;

namespace Model;

public class Client : Person, IValidateDataObject<Client>{
    private static Client instance;
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


}