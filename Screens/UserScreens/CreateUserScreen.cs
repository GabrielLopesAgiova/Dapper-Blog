using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens;

public class CreateUserScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Novo usuário");
        Console.WriteLine("--------------");

        Console.Write("Digite o nome do usuário: ");
        var name = Console.ReadLine()!;

        Console.Write("Digite o email do usuário: ");
        var email = Console.ReadLine()!;

        Console.Write("Digite a senha do usuário: ");
        var password = Console.ReadLine()!;

        Console.Write("Digite a biografia do usuário: ");
        var bio = Console.ReadLine()!;

        Console.Write("Digite a URL da foto do usuário: ");
        var image = Console.ReadLine()!;

        Console.Write("Digite o slug do usuário: ");
        var slug = Console.ReadLine()!;

        Create(
            new User()
            {
                Name = name,
                Email = email,
                PasswordHash = password,
                Bio = bio,
                Image = image,
                Slug = slug,
            }
        );
        Console.ReadKey();
        MenuUserScreen.Load();
    }

    private static void Create(User user)
    {
        var repository = new UserRepository();
        
        try
        {
            repository.Create(user);
            Console.WriteLine("Usuário criado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível salvar o usuário");
            Console.WriteLine(ex.Message);
        }
    }
}
