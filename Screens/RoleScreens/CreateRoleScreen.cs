using Blog.Models;

namespace Blog.Screens.RoleScreens;

public class CreateRoleScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Novo pefil");
        Console.WriteLine("--------------");

        Console.Write("Digite o nome do perfil: ");
        var name = Console.ReadLine()!;

        Console.Write("Digite o slug do perfil: ");
        var slug = Console.ReadLine()!;

        Create(
            new Role()
            {
                Name = name,
                Slug = slug,
            }
        );
        Console.ReadKey();
        MenuRoleScreen.Load();
    }

    private static void Create(Role role)
    {
        var repository = new RoleRepository();

        try
        {
            repository.Create(role);
            Console.WriteLine("Perfil criado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível salvar o perfil");
            Console.WriteLine(ex.Message);
        }
    }
}
