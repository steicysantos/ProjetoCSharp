using Microsoft.AspNetCore.Mvc;
using Model;
using DTO;
namespace Controller.Controllers;


[ApiController]
[Route("client")]
public class ClientController : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public object registerClient([FromBody] ClientDTO client)
    {
        var cliente=Model.Client.convertDTOToModel(client);
        var id=cliente.save();
        return new{
            name=client.name,
            date_of_birth=client.date_of_birth,
            document=client.document,
            email=client.email,
            phone=client.name,
            login=client.login,
            passwd=client.passwd,
            address=client.address,
            id=id
        };
    }
    [HttpGet(Name = "getInformations")]
    public void getInformations()
    {
    }
}