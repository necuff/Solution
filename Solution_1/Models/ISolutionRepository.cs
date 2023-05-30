using System.Collections.Generic;

namespace Solution_1.Models
{
    public interface ISolutionRepository
    {
        IEnumerable<Solution> Solutions { get; }        

        void AddSolution(Solution solution);

        void UpdateSolution(Solution solution);

        void DeleteSolution(Solution solution);
    }
}
