using System.Collections.Generic;
using System.Threading.Tasks;
using flightapp.entity;

namespace flightapp.business.Abstract
{
    public interface ICategoryService: IValidator<Category>
    {
        Task<Category> GetById(int id);

        Category GetByIdWithFlights(int categoryId);

        Task<List<Category>> GetAll();

        void Create(Category entity);
        Task<Category> CreateAsync(Category entity);
        void Update(Category entity);
        void Delete(Category entity);
        void DeleteFromCategory(int flightId,int categoryId);
    }
}