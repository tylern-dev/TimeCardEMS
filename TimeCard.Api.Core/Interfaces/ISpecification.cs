using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TimeCard.Api.Core.Interfaces {
    public interface ISpecification<T> {
        IEnumerable<Expression<Func<T, bool>>> Criteria { get; }
        IEnumerable<Expression<Func<T, object>>> Includes { get; }
        IEnumerable<string> IncludeStrings { get; }
    }
}
