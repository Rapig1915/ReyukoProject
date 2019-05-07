using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReyukoProject.Repository
{
    public interface IReyukoRepository
    {
        /// <summary>
        /// Returns the currency repository.
        /// </summary>
        ICurrencyRepository Currency { get; }

        /// <summary>
        /// Returns the customers repository.
        /// </summary>
        ICustomerRepository Customers { get; }

        /// <summary>
        /// Returns the orders repository.
        /// </summary>
        IOrderRepository Orders { get; }

        /// <summary>
        /// Returns the products repository.
        /// </summary>
        IProductRepository Products { get; }
    }
}
