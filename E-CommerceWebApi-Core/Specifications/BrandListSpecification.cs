using E_CommerceWebApi_Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebApi_Core.Specifications
{
    public class BrandListSpecification : BaseSpecification<Product, string>
    {
        public BrandListSpecification() 
        {
            AddSelect(x => x.Brand);
            ApplyDistinct();
        }
    }
}
