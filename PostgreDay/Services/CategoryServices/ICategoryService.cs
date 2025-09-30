using PostgreDay.Dtos.CategoryDtos;

namespace PostgreDay.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(int id);
        Task<GetCategoryByIdDto> GetCategoryByIdAsync(int id);
    }
}
