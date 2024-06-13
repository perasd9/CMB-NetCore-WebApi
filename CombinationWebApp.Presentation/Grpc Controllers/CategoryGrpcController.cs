using CombinationWebApp.Protos;
using Grpc.Core;

namespace CombinationWebApp.Presentation.Grpc_Controllers
{
    public class CategoryGrpcController : CategoryService.CategoryServiceBase
    {
        private readonly Application.Services.CategoryService _categoryService;

        public CategoryGrpcController(Application.Services.CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public override Task<CategoryList> GetAll(Empty request, ServerCallContext context)
        {
            return base.GetAll(request, context);
        }

        public override Task<CategoryList> GetBySearch(CategorySearchRequest request, ServerCallContext context)
        {
            return base.GetBySearch(request, context);
        }

        public override Task<CategoryReply> Save(CategoryRequest request, ServerCallContext context)
        {
            return base.Save(request, context);
        }

        public override Task<CategoryReply> Update(CategoryRequest request, ServerCallContext context)
        {
            return base.Update(request, context);
        }

        public override Task<Empty> Remove(CategoryRemoveRequest request, ServerCallContext context)
        {
            return base.Remove(request, context);
        }
    }
}
