using System.Linq;
using NHibernate;

namespace Core.Data
{
    public interface Repository
    {
        ISession Session { get; }
        IQueryable<T> All<T>();
        void Save<T>(T item);
        void Delete<T>(T item);
        void Delete<T>(int id);
    }
}