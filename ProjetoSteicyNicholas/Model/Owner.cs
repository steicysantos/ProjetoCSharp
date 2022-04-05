<<<<<<< HEAD
﻿using System;
using Interfaces;
namespace Model;
=======
﻿namespace Model;
using Interfaces;
>>>>>>> 29b7f701d1ca61a55db215810abf4a58b133276e

public class Owner : Person,IValidateDataObject<Owner>{


    private static Owner instance;
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

}

