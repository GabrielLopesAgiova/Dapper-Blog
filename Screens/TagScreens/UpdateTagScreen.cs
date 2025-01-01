using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public static class UpdateTagScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Atualização de tag");
        Console.WriteLine("--------------");
        ListTagsScreen.List();
        Console.WriteLine();
        Console.WriteLine("Selecione a tag para atualizar");
        Console.WriteLine("ATENÇÃO!!! Escolha a tag com o nome entre parênteses");
        Console.WriteLine();

        var slug = Console.ReadLine()!;

        Update(slug);

        Console.ReadKey();
        MenuTagScreen.Load();
    }

    private static void Update(string slug)
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
            Console.Write("Digite o novo nome da tag: ");
            var newName = Console.ReadLine();

            Console.Write("Digite o novo slug da tag: ");
            var newSlug = Console.ReadLine();

            repository.Update(new Tag()
            {
                Id = id,
                Name = newName!,
                Slug = newSlug!
            });

            Console.WriteLine("Tag atualizada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível atualizar a tag.");
            Console.WriteLine(ex.Message);
        }
    }
}
