using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;

namespace Model;

public class Person
{
    private String name;

    private DateTime date_of_birth;
    private String document;

    private String email;

    private String phone;
    private String login;

    public Person(String name,DateTime date_of_birth, String document,String email , String phone,String login){
        this.name =  name;

        this.date_of_birth = date_of_birth;

        this.document = document;

        this.email = email;

        this.phone = phone;

        this.login = login;
    }

    public void setName(String name)
    {
        this.name = name;
    }

    public void setDate_of_birth(String date_of_birth)
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

    public String getName()
    {
        return this.name;
    }

    public String getDate_of_birth()
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


}