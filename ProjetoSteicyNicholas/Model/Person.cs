using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;

namespace Model;

public class Person
{
    protected String name;
    protected DateTime date_of_birth;
    protected String document;
    protected String email;
    protected String phone;
    protected String login;
    protected String passwd;
    protected Address address;
    protected Person(Address address){
        this.address=address;
    }
    public void setName(String name)
    {
        this.name = name;
    }

    public void setDate_of_birth(DateTime date_of_birth)
    {
        this.date_of_birth = date_of_birth;
    }

    public void setDocument(String document)
    {
        this.document = document;
    }

    public void setEmail(String email)
    {
        this.email = email;
    }

    public void setPhone(String phone)
    {
        this.phone = phone;
    }

    public void setLogin(String login)
    {
        this.login = login;
    }
    public void setPasswd(String passwd)
    {
        this.passwd = passwd;
    }
    public String getName()
    {
        return this.name;
    }

    public DateTime getDate_of_birth()
    {        
        return this.date_of_birth;
    }

    public String getDocument()
    {
        return this.document;
    }

    public String getEmail()
    {
        return this.email;
    }

    public String getPhone()
    {
        return this.phone;
    }
    public String getLogin()
    {
        return this.login;
    }
    public String getPasswd()
    {
        return this.passwd;
    }
    public Address getAddress(){
        return address;
    }


}