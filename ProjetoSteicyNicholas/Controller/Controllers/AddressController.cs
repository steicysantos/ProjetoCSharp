using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("address")]

public class AddressController:ControllerBase{

    [HttpPost]
    [Route("register")]
    public object registerAddress([FromBody] AddressDTO address){

        var addres=Model.Address.convertDTOToModel(address);
        var id=addres.save();
        return new{
            rua=address.street,
            estado=address.state,
            cidade=address.city,
            pais=address.country,
            codigoPostal=address.postal_code,
            id=id
        };
    }    
}