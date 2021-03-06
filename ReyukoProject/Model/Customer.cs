﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReyukoProject.Model
{
    public class CustomerGroup : DbObject, IEquatable<CustomerGroup>
    {
        /// <summary>
        /// Gets or sets the customer's first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the customer's last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the customer's company.
        /// </summary>
        public string Company { get; set; }

        /// <summary>
        /// Gets or sets the customer's email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the customer's phone number.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the customer's address. 
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Returns the customer's name.
        /// </summary>
        public override string ToString() => $"{FirstName} {LastName}";

        public bool Equals(CustomerGroup other) =>
            FirstName == other.FirstName &&
            LastName == other.LastName &&
            Company == other.Company &&
            Email == other.Email &&
            Phone == other.Phone &&
            Address == other.Address;
    }
}
