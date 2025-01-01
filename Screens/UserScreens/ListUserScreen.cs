using Blog.Repositories;

namespace Blog.Screens.UserScreens;

public class ListUserScreen
{
    public static void Load ()
    {
        Console.Clear();
        Console.WriteLine("Lista de usuários");
        Console.WriteLine("--------------");
        List();

        Console.ReadKey();
        MenuUserScreen.Load();
    }

    public static void List()
    {
        var repository = new UserRepository();
        
        try
        {
            var users = repository.Get();

            if (users.Count() == 0)
            {
                Console.WriteLine("Não há usuários cadastrados!");
                return;
            }
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Name} ({user.Slug})");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível listar os usuários");
            Console.WriteLine(ex.Message);
        }
    }
}
