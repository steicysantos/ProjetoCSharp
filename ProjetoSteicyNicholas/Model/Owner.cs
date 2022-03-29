namespace Model;

public class Owner : Person{

    private Owner instance;
    private Address adress;
    public static Owner getInstance(){
        if(instance == null){
            instance = new Owner();
            adress = new Address();
        }

        return instance;

    }
}

