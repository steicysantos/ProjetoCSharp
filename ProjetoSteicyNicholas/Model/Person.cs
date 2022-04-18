namespace Model;
public class Person
{
    protected String name = "";
    protected DateTime date_of_birth;
    protected String document = "";
    protected String email = "";
    protected String phone = "";
    protected String login = "";

    protected Address address;
    protected Person(Address address){this.address=address;}
    public String getName(){
        return name;
    }

    public int getAge(){
        return age;
    }

    public String getDocument(){
        return document;
    }

    public String getEmail(){
        return email;
    }

    public String getPhone(){
        return phone;
    }

    public String getLogin(){
        return login;
    }

    public void setName(String name){
        this.name = name;
    }

    public void setAge(int age){
        this.age = age;
    }

    public void setDocument(String document){
    this.document = document;
    }

    public void setEmail(String email){
    this.email = email;
    }

    public void setPhone(String phone){
    this.phone = phone;
    }

    public void setLogin(String login){
    this.login = login;
    }

    public Address getAddress(){
        return address;
    }
}