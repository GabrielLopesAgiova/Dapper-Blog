using Blog.Repositories;
using Blog.Screens.CategoryScreens;
using Blog.Screens.RoleScreens;
using Blog.Screens.UserScreens;

namespace Blog.Screens.UserRoleScreens;

public class CreateUserRoleScreen
{
    public static void Load()
    {
        Console.Clear();
        Console.WriteLine("Vincular perfil/usuário");
        Console.WriteLine("--------------");

        ListUserScreen.List();

        Console.Write("Digite o slug do usuário: ");
        var userSlug = Console.ReadLine()!;

        Console.Clear();
        Console.WriteLine("Vincular perfil/usuário");
        Console.WriteLine("--------------");

        ListRoleScreen.List();

        Console.Write("Digite o slug do perfil: ");
        var roleSlug = Console.ReadLine()!;

        Create(userSlug, roleSlug);
        Console.ReadKey();
        MenuUserRoleScreen.Load();
    }

    private static void Create(string userSlug, string roleSlug)
    {
        var userRepository = new UserRepository();
        var roleRepository = new RoleRepository();

        try
        {
            var user = userRepository.Get(userSlug).FirstOrDefault();
            var role = roleRepository.Get(roleSlug).FirstOrDefault();

            if (user == null || role == null)
            {
                Console.WriteLine("Perfil/usuário não encontrado");
                Console.ReadKey();
                MenuUserRoleScreen.Load();
            }

            if (userRepository.UserRoleExists(user!.Id, role!.Id))
            {
                Console.WriteLine("O vínculo entre o perfil e o usuário já existe.");
                Console.ReadKey();
                MenuUserRoleScreen.Load();
            }

            userRepository.CreateRole(user.Id, role.Id);
            Console.WriteLine("vínculo perfil/usuário criado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Não foi possível vincular perfil/usuário");
            Console.WriteLine(ex.Message);
        }
    }
}
