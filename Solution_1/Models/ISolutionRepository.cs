using System.Collections.Generic;
using System.Linq;

namespace Solution_1.Models
{
    public interface ISolutionRepository
    {
        IQueryable<Solution> Solutions { get; }        

        void AddSolution(Solution solution);

        void UpdateSolution(Solution solution);

        void DeleteSolution(Solution solution);
    }
}
