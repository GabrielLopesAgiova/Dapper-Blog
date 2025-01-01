using Dapper.Contrib.Extensions;

namespace Blog.Models;

[Table("[Tag]")]
public class Tag
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
}
