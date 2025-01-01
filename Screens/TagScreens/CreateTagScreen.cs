using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.TagScreens;

public static class CrateTagScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Nova tag");
        Console.WriteLine("--------------");

        Console.Write("Digite o nome da tag: ");
        var name = Console.ReadLine()!;

        Console.Write("Digite o slug da tag: ");
        var slug = Console.ReadLine()!;
        
        Create(
            new Tag() {
                Name = name,
                Slug = slug,
            }
        );
        Console.ReadKey();
        MenuTagScreen.Load();
    }

    private static void Create(Tag tag)
    {
        var repository = new TagRepository();
        
        try 
        {
            repository.Create(tag);
            Console.WriteLine("Tag criada com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível salvar a tag");
            Console.WriteLine(ex.Message);
        }
    }
}