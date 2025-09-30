using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PostgreDay.Context;
using PostgreDay.Dtos.CategoryDtos;
using PostgreDay.Entities;

namespace PostgreDay.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly PostgreContext _context;
        public CategoryService(IMapper mapper, PostgreContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var value = _mapper.Map<Category>(createCategoryDto);
            await _context.Categories.AddAsync(value);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCategoryAsync(int id)
        {
            var values = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(values);
            await _context.SaveChangesAsync();
        }
        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await _context.Categories.ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }
        public async Task<GetCategoryByIdDto> GetCategoryByIdAsync(int id)
        {
            var value = await _context.Categories.FindAsync(id);
            return _mapper.Map<GetCategoryByIdDto>(value);
        }
        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            var values = _mapper.Map<Category>(updateCategoryDto);
            _context.Categories.Update(values);
            await _context.SaveChangesAsync();
        }
    }
}
