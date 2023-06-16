using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinancesApp.Models.EntityLayer
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
