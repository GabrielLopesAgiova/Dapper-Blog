using Blog.Repositories;

namespace Blog.Screens.RoleScreens;

public class DeleteRoleScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Exclusão de perfil");
        Console.WriteLine("--------------");
        ListRoleScreen.List();
        Console.WriteLine();
        Console.WriteLine("Selecione um perfil para excluir");
        Console.WriteLine("ATENÇÃO!!! Escolha o perfil com o nome entre parênteses");
        Console.WriteLine();

        var slug = Console.ReadLine()!;

        Delete(slug);

        Console.ReadKey();
        MenuRoleScreen.Load();
    }

    private static void Delete(string slug)
    {
        var repository = new RoleRepository();
        
        try
        {
            var selectedRole = repository.Get(slug);
            if (selectedRole.Count() == 0)
            {
                Console.WriteLine("Pefil não encontrado");
                Console.ReadKey();
                MenuRoleScreen.Load();
            }

            var id = selectedRole.First().Id;
            repository.Delete(id);

            Console.WriteLine("Perfil excluído com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível excluir o perfil.");
            Console.WriteLine(ex.Message);
        }
    }
}
