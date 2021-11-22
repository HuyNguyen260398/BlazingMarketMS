using CoreBusiness;

namespace UseCases
{
    public class ViewCategoriesUseCase
    {
        private readonly ICategoryRepository categoryRepo;

        public ViewCategoriesUseCase(ICategoryRepository categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public IEnumerable<Category> Execute()
        {
            return categoryRepo.GetCategories();
        }
    }
}
