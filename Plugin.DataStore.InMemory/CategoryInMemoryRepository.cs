using CoreBusiness;
using UseCases.DataStorePluginInterfaces;

namespace Plugin.DataStore.InMemory;

public class CategoryInMemoryRepository : ICategoryRepository
{
    private List<Category> categories;

    public CategoryInMemoryRepository()
    {
        // Add some default categories
        categories = new()
        {
            new Category { CategoryId = 1, Name = "Beverage", Description = "Beverage" },
            new Category { CategoryId = 2, Name = "Bakery", Description = "Bakery" },
            new Category { CategoryId = 3, Name = "Meat", Description = "Meat" },
        };
    }

    public void AddCategory(Category category)
    {
        if (categories.Any(c => c.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase)))
            return;

        if (categories != null && categories.Count() > 0)
        {
            var maxId = categories.Max(c => c.CategoryId);
            category.CategoryId = maxId + 1;
        }
        else
        {
            category.CategoryId = 1;
        }
        categories.Add(category);
    }

    public IEnumerable<Category> GetCategories()
    {
        return categories;
    }

    public Category GetCategoryById(int categoryId)
    {
        return categories.FirstOrDefault(c => c.CategoryId == categoryId);
    }

    public void UpdateCategory(Category category)
    {
        var categoryToUpdate = GetCategoryById(category.CategoryId);
        if (categoryToUpdate != null)
        {
            categoryToUpdate.Name = category.Name;
            categoryToUpdate.Description = category.Description;
        }
    }

    public void DeleteCategory(int categoryId)
    {
        var categoryToDelete = GetCategoryById(categoryId);
        if (categoryToDelete != null)
            categories.Remove(categoryToDelete);
    }
}
