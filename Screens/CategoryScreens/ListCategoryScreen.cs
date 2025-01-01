namespace Blog.Screens.CategoryScreens;

public class ListCategoryScreen
{
    public static void Load ()
    {
        Console.Clear();
        Console.WriteLine("Lista de categorias");
        Console.WriteLine("--------------");
        List();

        Console.ReadKey();
        MenuCategoryScreen.Load();
    }

    public static void List()
    {
        var repository = new CategoryRepository();
        
        try
        {
            var categories = repository.Get();
            if (categories.Count() == 0)
            {
                Console.WriteLine("Não há categorias cadastradas!");
                return;
            }
            foreach (var category in categories)
            {
                Console.WriteLine($"{category.Name} ({category.Slug})");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível listar as categorias");
            Console.WriteLine(ex.Message);
        }
    }
}
