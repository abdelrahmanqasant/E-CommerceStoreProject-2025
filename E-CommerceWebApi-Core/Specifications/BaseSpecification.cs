using E_CommerceWebApi_Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebApi_Core.Specifications
{
    public class BaseSpecification<T>(Expression<Func<T,bool>>? _Criteria) : ISpecification<T>
    {
        protected  BaseSpecification() : this(null) { }
        

        public Expression<Func<T, bool>>? Criteria =>_Criteria;

        public Expression<Func<T, object>>? OrderBy { get; private set; }

        public Expression<Func<T, object>>? OrderByDesc { get; private set; }

        public bool IsDistinct {get; private set;}

        protected void AddOrderBy (Expression<Func<T,object>>? orderByExpression)
        {
            OrderBy = orderByExpression;
        }
        protected void AddOrderByDescending(Expression<Func<T,object>>? orderByDescExpression)
        {
            OrderByDesc = orderByDescExpression;
        }
        protected void ApplyDistinct()
        {
            this.IsDistinct = true;
        }
    }
    public class BaseSpecification<T, TResult>(Expression<Func<T, bool>>? criteria) : BaseSpecification<T>(criteria),
        ISpecification<T, TResult>
    {
        protected BaseSpecification() : this(null!) { }
        public Expression<Func<T, TResult>>? Select { get; private set; }
        protected void AddSelect(Expression<Func<T,TResult>> selectExprssion)
        {
            this.Select = selectExprssion;
        }
    }
}
