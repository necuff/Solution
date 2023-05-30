using System.Collections.Generic;
using System.Linq;

namespace Solution_1.Models
{
    public interface IProblemRepository
    {
        IQueryable<Problem> Problems { get; }

        Problem GetProblem(long id);

        void AddProblem(Problem problem);

        void UpdateProblem(Problem problem);

        void DeleteProblem(Problem problem);
    }
}
