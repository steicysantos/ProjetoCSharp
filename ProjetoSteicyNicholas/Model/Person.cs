namespace Model;
public class Person
{
    protected String name = "";
    protected int age;
    protected String document = "";
    protected String email = "";
    protected String phone = "";
    protected String login = "";

    private Address adress;

    public String getName(){
        return name;
    }

    public INT getAge(){
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

    public void setAge(INT age){
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
}