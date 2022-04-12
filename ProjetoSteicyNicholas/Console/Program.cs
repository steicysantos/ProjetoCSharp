using DAO;

using (var context = new Context())
{

    context.Database.EnsureCreated();

    var address = new Address
   {
        street = "Rua Itajuba",
        city = "Curitiba",
        state = "Paraná",
        country = "Brasil",
        posteCode = "81130040"
    };
    context.Address.Add(address);
    
    context.Client.Add(new Client
    {
        name = "Carlos",
        age = 17,
        passwd = "carcos",
        email = "carcos@gmail.com",
        phone = "41999999999",
        login = "carcos17",
        address = address
    });

    context.Owner.Add(new Owner
    {
        name = "Nathan",
        age = 19,
        passwd = "nathan",
        email = "nathan@gmail.com",
        phone = "41999999999",
        login = "nathan17",
        address = address
    });

    context.Product.Add(new Product
    {
        name = "celular",
        unitPrice = 1599.99,
        barCode = "123123123"
    });

    // Saves changes
    context.SaveChanges();
}