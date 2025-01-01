using Blog.Models;

namespace Blog.Screens.CategoryScreens;

public class CreateCategoryScreen
{
     public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Nova categoria");
        Console.WriteLine("--------------");

        Console.Write("Digite o nome da categoria: ");
        var name = Console.ReadLine()!;

        Console.Write("Digite o slug da categoria: ");
        var slug = Console.ReadLine()!;

        Create(
            new Category()
            {
                Name = name,
                Slug = slug,
            }
        );
        Console.ReadKey();
        MenuCategoryScreen.Load();
    }

    private static void Create(Category category)
    {
        var repository = new CategoryRepository();

        try
        {
            repository.Create(category);
            Console.WriteLine("Categoria criada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível salvar a categoria");
            Console.WriteLine(ex.Message);
        }
    }
}
