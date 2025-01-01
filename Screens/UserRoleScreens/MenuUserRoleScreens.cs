namespace Blog.Screens.UserRoleScreens;

public class MenuUserRoleScreen
{
    public static void Load ()
    {
        Console.Clear();
        Console.WriteLine("Vincular perfil/usuário");
        Console.WriteLine("--------------");
        Console.WriteLine("O que deseja fazer");
        Console.WriteLine();
        Console.WriteLine("1 - Listar vínculos perfil/usuário");
        Console.WriteLine("2 - Vincular perfil/usuário");
        Console.WriteLine("3 - Remover vínculo perfil/usuário");
        Console.WriteLine("4 - Voltar ao menu principal");
        Console.WriteLine();

        var option = short.Parse(Console.ReadLine()!);

        switch (option)
        {
            case 1: ListUserRoleScreen.Load(); break;
            case 2: CreateUserRoleScreen.Load(); break;
            case 3: DeleteUserRoleScreen.Load(); break;
            case 4: MainScreen.Load(); break;
            default: Load(); break;
        }
    }
}
