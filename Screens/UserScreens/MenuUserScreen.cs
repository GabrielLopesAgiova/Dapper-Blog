namespace Blog.Screens.UserScreens;

public class MenuUserScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Gestão de usuário");
        Console.WriteLine("--------------");
        Console.WriteLine("O que deseja fazer");
        Console.WriteLine();
        Console.WriteLine("1 - Listar usuários");
        Console.WriteLine("2 - Cadastrar usuário");
        Console.WriteLine("3 - Atualizar usuário");
        Console.WriteLine("4 - Excluir usuário");
        Console.WriteLine("5 - Voltar ao menu principal");
        Console.WriteLine();

        var option = short.Parse(Console.ReadLine()!);

        switch (option)
        {
            case 1: ListUserScreen.Load(); break;
            case 2: CreateUserScreen.Load(); break;
            case 3: UpdateUserScreen.Load(); break;
            case 4: DeleteUserScreen.Load(); break;
            case 5: MainScreen.Load(); break;
            default: Load(); break;
        }
    }
}
