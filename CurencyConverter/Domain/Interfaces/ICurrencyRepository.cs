using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace Domain.Interfaces
{
    public interface ICurrencyRepository : IRepository<Currency>
    {
        Currency GetByAbreviation(string abreviation);
    }
}
