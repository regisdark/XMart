using System.Linq;

namespace Modelo
{
    public abstract class ManejadorModelo<TEntity> where TEntity : class
    {
        XMARTEntities ctx;
        bool EnablingLazyLoading;

        public XMARTEntities GetContext
        {
            get
            {
                return ctx = ctx ?? new XMARTEntities();
            }
        }
        public ManejadorModelo()
        {
            ctx = new XMARTEntities();
        }

        ~ManejadorModelo()
        {
            ctx = null;
        }

        public ManejadorModelo<TEntity> UseLazyLoading(bool isEnabled = true)
        {
            EnablingLazyLoading = isEnabled;
            return this;
        }

        #region [Operaciones Basicas]
        public IQueryable<TEntity> SelectFrom
        {
            get
            {
                try
                {
                    ctx = GetContext;
                    ctx.Configuration.LazyLoadingEnabled = EnablingLazyLoading;
                    return ctx.Set<TEntity>();
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
        }

        public virtual TEntity Insert(TEntity entity)
        {
            try
            {
                ctx = GetContext;
                ctx.Configuration.LazyLoadingEnabled = EnablingLazyLoading;
                ctx.Set<TEntity>().Add(entity);
                ctx.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    System.Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return entity;
        }

        public virtual void Insert(TEntity[] entity)
        {
            try
            {
                ctx = GetContext;
                ctx.Configuration.LazyLoadingEnabled = EnablingLazyLoading;
                ctx.Set<TEntity>().AddRange(entity);
                ctx.SaveChanges();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public virtual TEntity Update(TEntity entity)
        {
            try
            {
                ctx = GetContext;
                ctx.Configuration.LazyLoadingEnabled = EnablingLazyLoading;
                ctx.Set<TEntity>().Attach(entity);
                ctx.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return entity;
        }

        public virtual void Update(TEntity[] entity)
        {
            try
            {
                ctx = GetContext;
                ctx.Configuration.LazyLoadingEnabled = EnablingLazyLoading;
                foreach (var item in entity)
                {
                    ctx.Set<TEntity>().Attach(item);
                    ctx.Entry(item).State = System.Data.Entity.EntityState.Modified;
                }
                ctx.SaveChanges();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public virtual TEntity Delete(TEntity entity)
        {
            try
            {
                ctx = GetContext;
                ctx.Configuration.LazyLoadingEnabled = EnablingLazyLoading;
                ctx.Set<TEntity>().Attach(entity);
                ctx.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            return entity;
        }

        public virtual void Delete(System.Collections.Generic.ICollection<TEntity> entity)
        {
            try
            {
                ctx = GetContext;
                ctx.Configuration.LazyLoadingEnabled = EnablingLazyLoading;
                foreach (var item in entity)
                {
                    ctx.Set<TEntity>().Attach(item);
                    ctx.Entry(item).State = System.Data.Entity.EntityState.Deleted;
                }
                ctx.SaveChanges();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region [Utileria]
        public System.Data.Entity.Infrastructure.DbRawSqlQuery<TElement> ExecuteQuery<TElement>(string query)
        {
            try
            {
                ctx = GetContext;
                return ctx.Database.SqlQuery<TElement>(query);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public System.DateTime GetServerDate
        {
            get
            {
                try
                {
                    return ExecuteQuery<System.DateTime>("SELECT GETDATE();").SingleOrDefault();
                }
                catch (System.Exception ex)
                {
                    throw ex;
                }
            }
        }

        #endregion

    }
}
