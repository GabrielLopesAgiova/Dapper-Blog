using Blog.Models;

namespace Blog.Screens.RoleScreens;

public class UpdateRoleScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Atualização de perfil");
        Console.WriteLine("--------------");
        ListRoleScreen.List();
        Console.WriteLine();
        Console.WriteLine("Selecione o perfil para atualizar");
        Console.WriteLine("ATENÇÃO!!! Escolha o perfil com o nome entre parênteses");
        Console.WriteLine();

        var slug = Console.ReadLine()!;

        Update(slug);

        Console.ReadKey();
        MenuRoleScreen.Load();
    }

    private static void Update(string slug)
    {
        var repository = new RoleRepository();
        
        try
        {
            var selectedRole = repository.Get(slug);
            if (selectedRole.Count() == 0)
            {
                Console.WriteLine("Perfil não encontrado");
                Console.ReadKey();
                MenuRoleScreen.Load();
            }

            var id = selectedRole.First().Id;
            Console.Write("Digite o novo nome do perfil: ");
            var newName = Console.ReadLine();

            Console.Write("Digite o novo slug do perfil: ");
            var newSlug = Console.ReadLine();

            repository.Update(new Role()
            {
                Id = id,
                Name = newName!,
                Slug = newSlug!
            });

            Console.WriteLine("Perfil atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível atualizar o perfil.");
            Console.WriteLine(ex.Message);
        }
    }
}
