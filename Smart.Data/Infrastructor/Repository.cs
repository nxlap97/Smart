using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Smart.Core.Domain;
using Smart.Domain.Entity;
using Smart.Utility.StringHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;

namespace Smart.Data.Infrastructor
{
    public class Repository<T,K> : IRepository<T,K>, IDisposable where T : ParentEntity<string>
    {
        private readonly SmartDbContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public Repository(SmartDbContext context, IHttpContextAccessor httpContext)
        {
            _context = context;
            _httpContext = httpContext;
        }

        private void UpdateInfo(string objectId, string state, bool published = true)
        {
            var info = new Info();
            var addState = InfoState.ADD;
            var claim = _httpContext.HttpContext.User.Claims.Where(x => x.Type == ClaimHelper.ID).FirstOrDefault();

            switch (state)
            {
                case "ADD_ENTITY_STATE":
                    info.CreatedDate = DateTime.Now;
                    info.CreatedBy = claim?.Value;
                    info.ObjectId = objectId;
                    info.Published = published;
                    _context.Infos.Add(info);
                    break;
                case "UPDATE_ENTITY_STATE":
                    info = _context.Infos.Where(x => x.ObjectId == objectId).FirstOrDefault();
                    if(info != null)
                    {
                        info.UpdatedDate = DateTime.Now;
                        info.UpdatedBy = claim?.Value;
                        info.ObjectId = objectId;
                        info.Published = published;
                        _context.Infos.Update(info);
                    }
                   
                    break;
                case "REMOVE_ENTITY_STATE":
                    info = _context.Infos.Where(x => x.ObjectId == objectId).FirstOrDefault();
                    if (info != null)
                    {
                        info.DeletedDate = DateTime.Now;
                        info.DeletedBy = claim?.Value;
                        info.ObjectId = objectId;
                        info.Published = published;
                        _context.Infos.Update(info);
                    }
                    break;
            }
            SaveChange();
        }

        public void Add(T entity)
        {
            _context.Add(entity);
            UpdateInfo(entity.Id, InfoState.ADD);
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _context.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items;
        }

        public IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> items = _context.Set<T>();
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties)
                {
                    items = items.Include(includeProperty);
                }
            }
            return items.Where(predicate);
        }

        public T FindById(K id, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(x => x.Id.Equals(id));
        }

        public T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            return FindAll(includeProperties).SingleOrDefault(predicate);
        }

        public void Remove(T entity)
        {
            UpdateInfo(entity.Id, InfoState.REMOVE);
            //_context.Set<T>().Remove(entity);
        }

        public void Remove(K id)
        {
            UpdateInfo(id.ToString(), InfoState.REMOVE);
        }

        public void RemoveMultiple(List<T> entities)
        {
            foreach (var entity in entities)
            {
                Remove(entity);
            }
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            UpdateInfo(entity.Id, InfoState.UPDATE);
        }


        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
