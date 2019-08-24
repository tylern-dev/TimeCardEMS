using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage;
using TimeCard.Api.Core.Models;

namespace TimeCard.Api.Core.Interfaces {
    public interface IRepository<T> where T: IIdKeyModel {
        T GetById(int id);
        T GetById(int id, ISpecification<T> spec);
        TProjectTo GetById<TProjectTo>(int id);
        TProjectTo GetById<TProjectTo>(int id, ISpecification<T> spec);
        IEnumerable<T> List();
        IEnumerable<T> List(ISpecification<T> spec);
        IEnumerable<TProjectTo> List<TProjectTo>();
        IEnumerable<TProjectTo> List<TProjectTo>(ISpecification<T> spec);
        IPagedResults<T> List(IPagingSpecification<T> pagingSpec);
        IPagedResults<T> List(IPagingSpecification<T> pagingSpec, ISpecification<T> spec);
        IPagedResults<TProjectTo> List<TProjectTo>(IPagingSpecification<T> pagingSpec, ISpecification<T> spec);
        T Add(T model);
        IEnumerable<T> Add(IEnumerable<T> models);
        void Update(T model);
        void Update(IEnumerable<T> models);
        void Delete(T model);
        IDbContextTransaction BeginTransaction();
        void CommitTransaction(IDbContextTransaction transaction);
    }
}