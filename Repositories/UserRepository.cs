using Blog.Models;
using Dapper;

namespace Blog.Repositories;

public class UserRepository : Repository<User>
{
    public bool UserRoleExists(Guid userId, Guid roleId)
    {
        var query = @"
        SELECT COUNT(*) 
        FROM [UserRole] 
        WHERE UserId = @UserId AND RoleId = @RoleId
        ";

        var result = Database.Connection.ExecuteScalar<int>(query, new { UserId = userId, RoleId = roleId });
        return result > 0;
    }
    public void CreateRole(Guid userId, Guid roleId)
    {
        var query = @"
            INSERT INTO 
                [UserRole] 
            VALUES(
                @UserId,
                @RoleId
            )
        ";

        Database.Connection.Execute(query, new
        {
            UserId = userId,
            RoleId = roleId
        });
    }
    public List<User> GetWithRoles()
    {
        var query = @"
            SELECT 
                [User].*,
                [Role].*
            FROM
                [User]
            LEFT JOIN [UserRole] ON [UserRole].[UserId] = [User].[Id]
            LEFT JOIN [Role] ON [UserRole].[RoleId] = [Role].[Id]
        ";

        var users = new List<User>();

        Database.Connection.Query<User, Role, User>(
            query,
            (user, role) =>
            {
                var usr = users.FirstOrDefault(x => x.Id == user.Id);
                if (usr == null)
                {
                    usr = user;
                    if (role is not null)
                    {
                        usr.Roles.Add(role);
                    }
                    users.Add(usr);
                }
                else
                    usr.Roles.Add(role);

                return usr;
            }, splitOn: "Id"
        );

        return users;
    }

    public IEnumerable<User> Get(string slug)
    {
        var users = Get();
        var selectedUser = users.Where(x => x.Slug == slug);
        return selectedUser;
    }
}
