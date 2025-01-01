using Dapper.Contrib.Extensions;

namespace Blog.Models;

[Table("[Role]")]
public class Role
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
}
