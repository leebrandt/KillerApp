using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain;

namespace Core.Data.NHibernate
{
    public class NHibernateKillerRepository : KillerRepository
    {
        readonly Repository _repository;

        public NHibernateKillerRepository(Repository repository)
        {
            _repository = repository;
        }

        public IList<Killer> GetAll()
        {
            return _repository.All<Killer>().ToList();
        }
    }
}