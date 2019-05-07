using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReyukoProject.Model
{
    public class Currency : DbObject, IEquatable<Currency>
    {
        /// <summary>
        /// returns currency Name
        /// </summary>
        public string Name { get; set; }

        public override string ToString() => Name;

        public bool Equals(Currency other) =>
            Name == other.Name;
            
    }
}
