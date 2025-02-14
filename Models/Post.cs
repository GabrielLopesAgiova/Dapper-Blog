using Dapper.Contrib.Extensions;

namespace Blog.Models;

[Table("[Post]")]
public class Post
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public Guid AuthorId { get; set;}
    public string Title { get; set; }
    public string Summary { get; set; }
    public string Body { get; set; }
    public string Slug { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime LastUpdateDate { get; set; }
}
