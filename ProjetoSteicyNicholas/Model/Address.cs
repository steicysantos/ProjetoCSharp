using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model
{

    public class Address : IValidateDataObject<Address>
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
    }
}