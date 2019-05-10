using Microsoft.Toolkit.Uwp.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReyukoProject.Model.ViewModels
{
    public class CurrencyViewModel : BindableBase, IEditableObject
    {
        public CurrencyViewModel(Currency model = null) => Model = model ?? new Currency();

        private Currency _model;

        /// <summary>
        /// Gets or sets the underlying Currency object.
        /// </summary>
        public Currency Model
        {
            get => _model;
            set
            {
                if (_model != value)
                {
                    _model = value;

                    // Raise the PropertyChanged event for all properties.
                    OnPropertyChanged(string.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets the currency name.
        /// </summary>
        public string Name
        {
            get => Model.Name;
            set
            {
                if (value != Model.Name)
                {
                    Model.Name = value;
                    IsModified = true;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        // <summary>
        /// Gets or sets the currency code.
        /// </summary>
        public string Code
        {
            get => Model.Code;
            set
            {
                if (value != Model.Code)
                {
                    Model.Code = value;
                    IsModified = true;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Code));
                }
            }
        }
        // <summary>
        /// Gets or sets the currency symbol.
        /// </summary>
        public string Symbol
        {
            get => Model.Symbol;
            set
            {
                if (value != Model.Symbol)
                {
                    Model.Code = value;
                    IsModified = true;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(Symbol));
                }
            }
        }

        /// <summary>
        /// Gets or sets a value that indicates whether the underlying model has been modified. 
        /// </summary>
        /// <remarks>
        /// Used when sync'ing with the server to reduce load and only upload the models that have changed.
        /// </remarks>
        public bool IsModified { get; set; }

        /// <summary>
        /// Gets the collection of the currency orders.
        /// </summary>
        public ObservableCollection<Currency> Orders { get; } = new ObservableCollection<Currency>();

        private Order _selectedOrder;

        /// <summary>
        /// Gets or sets the currently selected order.
        /// </summary>
        public Order SelectedOrder
        {
            get => _selectedOrder;
            set { _selectedOrder = value; }
        }


        private bool _isLoading;

        /// <summary>
        /// Gets or sets a value that indicates whether to show a progress bar. 
        /// </summary>
        public bool IsLoading
        {
            get => _isLoading;
            set { _isLoading = value; }
        }

        private bool _isNewCurrency;

        /// <summary>
        /// Gets or sets a value that indicates whether this is a new currency.
        /// </summary>
        public bool IsNewCurrency
        {
            get => _isNewCurrency;
            set { _isNewCurrency = value; }
        }

        private bool _isInEdit = false;

        /// <summary>
        /// Gets or sets a value that indicates whether the currency data is being edited.
        /// </summary>
        public bool IsInEdit
        {
            get { return _isInEdit; }
            set { _isInEdit = value; }
        }

        /// <summary>
        /// Saves currency data that has been edited.
        /// </summary>
        public async Task SaveAsync()
        {
            IsInEdit = false;
            IsModified = false;
            if (IsNewCurrency)
            {
                IsNewCurrency = false;
                App.ViewModel.Currencies.Add(this);
            }

            await App.Repository.Currency.UpsertAsync(Model);
        }

        /// <summary>
        /// Raised when the user cancels the changes they've made to the currency data.
        /// </summary>
        public event EventHandler AddNewCurrencyCanceled;

        /// <summary>
        /// Cancels any in progress edits.
        /// </summary>
        public async Task CancelEditsAsync()
        {
            if (IsNewCurrency)
            {
                AddNewCurrencyCanceled?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                await RevertChangesAsync();
            }
        }

        /// <summary>
        /// Discards any edits that have been made, restoring the original values.
        /// </summary>
        public async Task RevertChangesAsync()
        {
            IsInEdit = false;
            if (IsModified)
            {
                await RefreshCurrencyAsync();
                IsModified = false;
            }
        }

        /// <summary>
        /// Enables edit mode.
        /// </summary>
        public void StartEdit() => IsInEdit = true;

        /// <summary>
        /// Reloads all of the currency data.
        /// </summary>
        public async Task RefreshCurrencyAsync()
        {
            Model = await App.Repository.Currency.GetAsync(Model.Id);
        }

       

        /// <summary>
        /// Called when a bound DataGrid control causes the currency to enter edit mode.
        /// </summary>
        public void BeginEdit()
        {
            // Not used.
        }

        /// <summary>
        /// Called when a bound DataGrid control cancels the edits that have been made to a currency.
        /// </summary>
        public async void CancelEdit() => await CancelEditsAsync();

        /// <summary>
        /// Called when a bound DataGrid control commits the edits that have been made to a currency.
        /// </summary>
        public async void EndEdit() => await SaveAsync();
    }
}
