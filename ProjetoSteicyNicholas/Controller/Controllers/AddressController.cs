using System;
using Model;
using DTO;
using Microsoft.AspNetCore.Mvc;

namespace Contoller.Controller;
[ApiController]
[Route("address")]
public class AdressContoller : ControllerBase{
    [HttpPost]
    [Route("register")]
    public object registerAddress([FromBody] AddressDTO address){
        var addressModel = Model.Address.convertDTOToModel(address);
        var id = addressModel.save();
        return new{
            rua = address.street,
            estado = address.state,
            cidade = address.city,
            pais = address.country,
            codPostal = address.postal_code,
            id = id
        };
    }
}