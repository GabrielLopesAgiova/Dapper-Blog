using Blog.Screens;
using Blog.Screens.TagScreens;
using Microsoft.Data.SqlClient;

namespace Blog;
class Program
{
    private const string CONNECTION_STRING =
    @"Server=localhost,1433;
    Database=Blog;
    User ID=sa;
    Password=1q2w3e4r@#$;
    TrustServerCertificate=True
    ";
    static void Main(string[] args)
    {
        using(Database.Connection = new SqlConnection(CONNECTION_STRING)){
            MainScreen.Load();
        }
    }

    

    // public static void ReadUsers(SqlConnection connection)
    // {
    //     var repository = new Repository<User>(connection);
    //     var users = repository.Get();

    //     foreach (var user in users)
    //         Console.WriteLine(user.Name);
    // }

    // public static void ReadRoles(SqlConnection connection)
    // {
    //     var repository = new Repository<Role>(connection);
    //     var roles = repository.Get();

    //     foreach (var role in roles)
    //         Console.WriteLine(role.Name);
    // }

    // public static void ReadTags(SqlConnection connection)
    // {
    //     var repository = new Repository<Tag>(connection);
    //     var tags = repository.Get();

    //     foreach (var tag in tags)
    //         Console.WriteLine(tag.Name);
    // }

    // public static void ReadCategories(SqlConnection connection)
    // {
    //     var repository = new Repository<Category>(connection);
    //     var categories = repository.Get();

    //     foreach (var category in categories)
    //         Console.WriteLine(category.Name);
    // }

    // public static void ReadUsersWithRoles(SqlConnection connection)
    // {
    //     var repository = new UserRepository(connection);
    //     var items = repository.GetWithRoles();

    //     foreach (var item in items)
    //     {
    //         Console.WriteLine(item.Name);
    //         foreach (var role in item.Roles){
    //             Console.WriteLine(role.Name);
    //         }
    //     }
    // }
}