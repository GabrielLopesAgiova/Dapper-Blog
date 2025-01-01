using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public static class DeleteTagScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Exclusão de tag");
        Console.WriteLine("--------------");
        ListTagsScreen.List();
        Console.WriteLine();
        Console.WriteLine("Selecione a tag para excluir");
        Console.WriteLine("ATENÇÃO!!! Escolha a tag com o nome entre parênteses");
        Console.WriteLine();

        var slug = Console.ReadLine()!;

        Delete(slug);

        Console.ReadKey();
        MenuTagScreen.Load();
    }

    private static void Delete(string slug)
    {
        var repository = new TagRepository();
        
        try
        {
            var selectedTag = repository.Get(slug);
            if (selectedTag.Count() == 0)
            {
                Console.WriteLine("Tag não encontrada");
                Console.ReadKey();
                MenuTagScreen.Load();
            }

            var id = selectedTag.First().Id;
            repository.Delete(id);

            Console.WriteLine("Tag excluída com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível excluir a tag.");
            Console.WriteLine(ex.Message);
        }
    }
}