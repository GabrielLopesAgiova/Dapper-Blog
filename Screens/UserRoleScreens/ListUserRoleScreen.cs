using Blog.Repositories;

namespace Blog.Screens.UserRoleScreens;

public class ListUserRoleScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Lista de usuários");
        Console.WriteLine("--------------");
        List();

        Console.ReadKey();
        MenuUserRoleScreen.Load();
    }

    public static void List()
    {
        var repository = new UserRepository();

        try
        {
            var usersWithRoles = repository.GetWithRoles();

            if (usersWithRoles.Count() == 0)
            {
                Console.WriteLine("Não há usuários cadastrados no sistema!");
                return;
            }

            foreach (var user in usersWithRoles)
            {
                Console.WriteLine($"{user.Name} ({user.Slug})");
                if (user.Roles.Count > 0)
                {
                    foreach (var role in user.Roles)
                    {
                        Console.WriteLine($"- {role.Name} ({role.Slug})");
                    }
                }
                else
                {
                    Console.WriteLine("- usuário sem perfil associado");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível os vínculos perfil/usuário");
            Console.WriteLine(ex.Message);
        }
    }
}
