namespace Model;

public class Owner : Person{

    private Owner instance;
    private Adress adress;
    public static Owner getInstance(){
        if(instance == null){
            instance = new Owner();
            adress = new Adress();
        }

        return instance;

    }
}

