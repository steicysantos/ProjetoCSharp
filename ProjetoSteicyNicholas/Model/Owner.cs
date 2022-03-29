namespace Model;

public class Owner : Person{

    private static Owner instance;
    private static Adress adress;
    public static Owner getInstance(Adress adress){
        if(instance == null){
            instance = new Owner(adress);
        }
        return instance;
    }

    private Owner(Adress adress){
        Owner.adress = adress;
    }

}

