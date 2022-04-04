namespace Model;

public class Owner : Person{


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

}

