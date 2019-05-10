using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReyukoProject.Model
{
    public class Currency : DbObject, IEquatable<Currency>
    {
      
        /// returns currency Name
        /// </summary>
        public string Name { get; set; }
        public int  Active_Check { get; set; }
        public string Code { get; set; }
        public string Symbol { get; set; }
        public string DateUpdate { get; set; }
        public string Exchange { get; set; }

        public override string ToString() => Name;

        public bool Equals(Currency other) =>
            Name == other.Name;
            
    }
}
