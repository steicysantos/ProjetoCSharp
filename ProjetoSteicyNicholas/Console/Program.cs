using DAO;

using (var context = new DaoContext())
{

    context.Database.EnsureCreated();

    var address = new Address
   {
        street = "Rua Itajuba",
        city = "Curitiba",
        state = "Paraná",
        country = "Brasil",
        poste_code = "81130040"
    };
    context.address.Add(address);
    
    context.clients.Add(new Client
    {
        name = "alison",
        age = 19,
        password = "alison",
        email = "alison@yahoo.com",
        phone = "41999999999",
        login = "alison17",
        address = address
    });

    context.owners.Add(new Owner
    {
        name = "alison",
        age = 19,
        password = "alison",
        email = "alison@yahoo.com",
        phone = "41999999999",
        login = "alison17",
        address = address
    });

    context.products.Add(new Product
    {
        name = "abacaxi",
        unit_price = 13.20,
        bar_code = "1234567890"
    });

    // Saves changes
    context.SaveChanges();
}