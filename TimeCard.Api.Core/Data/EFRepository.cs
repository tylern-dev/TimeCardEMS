using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using AutoMapper.QueryableExtensions;
using TimeCard.Api.Core.Interfaces;
using TimeCard.Api.Core.Models;

namespace TimeCard.Api.Core.Data {
    public class EFRepository<T> : IAsyncRepository<T> where T : class, IIdKeyModel {
        protected readonly TimeCardDbContext _dbContext;

        public EFRepository(TimeCardDbContext dbContext) {
            _dbContext = dbContext;
        }

        public virtual T GetById(int id)
        {
            return _dbContext.Set<T>().Where(x => x.Id == id).SingleOrDefault();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().Where(x => x.Id == id).SingleOrDefaultAsync();
        }

        public virtual T GetById(int id, ISpecification<T> spec)
        {
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            return spec.Criteria
                .Aggregate(secondaryResult.Where(x => x.Id == id),
                    (current, criterion) => current.Where(criterion))
                .SingleOrDefault();
        }

        public virtual async Task<T> GetByIdAsync(int id, ISpecification<T> spec)
        {
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            return await spec.Criteria
                .Aggregate(secondaryResult.Where(x => x.Id == id),
                    (current, criterion) => current.Where(criterion))
                .SingleOrDefaultAsync();
        }

        public virtual TProjectTo GetById<TProjectTo>(int id)
        {
            return _dbContext.Set<T>().Where(x => x.Id == id).ProjectTo<TProjectTo>().SingleOrDefault();
        }

        public virtual async Task<TProjectTo> GetByIdAsync<TProjectTo>(int id)
        {
            return await _dbContext.Set<T>().Where(x => x.Id == id).ProjectTo<TProjectTo>().SingleOrDefaultAsync();
        }

        public virtual TProjectTo GetById<TProjectTo>(int id, ISpecification<T> spec)
        {
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            return spec.Criteria
                .Aggregate(secondaryResult.Where(x => x.Id == id),
                    (current, criterion) => current.Where(criterion))
                .ProjectTo<TProjectTo>()
                .SingleOrDefault();
        }

        public virtual async Task<TProjectTo> GetByIdAsync<TProjectTo>(int id, ISpecification<T> spec)
        {
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            return await spec.Criteria
                .Aggregate(secondaryResult.Where(x => x.Id == id),
                    (current, criterion) => current.Where(criterion))
                .ProjectTo<TProjectTo>()
                .SingleOrDefaultAsync();
        }

