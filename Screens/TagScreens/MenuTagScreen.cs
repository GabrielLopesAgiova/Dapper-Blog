namespace Blog.Screens.TagScreens;

public static class MenuTagScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Gestão de tags");
        Console.WriteLine("--------------");
        Console.WriteLine("O que deseja fazer");
        Console.WriteLine();
        Console.WriteLine("1 - Listar tags");
        Console.WriteLine("2 - Cadastrar tags");
        Console.WriteLine("3 - Atualizar tags");
        Console.WriteLine("4 - Excluir tags");
        Console.WriteLine("5 - Voltar ao menu principal");
        Console.WriteLine();

        var option = short.Parse(Console.ReadLine()!);

        switch (option)
        {
            case 1: ListTagsScreen.Load(); break;
            case 2: CrateTagScreen.Load(); break;
            case 3: UpdateTagScreen.Load(); break;
            case 4: DeleteTagScreen.Load(); break;
            case 5: MainScreen.Load(); break;
            default: Load(); break;
        }
    }
}
