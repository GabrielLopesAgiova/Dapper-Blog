using Blog.Models;
using Blog.Repositories;

namespace Blog;

public class CategoryRepository : Repository<Category>
{
        public IEnumerable<Category> Get(string slug)
    {
        var categories = Get();  
        var selectedCategory = categories.Where(x => x.Slug == slug);
        return selectedCategory;
    }
}
