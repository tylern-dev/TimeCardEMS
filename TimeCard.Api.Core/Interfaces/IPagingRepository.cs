using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TimeCard.Api.Core.Interfaces {
    public interface IPagingSpecification<T> {
        Expression<Func<T, int>> OrderBy { get; }
        int Page { get; }
        int Count { get; }
    }
}
