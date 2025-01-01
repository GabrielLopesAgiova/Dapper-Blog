using Blog.Repositories;

namespace Blog.Screens.UserScreens;

public class DeleteUserScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Exclusão de usuário");
        Console.WriteLine("--------------");
        ListUserScreen.List();
        Console.WriteLine();
        Console.WriteLine("Selecione a tag para excluir");
        Console.WriteLine("ATENÇÃO!!! Escolha a tag com o nome entre parênteses");
        Console.WriteLine();

        var slug = Console.ReadLine()!;

        Delete(slug);

        Console.ReadKey();
        MenuUserScreen.Load();
    }

    private static void Delete(string slug)
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
            repository.Delete(id);

            Console.WriteLine("Usuário excluído com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível excluir o usuário.");
            Console.WriteLine(ex.Message);
        }
    }
}
