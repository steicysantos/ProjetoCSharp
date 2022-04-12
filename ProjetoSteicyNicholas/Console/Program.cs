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
        name = "Carlos",
        age = 17,
        password = "carcos",
        email = "carcos@gmail.com",
        phone = "41999999999",
        login = "carcos17",
        address = address
    });

    context.owners.Add(new Owner
    {
        name = "Nathan",
        age = 19,
        password = "nathan",
        email = "nathan@gmail.com",
        phone = "41999999999",
        login = "nathan17",
        address = address
    });

    context.products.Add(new Product
    {
        name = "celular",
        unit_price = 1599.99,
        bar_code = "123123123"
    });

    // Saves changes
    context.SaveChanges();
}