using Microsoft.AspNetCore.Mvc;
using Model;
using DTO;
namespace Controller.Controllers;


[ApiController]
[Route("owner")]
public class OwnerController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public object registerOwner(OwnerDTO owner)
    {
        var ownerr=Model.Owner.convertDTOToModel(owner);
        var id=ownerr.save();
        return new{
            name=owner.name,
            date_of_birth=owner.date_of_birth,
            document=owner.document,
            email=owner.email,
            phone=owner.name,
            login=owner.login,
            passwd=owner.passwd,
            address=owner.address,
            id=id
        };
    }
    [HttpGet]
    [Route("get/{document}")]
    public object getInformations(string document)
    {
        var client=Model.Owner.find(document);
        return client;
    }
}