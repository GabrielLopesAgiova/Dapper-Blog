using Blog.Models;

namespace Blog.Repositories;

public class TagRepository : Repository<Tag>
{
    public IEnumerable<Tag> Get(string slug)
    {
        var tags = Get();  
        var selectedTag = tags.Where(x => x.Slug == slug);
        return selectedTag;
    }
}
