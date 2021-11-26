using CoreBusiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.CategoriesUseCases
{
    public class ViewCategoriesUseCase : IViewCategoriesUseCase
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
