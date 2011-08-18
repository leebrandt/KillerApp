using System;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace Core.Data.NHibernate
{
    public class NHibernateRepository : Repository
    {
        readonly ISession _session;

        public NHibernateRepository(ISession session)
        {
            _session = session;
            _session.FlushMode = FlushMode.Always;
        }

        public ISession Session 
        {
            get { return _session; }
        }

        public IQueryable<T> All<T>()
        {
            return _session.Query<T>();
        }

        public void Save<T>(T item)
        {
            using (var tnx = _session.BeginTransaction())
            {
                try
                {
                    _session.SaveOrUpdate(item);
                    tnx.Commit();
                }
                catch (Exception)
                {
                    tnx.Rollback();
                    throw;
                }
            }
        }

        public void Delete<T>(T item)
        {
            using (var tnx = _session.BeginTransaction())
            {
                try
                {
                    _session.Delete(item);
                    tnx.Commit();
                }
                catch (Exception)
                {
                    tnx.Rollback();
                    throw;
                }
            }
        }

        public void Delete<T>(int id)
        {
            Delete(_session.Get<T>(id));
        }

    }
}