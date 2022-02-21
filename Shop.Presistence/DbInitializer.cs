using Shop.Domain.Entities;

namespace Shop.Presistence
{
    public class DbInitializer
    {
        public static void Intialize(DataBaseContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
