using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReyukoProject.Model
{
    public class DbObject
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
