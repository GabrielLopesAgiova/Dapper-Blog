using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public static class ListTagsScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Lista de tags");
        Console.WriteLine("--------------");
        List();

        Console.ReadKey();
        MenuTagScreen.Load();
    }

    public static void List()
    {
        var repository = new TagRepository();
        
        try
        {
            var tags = repository.Get();
            if (tags.Count() == 0)
            {
                Console.WriteLine("Não há tags cadastradas!");
                return;
            }
            foreach (var tag in tags)
            {
                Console.WriteLine($"{tag.Name} ({tag.Slug})");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível listar as tags");
            Console.WriteLine(ex.Message);
        }
    }
}
