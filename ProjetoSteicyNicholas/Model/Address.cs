using System;
using Interfaces; 
using DAO;
using DTO;
using System.Collections.Generic;

namespace Model
{

    public class Address : IValidateDataObject, IDataController<AddressDTO, Address>
    {
        protected String street = "";
        protected String city = "";
        protected String state = "";
        protected String country = "";
        protected String posteCode = "";

        public Address(String street, String city, String state, String country, String posteCode)
        {
            this.street = street;
            this.city = city;
            this.state = state;
            this.country = country;
            this.posteCode = posteCode;
        }

        public string getStreet()
        {
            return street;
        }
        public string getCity()
        {
            return city;
        }
        public string getState()
        {
            return state;
        }
        public string getCountry()
        {
            return country;
        }
        public string getPostalCode()
        {
            return posteCode;
        }

        public void setStreet(string street)
        {
            this.street = street;
        }
        public void setCity(string city)
        {
            this.city = city;
        }
        public void setState(string state)
        {
            this.state = state;
        }
        public void setCountry(string country)
        {
            this.country = country;
        }
        public void setPosteCode(string posteCode)
        {
            this.posteCode = posteCode;
        }

        public Boolean validateObject(Address obj)
        {
            if (obj.city == null)
                return false;
            if (obj.state == null)
                return false;
            if (obj.country == null)
                return false;
            if (obj.posteCode == null)
                return false;
            if (obj.street == null)
                return false;
            return true;

        }
        public static Address convertDTOToModel(AddressDTO obj)
    {
        return new Address(obj.street, obj.city, obj.state, obj.country, obj.posteCode);
    }


    public Boolean validateObject()
    {
        return true;
    }

    public void delete(AddressDTO obj)
    {

    }

    public int save()
    {
        var id = 0;

        using(var context = new DAOContext())
        {
            var address = new DAO.Address{
                street = this.street,
                city = this.city,
                state = this.state,
                country = this.country,
                posteCode = this.posteCode
            };

            context.Address.Add(address);

            context.SaveChanges();

            id = address.id;

        }
         return id;
    }

    public void update(AddressDTO obj)
    {

    }

    public AddressDTO findById(int id)
    {

        return new AddressDTO();
    }

    public List<AddressDTO> getAll()
    {        
        return this.addressDTO;      
    }

   
    public AddressDTO convertModelToDTO()
    {
        var addressDTO = new AddressDTO();

        addressDTO.street = this.street;

        addressDTO.state = this.state;

        addressDTO.city = this.city;

        addressDTO.country = this.country;

        addressDTO.posteCode = this.posteCode;

        return addressDTO;
    }
    }
}