        public IEnumerable<T> List()
        {
            return _dbContext.Set<T>().AsEnumerable();
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public IEnumerable<TProjectTo> List<TProjectTo>()
        {
            return _dbContext.Set<T>().ProjectTo<TProjectTo>().AsEnumerable();
        }

        public async Task<IEnumerable<TProjectTo>> ListAsync<TProjectTo>()
        {
            return await _dbContext.Set<T>().ProjectTo<TProjectTo>().ToListAsync();
        }

        public IEnumerable<T> List(ISpecification<T> spec)
        {
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            var query = spec.Criteria
                .Aggregate(secondaryResult,
                    (current, criterion) => current.Where(criterion));

            return query.AsEnumerable();
        }

        public async Task<IEnumerable<T>> ListAsync(ISpecification<T> spec)
        {
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            var query = spec.Criteria
                .Aggregate(secondaryResult,
                    (current, criterion) => current.Where(criterion));

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<T>> ListAsyncAsNoTracking(ISpecification<T> spec)
        {
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            var query = spec.Criteria
                .Aggregate(secondaryResult,
                    (current, criterion) => current.Where(criterion));

            return await query.AsNoTracking().ToListAsync();
        }

        public IEnumerable<TProjectTo> List<TProjectTo>(ISpecification<T> spec)
        {
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            var query = spec.Criteria
                .Aggregate(secondaryResult,
                    (current, criterion) => current.Where(criterion));

            return query.ProjectTo<TProjectTo>().AsEnumerable();
        }

        public async Task<IEnumerable<TProjectTo>> ListAsync<TProjectTo>(ISpecification<T> spec)
        {
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            var query = spec.Criteria
                .Aggregate(secondaryResult,
                    (current, criterion) => current.Where(criterion));

            return await query.ProjectTo<TProjectTo>().ToListAsync();
        }

        public virtual IPagedResults<T> List(IPagingSpecification<T> pagingSpec)
        {
            var query = _dbContext.Set<T>();
            var total = query.Count();
            var data = query
                .OrderBy(pagingSpec.OrderBy)
                .Skip(pagingSpec.Count * (pagingSpec.Page - 1))
                .Take(pagingSpec.Count)
                .AsEnumerable();

            return GetPagedResults(total, pagingSpec.Count, pagingSpec.Page, data);
        }

        public virtual async Task<IPagedResults<T>> ListAsync(IPagingSpecification<T> pagingSpec)
        {
            var query = _dbContext.Set<T>();
            var total = await query.CountAsync();
            var data = await query
                .OrderBy(pagingSpec.OrderBy)
                .Skip(pagingSpec.Count * (pagingSpec.Page - 1))
                .Take(pagingSpec.Count)
                .ToListAsync();

            return GetPagedResults(total, pagingSpec.Count, pagingSpec.Page, data);
        }

        public virtual IPagedResults<T> List(IPagingSpecification<T> pagingSpec, ISpecification<T> spec)
        {
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            var query = spec.Criteria
                .Aggregate(secondaryResult,
                    (current, criterion) => current.Where(criterion));
            var total = query.Count();
            var data = query
                .OrderBy(pagingSpec.OrderBy)
                .Skip(pagingSpec.Count * (pagingSpec.Page - 1))
                .Take(pagingSpec.Count)
                .AsEnumerable();

            return GetPagedResults(total, pagingSpec.Count, pagingSpec.Page, data);
        }

        public virtual async Task<IPagedResults<T>> ListAsync(IPagingSpecification<T> pagingSpec, ISpecification<T> spec)
        {
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            var query = spec.Criteria
                .Aggregate(secondaryResult,
                    (current, criterion) => current.Where(criterion));
            var total = await query.CountAsync();
            var data = await query
                .OrderBy(pagingSpec.OrderBy)
                .Skip(pagingSpec.Count * (pagingSpec.Page - 1))
                .Take(pagingSpec.Count)
                .ToListAsync();

            return GetPagedResults(total, pagingSpec.Count, pagingSpec.Page, data);
        }

        public virtual IPagedResults<TProjectTo> List<TProjectTo>(IPagingSpecification<T> pagingSpec, ISpecification<T> spec)
        {
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            var query = spec.Criteria
                .Aggregate(secondaryResult,
                    (current, criterion) => current.Where(criterion));
            var total = query.Count();
            var data = query
                .OrderBy(pagingSpec.OrderBy)
                .Skip(pagingSpec.Count * (pagingSpec.Page - 1))
                .Take(pagingSpec.Count)
                .ProjectTo<TProjectTo>()
                .AsEnumerable();

            return GetPagedResults(total, pagingSpec.Count, pagingSpec.Page, data);
        }

        public virtual async Task<IPagedResults<TProjectTo>> ListAsync<TProjectTo>(IPagingSpecification<T> pagingSpec, ISpecification<T> spec)
        {
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_dbContext.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            var query = spec.Criteria
                .Aggregate(secondaryResult,
                    (current, criterion) => current.Where(criterion));
            var total = await query.CountAsync();
            var data = await query
                .OrderBy(pagingSpec.OrderBy)
                .Skip(pagingSpec.Count * (pagingSpec.Page - 1))
                .Take(pagingSpec.Count)
                .ProjectTo<TProjectTo>()
                .ToListAsync();

            return GetPagedResults<TProjectTo>(total, pagingSpec.Count, pagingSpec.Page, data);
        }

        public virtual T Add(T model)
        {
            _dbContext.Set<T>().Add(model);
            _dbContext.SaveChanges();

            return model;
        }

        public virtual async Task<T> AddAsync(T model)
        {
            _dbContext.Set<T>().Add(model);
            await _dbContext.SaveChangesAsync();

            return model;
        }

        public virtual IEnumerable<T> Add(IEnumerable<T> models)
        {
            foreach (var model in models) {
                _dbContext.Set<T>().Add(model);
            }
            _dbContext.SaveChanges();

            return models;
        }

        public virtual async Task<IEnumerable<T>> AddAsync(IEnumerable<T> models)
        {
            foreach (var model in models) {
                _dbContext.Set<T>().Add(model);
            }
            await _dbContext.SaveChangesAsync();

            return models;
        }

        public virtual void Update(T model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public virtual void Update(IEnumerable<T> models)
        {
            foreach (var model in models) {
                _dbContext.Entry(model).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();
        }

        public virtual async Task UpdateAsync(T model)
        {
            _dbContext.Entry(model).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(IEnumerable<T> models)
        {
            foreach (var model in models) {
                _dbContext.Entry(model).State = EntityState.Modified;
            }
            await _dbContext.SaveChangesAsync();
        }

        public virtual void Delete(T model)
        {
            _dbContext.Set<T>().Remove(model);
            _dbContext.SaveChanges();
        }

        public virtual async Task DeleteAsync(T model)
        {
            _dbContext.Set<T>().Remove(model);
            await _dbContext.SaveChangesAsync();
        }

        public virtual IDbContextTransaction BeginTransaction() {
            return _dbContext.Database.BeginTransaction();
        }

        public virtual async Task<IDbContextTransaction> BeginTransactionAsync() {
            return await _dbContext.Database.BeginTransactionAsync();
        }

        public virtual void CommitTransaction(IDbContextTransaction transaction) {
            transaction.Commit();
        }

        protected PagedResults<TReturn> GetPagedResults<TReturn>(int total, int count, int page, IEnumerable<TReturn> data) {
            return new PagedResults<TReturn> {
                Total = total,
                Pages =  (int)Math.Ceiling((double)total / (double)count),
                Count = count,
                Page = page,
                Data = data
            };
        }
    }
}