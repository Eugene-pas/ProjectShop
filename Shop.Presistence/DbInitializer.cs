using Shop.Domain.Entities;

namespace Shop.Presistence
{
    public class DbInitializer
    {
        // клас що підключається до ДБ
        public static void Intialize(DataBaseContext context)
        {              
            context.Database.EnsureCreated();
        }
    }
}
