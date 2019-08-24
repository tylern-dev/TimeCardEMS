using System.Collections.Generic;
using TimeCard.Api.Core.Interfaces;

namespace TimeCard.Api.Core.Data {
    public class PagedResults<T> : IPagedResults<T> {
        public int Total { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }
        public int Pages { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}