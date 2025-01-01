using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens;

public class UpdateUserScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Atualização de usuário");
        Console.WriteLine("--------------");
        ListUserScreen.List();
        Console.WriteLine();
        Console.WriteLine("Selecione o usuário para atualizar");
        Console.WriteLine("ATENÇÃO!!! Escolha o usuário com o nome entre parênteses");
        Console.WriteLine();

        var slug = Console.ReadLine()!;

        Update(slug);

        Console.ReadKey();
        MenuUserScreen.Load();
    }

    private static void Update(string slug)
    {
        var repository = new UserRepository();
        
        try
        {
            var selectedUser = repository.Get(slug);
            if (selectedUser.Count() == 0)
            {
                Console.WriteLine("Usuário não encontrado");
                Console.ReadKey();
                MenuUserScreen.Load();
            }

            var id = selectedUser.First().Id;
            Console.Write("Digite o novo nome do usuário: ");
            var newName = Console.ReadLine();

            Console.Write("Digite o novo email do usuário: ");
            var newEmail = Console.ReadLine()!;

            Console.Write("Digite a nova senha do usuário: ");
            var newPassword = Console.ReadLine()!;

            Console.Write("Digite a nova biografia do usuário: ");
            var newBio = Console.ReadLine()!;

            Console.Write("Digite a nova URL da foto do usuário: ");
            var newImage = Console.ReadLine()!;

            Console.Write("Digite o novo slug do usuário: ");
            var newSlug = Console.ReadLine();

            repository.Update(new User()
            {
                Id = id,
                Name = newName!,
                Email = newEmail!,
                PasswordHash = newPassword!,
                Bio = newBio!,
                Image = newImage!,
                Slug = newSlug!
            });

            Console.WriteLine("Usuário atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível atualizar a tag.");
            Console.WriteLine(ex.Message);
        }
    }
}
