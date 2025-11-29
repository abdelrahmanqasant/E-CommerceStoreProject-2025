using E_CommerceWebApi_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebApi_Core.Specifications
{
    public class TypeListSpecification :BaseSpecification<Product,string>
    {
        public TypeListSpecification()
        {
            AddSelect(x => x.Type);
            ApplyDistinct();
        }
    }
}
