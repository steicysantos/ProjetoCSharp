using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;

namespace Model;

public class Person : IValidateDataObject, IDataController<PersonDTO, Person>
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

    public static Person convertDTOToModel(PersonDTO obj)
    {
        return new Person(obj.name, obj.date_of_birth, obj.document, obj.email, obj.phone, obj.login);
    }


    public Boolean validateObject()
    {
        return true;
    }

    public void delete(PersonDTO obj)
    {

    }

    public int save()
    {
        var id = 0;

        using(var context = new DAOContext())
        {
            var person = new DAO.Person{
                name = this.name,
                date_of_birth = this.date_of_birth,
                document = this.document,
                email = this.email,
                phone = this.phone,
                login = this.login
            };

            context.Person.Add(person);

            context.SaveChanges();

            id = person.id;

        }
         return id;
    }

    public void update(PersonDTO obj)
    {

    }

    public PersonDTO findById(int id)
    {

        return new PersonDTO();
    }

    public List<PersonDTO> getAll()
    {        
        return this.PersonDTO;      
    }

   
    public PersonDTO convertModelToDTO()
    {
        var PersonDTO = new PersonDTO();

        PersonDTO.name = this.name;
        
        PersonDTO.date_of_birth = this.date_of_birth;
        
        PersonDTO.document = this.document;
        
        PersonDTO.email = this.email;
        
        PersonDTO.phone = this.phone;
        
        PersonDTO.login = this.login;

        return PersonDTO;
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