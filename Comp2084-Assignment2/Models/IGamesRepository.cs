using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comp2084_Assignment2.Models
{
    public interface IGamesRepository
    {
        IQueryable<game> Games { get; }

        IQueryable<console> Consoles { get; }

        game Save(game game);
        void Delete(game game);
    }
}
