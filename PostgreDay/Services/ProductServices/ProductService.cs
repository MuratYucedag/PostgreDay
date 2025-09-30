using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PostgreDay.Context;
using PostgreDay.Dtos.ProductDtos;
using PostgreDay.Entities;

namespace PostgreDay.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly PostgreContext _context;
        public ProductService(IMapper mapper, PostgreContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            await _context.Products.AddAsync(values);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteProductAsync(int id)
        {
            var values = await _context.Products.FindAsync(id);
            _context.Products.Remove(values);
            await _context.SaveChangesAsync();
        }
        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _context.Products.ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }
        public async Task<GetProductByIdDto> GetProductByIdAsync(int id)
        {
            var value = await _context.Products.FindAsync(id);
            return _mapper.Map<GetProductByIdDto>(value);
        }
        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var value = _mapper.Map<Product>(updateProductDto);
            _context.Products.Update(value);
            await _context.SaveChangesAsync();
        }
    }
}