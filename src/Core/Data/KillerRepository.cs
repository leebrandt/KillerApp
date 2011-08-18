using System.Collections.Generic;
using Core.Domain;

namespace Core.Data
{
    public interface KillerRepository
    {
        IList<Killer> GetAll();
    }
}