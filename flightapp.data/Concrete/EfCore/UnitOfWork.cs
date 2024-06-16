using System.Threading.Tasks;
using flightapp.data.Abstract;

namespace flightapp.data.Concrete.EfCore
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FlightContext _context;
        public UnitOfWork(FlightContext context)
        {
            _context = context;
        }
        
        private EfCoreCartRepository _cartRepository;
        private EfCoreCategoryRepository _categoryRepository;
        private EfCoreBookRepository _bookRepository;
        private EfCoreFlightRepository _flightRepository;

        public ICartRepository Carts => 
            _cartRepository = _cartRepository ?? new EfCoreCartRepository(_context);

        public ICategoryRepository Categories => 
            _categoryRepository = _categoryRepository ?? new EfCoreCategoryRepository(_context);             

        public IBookRepository Books => 
            _bookRepository = _bookRepository ?? new EfCoreBookRepository(_context);

        public IFlightRepository Flights => 
            _flightRepository = _flightRepository ?? new EfCoreFlightRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}