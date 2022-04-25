using DAO;

using (var context = new DAOContext())
{

    context.Database.EnsureCreated();

}