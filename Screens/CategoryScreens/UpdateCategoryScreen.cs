using Blog.Models;

namespace Blog.Screens.CategoryScreens;

public class UpdateCategoryScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Atualização de categoria");
        Console.WriteLine("--------------");
        ListCategoryScreen.List();
        Console.WriteLine();
        Console.WriteLine("Selecione a categoria para atualizar");
        Console.WriteLine("ATENÇÃO!!! Escolha a categoria com o nome entre parênteses");
        Console.WriteLine();

        var slug = Console.ReadLine()!;

        Update(slug);

        Console.ReadKey();
        MenuCategoryScreen.Load();
    }

    private static void Update(string slug)
    {
        var repository = new CategoryRepository();
        
        try
        {
            var selectedCategory = repository.Get(slug);
            if (selectedCategory.Count() == 0)
            {
                Console.WriteLine("Categoria não encontrada");
                Console.ReadKey();
                MenuCategoryScreen.Load();
            }

            var id = selectedCategory.First().Id;
            Console.Write("Digite o novo nome da categoria: ");
            var newName = Console.ReadLine();

            Console.Write("Digite o novo slug da categoria: ");
            var newSlug = Console.ReadLine();

            repository.Update(new Category()
            {
                Id = id,
                Name = newName!,
                Slug = newSlug!
            });

            Console.WriteLine("Categoria atualizada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível atualizar a categoria.");
            Console.WriteLine(ex.Message);
        }
    }
}
