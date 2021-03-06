﻿using ReyukoProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReyukoProject.Repository
{
    public interface IOrderRepository
    {
        /// <summary>
        /// Returns all orders. 
        /// </summary>
        Task<IEnumerable<Order>> GetAsync();

        /// <summary>
        /// Returns the order with the given id.
        /// </summary>
        Task<Order> GetAsync(Guid orderId);

        /// <summary>
        /// Returns all order with a data field matching the start of the given string. 
        /// </summary>
        Task<IEnumerable<Order>> GetAsync(string search);

        /// <summary>
        /// Returns all the given currency's orders. 
        /// </summary>
        Task<IEnumerable<Order>> GetForCurrencyAsync(Guid currencyId);

        /// <summary>
        /// Returns all the given customer's orders. 
        /// </summary>
        Task<IEnumerable<Order>> GetForCustomerAsync(Guid customerId);

        /// <summary>
        /// Adds a new order if the order does not exist, updates the 
        /// existing order otherwise.
        /// </summary>
        Task<Order> UpsertAsync(Order order);

        /// <summary>
        /// Deletes an order.
        /// </summary>
        Task DeleteAsync(Guid orderId);

    }
}
