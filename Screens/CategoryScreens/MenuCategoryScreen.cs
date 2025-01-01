namespace Blog.Screens.CategoryScreens;

public class MenuCategoryScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Gestão de categoria");
        Console.WriteLine("--------------");
        Console.WriteLine("O que deseja fazer");
        Console.WriteLine();
        Console.WriteLine("1 - Listar categorias");
        Console.WriteLine("2 - Cadastrar categoria");
        Console.WriteLine("3 - Atualizar categoria");
        Console.WriteLine("4 - Excluir categoria");
        Console.WriteLine("5 - Voltar ao menu principal");
        Console.WriteLine();

        var option = short.Parse(Console.ReadLine()!);

        switch (option)
        {
            case 1: ListCategoryScreen.Load(); break;
            case 2: CreateCategoryScreen.Load(); break;
            case 3: UpdateCategoryScreen.Load(); break;
            case 4: DeleteCategoryScreen.Load(); break;
            case 5: MainScreen.Load(); break;
            default: Load(); break;
        }
    }
}
