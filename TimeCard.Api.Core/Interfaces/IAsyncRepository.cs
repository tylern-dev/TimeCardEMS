using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage;
using TimeCard.Api.Core.Models;

namespace TimeCard.Api.Core.Interfaces {

    public interface IAsyncRepository<T> : IRepository<T> where T: IIdKeyModel {
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(int id, ISpecification<T> spec);
        Task<TProjectTo> GetByIdAsync<TProjectTo>(int id);
        Task<TProjectTo> GetByIdAsync<TProjectTo>(int id, ISpecification<T> spec);
        Task<IEnumerable<T>> ListAsync();
        Task<IEnumerable<T>> ListAsync(ISpecification<T> spec);
        Task<IEnumerable<T>> ListAsyncAsNoTracking(ISpecification<T> spec);
        Task<IEnumerable<TProjectTo>> ListAsync<TProjectTo>();
        Task<IEnumerable<TProjectTo>> ListAsync<TProjectTo>(ISpecification<T> spec);
        Task<IPagedResults<T>> ListAsync(IPagingSpecification<T> pagingSpec);
        Task<IPagedResults<T>> ListAsync(IPagingSpecification<T> pagingSpec, ISpecification<T> spec);
        Task<IPagedResults<TProjectTo>> ListAsync<TProjectTo>(IPagingSpecification<T> pagingSpec, ISpecification<T> spec);
        Task<T> AddAsync(T model);
        Task<IEnumerable<T>> AddAsync(IEnumerable<T> models);
        Task UpdateAsync(T model);
        Task UpdateAsync(IEnumerable<T> models);
        Task DeleteAsync(T model);
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}