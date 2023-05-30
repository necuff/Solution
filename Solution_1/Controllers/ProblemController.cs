using Microsoft.AspNetCore.Mvc;
using Solution_1.Models;
using System.Linq;

namespace Solution_1.Controllers
{
    public class ProblemController : Controller
    {
        private IProblemRepository _problemRepository;
        private ISolutionRepository _solutionRepository;

        public ProblemController(IProblemRepository problemRepository, ISolutionRepository solutionRepository)
        {
            _problemRepository = problemRepository;
            _solutionRepository = solutionRepository;
        }

        public IActionResult Index() => View(_problemRepository.Problems as IQueryable);

        public IActionResult AddProblem(Problem problem)
        {
            _problemRepository.AddProblem(problem);
            return RedirectToAction(nameof(Index));
        }        

        public IActionResult UpdateProblem(long id)
        {
            ViewBag.Solutions = _solutionRepository.Solutions;
            return View(id == 0 ? new Problem() : _problemRepository.GetProblem(id));
        }

        [HttpPost]
        public IActionResult UpdateProblem(Problem problem)
        {
            if(problem.Id == 0)
            {
                _problemRepository.AddProblem(problem);
            }
            else
            {
                _problemRepository.UpdateProblem(problem);
            }            
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteProblem(Problem problem) 
        { 
            _problemRepository.DeleteProblem(problem);
            return RedirectToAction(nameof(Index));
        }
    }
}
