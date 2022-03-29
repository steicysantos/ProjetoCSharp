namespace Model;
public class Adress{
    protected String street = "";
    protected String city = "";
    protected String state = "";
    protected String country = "";
    protected String posteCode = "";



    public string getStreet(){
        return street;
    }
     public string getCity(){
        return city;
    }
    public string getState(){
        return state;
    }
    public string getCountry(){
        return country;
    }
    public string getPosteCode(){
        return posteCode;
    }

    public void setStreet(string street){
        this.street=street;
    }
    public void setCity(string city){
        this.city=city;
    }
    public void setState(string state){
        this.state=state;
    }
    public void setCountry(string country){
        this.country=country;
    }
    public void setPosteCode(string posteCode){
        this.posteCode=posteCode;
    }
}