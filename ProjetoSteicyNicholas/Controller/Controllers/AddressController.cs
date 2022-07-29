using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace Controller.Controllers;


[ApiController]
[Route("address")]

public class AddressController:ControllerBase{

    [Authorize]
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
    [Authorize]
    [HttpDelete]
    [Route("remove")]
    public void removeAddress(AddressDTO address){

        Model.Address.delete(address);
    }
    [Authorize]
    [HttpPut]
    [Route("update/{id}")]
    public void updateAddress([FromBody]AddressDTO address,int id){
        var iduser = Lib.GetIdFromRequest( Request.Headers["Authorization"].ToString());
        var addresss = new Model.Address();
        addresss.update(address,id,iduser);
    }    
}