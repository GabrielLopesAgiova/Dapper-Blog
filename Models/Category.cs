using Dapper.Contrib.Extensions;

namespace Blog.Models;

[Table("[Category]")]
public class Category
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    
    [Write(false)]
    public List<Post> Posts { get; set; }
}
