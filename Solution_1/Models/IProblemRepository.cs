using System.Collections.Generic;

namespace Solution_1.Models
{
    public interface IProblemRepository
    {
        IEnumerable<Problem> Problems { get; }

        Problem GetProblem(long id);

        void AddProblem(Problem problem);

        void UpdateProblem(Problem problem);

        void DeleteProblem(Problem problem);
    }
}
