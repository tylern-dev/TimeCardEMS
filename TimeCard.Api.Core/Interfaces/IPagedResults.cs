using System.Collections.Generic;

namespace TimeCard.Api.Core.Interfaces {

    public interface IPagedResults<T> {
        int Total { get; }
        int Count { get; }
        int Page { get; }
        int Pages { get; }

        IEnumerable<T> Data { get; }
    }
}