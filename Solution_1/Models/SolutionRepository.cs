using System.Collections.Generic;

namespace Solution_1.Models
{
    public class SolutionRepository : ISolutionRepository
    {
        private DataContext _context;

        public SolutionRepository(DataContext context) => _context = context;
        
        public IEnumerable<Solution> Solutions => _context.Solutions;

        public void AddSolution(Solution solution)
        {
            _context.Solutions.Add(solution);
            _context.SaveChanges();
        }

        public void DeleteSolution(Solution solution)
        {
            _context?.Solutions.Remove(solution);
            _context.SaveChanges();
        }
        

        public void UpdateSolution(Solution solution)
        {
            _context.Solutions.Update(solution);
            _context.SaveChanges();
        }
    }
}
