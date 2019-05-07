using ReyukoProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReyukoProject.Repository
{
    public interface ICurrencyRepository
    {
        Task<IEnumerable<Currency>> GetAsync();

        /// <summary>
        /// Returns all currenys with a data field matching the start of the given string. 
        /// </summary>
        Task<IEnumerable<Currency>> GetAsync(string search);

        /// <summary>
        /// Returns the curreny with the given id. 
        /// </summary>
        Task<Currency> GetAsync(Guid id);

        /// <summary>
        /// Adds a new curreny if the curreny does not exist, updates the 
        /// existing curreny otherwise.
        /// </summary>
        Task<Currency> UpsertAsync(Currency curreny);


        /// <summary>
        /// Deletes a curreny.
        /// </summary>
        Task DeleteAsync(Guid curreny);
    }
}
