namespace Model;

public class Client : Person{
    private static Person instance;
    private static Adress adress;
    public static Person getInstance(Adress adress){
        if(instance == null){
            instance = new Person(adress);
        }
        return instance;
    }

    private Person(Adress adress){
        Person.adress = adress;
    }

    

    
}