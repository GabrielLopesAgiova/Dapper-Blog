namespace Blog.Screens.CategoryScreens;

public class DeleteCategoryScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Exclusão de categoria");
        Console.WriteLine("--------------");
        ListCategoryScreen.List();
        Console.WriteLine();
        Console.WriteLine("Selecione uma categoria para excluir");
        Console.WriteLine("ATENÇÃO!!! Escolha a categoria com o nome entre parênteses");
        Console.WriteLine();

        var slug = Console.ReadLine()!;

        Delete(slug);

        Console.ReadKey();
        MenuCategoryScreen.Load();
    }

    private static void Delete(string slug)
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
            repository.Delete(id);

            Console.WriteLine("Categoria excluída com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível excluir a categoria.");
            Console.WriteLine(ex.Message);
        }
    }
}
