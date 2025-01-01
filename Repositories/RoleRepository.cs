using Blog.Models;
using Blog.Repositories;

namespace Blog;

public class RoleRepository : Repository<Role>
{
    public IEnumerable<Role> Get(string slug)
    {
        var roles = Get();  
        var selectedRole = roles.Where(x => x.Slug == slug);
        return selectedRole;
    }
}
