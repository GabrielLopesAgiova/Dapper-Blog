namespace Blog.Screens.RoleScreens;

public class ListRoleScreen
{
    public static void Load ()
    {
        Console.Clear();
        Console.WriteLine("Lista de perfis");
        Console.WriteLine("--------------");
        List();

        Console.ReadKey();
        MenuRoleScreen.Load();
    }

    public static void List()
    {
        var repository = new RoleRepository();
        
        try
        {
            var roles = repository.Get();
            if (roles.Count() == 0)
            {
                Console.WriteLine("Não há perfis cadastrados!");
                return;
            }
            foreach (var role in roles)
            {
                Console.WriteLine($"{role.Name} ({role.Slug})");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível listar os perfis");
            Console.WriteLine(ex.Message);
        }
    }
}
