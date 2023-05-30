using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Solution_1.Models
{
    public class ProblemRepository : IProblemRepository
    {
        private DataContext _dataContext;

        public ProblemRepository(DataContext dataContext)
        {
            _dataContext = dataContext;            
        }

        public IQueryable<Problem> Problems =>
            _dataContext.Problems.Include(p => p.Solution);

        public void AddProblem(Problem problem)
        {
            _dataContext.Problems.Add(problem);
            _dataContext.SaveChanges();
        }
        
        public Problem GetProblem(long id) =>
            _dataContext.Problems.Include(p => p.Solution).First(p => p.Id == id);        

        public void UpdateProblem(Problem problem)
        {
            Problem p = _dataContext.Problems.Find(problem.Id);
            p.Name = problem.Name;
            p.SolutionId = problem.SolutionId;
            p.FinishDate = problem.FinishDate;
            p.Description = problem.Description;
            p.Email = problem.Email;            
            _dataContext.SaveChanges();
        }

        public void DeleteProblem(Problem problem) 
        {
            _dataContext.Problems.Remove(problem);
            _dataContext.SaveChanges();
        }
    }
}
