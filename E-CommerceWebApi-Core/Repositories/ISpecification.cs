using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebApi_Core.Repositories
{
    public interface ISpecification<T>
    {
        Expression<Func<T,bool>>? Criteria { get; }
        Expression<Func<T,object>>? OrderBy { get; }
        Expression<Func<T,object>>? OrderByDesc { get; }
        bool IsDistinct { get; }
    }
    public interface ISpecification<T, TResult> : ISpecification<T>
    {
        Expression<Func<T, TResult>>? Select { get; }
    }
}
