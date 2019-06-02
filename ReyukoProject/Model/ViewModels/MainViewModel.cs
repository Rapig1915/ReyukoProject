using Microsoft.Toolkit.Uwp.Helpers;
using ReyukoProject.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReyukoProject.Model.ViewModels
{
    public class MainViewModel : BindableBase
    {
        

        /// <summary>
        /// Load DBt
        /// </summary>
        public void LoadCurrencyModel()
        {
            const string sqlCmd = "select * from dbo.currency";
            try
            {
                if (App.m_DB.GetDB().State == System.Data.ConnectionState.Open)
                {
                    using (SqlCommand cmd = new SqlCommand(sqlCmd, App.m_DB.GetDB()))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Currency curreny = new Currency();
                                if (!reader.IsDBNull(1))
                                {
                                    curreny.Active_Check = reader.GetInt32(1);
                                }
                                if (!reader.IsDBNull(2))
                                {
                                    curreny.Name = reader.GetString(2);
                                }
                                if (!reader.IsDBNull(3))
                                {
                                    curreny.Code = reader.GetString(3);
                                }
                                if (!reader.IsDBNull(4))
                                {
                                    curreny.Symbol = reader.GetString(4);
                                }
                                if (!reader.IsDBNull(5))
                                {
                                    curreny.DateUpdate = reader.GetString(5);
                                }
                                if (!reader.IsDBNull(6))
                                {
                                    curreny.Exchange = reader.GetString(6);
                                }

                                Currencies.Add(new CurrencyViewModel(curreny));
                            }
                        }
                    }
                }
                return;
            }
            catch (Exception eSql)
            {
                Debug.WriteLine("Exception: " + eSql.Message);
            }
            return;
        }

        /// <summary>
        /// Creates a new MainViewModel.
        /// </summary>
        public MainViewModel()
        {
            LoadCurrencyModel();
            
            //Task.Run(GetCustomerGroupListAsync);
            //Task.Run(GetCurrencyGroupListAsync);
        }

    // For Currency View Model
        /// <summary>
        /// The collection of currency in the list
        /// </summary>
        public ObservableCollection<CurrencyViewModel> Currencies { get; }
            = new ObservableCollection<CurrencyViewModel>();

        private CurrencyViewModel _selectedCurrency;

        /// <summary>
        /// Gets or sets the selected currency, or null if no customer is selected. 
        /// </summary>
        public CurrencyViewModel SelectedCurrency
        {
            get => _selectedCurrency;
            set => Set(ref _selectedCurrency, value);
        }

    // For Customer View Model

        /// <summary>
        /// The collection of customers in the list. 
        /// </summary>
        public ObservableCollection<CustomerGroupViewModel> Customer_Group { get; }
            = new ObservableCollection<CustomerGroupViewModel>();

        private CustomerGroupViewModel _selectedCustomer;

        /// <summary>
        /// Gets or sets the selected customer, or null if no customer is selected. 
        /// </summary>
        public CustomerGroupViewModel SelectedCustomer
        {
            get => _selectedCustomer;
            set => Set(ref _selectedCustomer, value);
        }

        private bool _isLoading = false;

        /// <summary>
        /// Gets or sets a value indicating whether the Customers list is currently being updated. 
        /// </summary>
        public bool IsLoading
        {
            get => _isLoading;
            set => Set(ref _isLoading, value);
        }

        /// <summary>
        /// Gets the complete list of customers from the database.
        /// </summary>
        public async Task GetCustomerGroupListAsync()
        {
            await DispatcherHelper.ExecuteOnUIThreadAsync(() => IsLoading = true);

            var customers = await App.Repository.Customers.GetAsync();
            if (customers == null)
            {
                return;
            }

            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                Customer_Group.Clear();
                foreach (var c in customers)
                {
                    Customer_Group.Add(new CustomerGroupViewModel(c));
                }
                IsLoading = false;
            });
        }

        /// <summary>
        /// Gets the complete list of currency from the database.
        /// </summary>
        public async Task GetCurrencyGroupListAsync()
        {
   
            /*await DispatcherHelper.ExecuteOnUIThreadAsync(() => IsLoading = true);

            var currency = await App.Repository.Currency.GetAsync();
            if (currency == null)
            {
                return;
            }

            await DispatcherHelper.ExecuteOnUIThreadAsync(() =>
            {
                Currencies.Clear();
                foreach (var c in currency)
                {
                    Currencies.Add(new CurrencyViewModel(c));
                }
                IsLoading = false;
            });*/

        }
        
        /// <summary>
        /// Saves any modified customers and reloads the customer list from the database.
        /// </summary>
        public void Sync()
        {
            Task.Run(async () =>
            {
                IsLoading = true;
                foreach (var modifiedCustomer in Customer_Group
                    .Where(customer => customer.IsModified).Select(customer => customer.Model))
                {
                    await App.Repository.Customers.UpsertAsync(modifiedCustomer);
                }

                await GetCustomerGroupListAsync();
                IsLoading = false;
            });
        }
    }
}
