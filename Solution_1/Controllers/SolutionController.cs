using Microsoft.AspNetCore.Mvc;
using Solution_1.Models;
using System.Linq;

namespace Solution_1.Controllers
{
    public class SolutionController : Controller
    {
        private ISolutionRepository _solutionRepository;

        public SolutionController(ISolutionRepository solutionRepository) => _solutionRepository = solutionRepository;

        public IActionResult Index() => View(_solutionRepository.Solutions as IQueryable);

        [HttpPost]
        public IActionResult AddSolution(Solution solution)
        {
            _solutionRepository.AddSolution(solution);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditSolution(long id)
        {
            ViewBag.EditId = id;
            return View("Index", _solutionRepository.Solutions);
        }
        
        [HttpPost]
        public IActionResult UpdateSolution(Solution solution) 
        { 
            _solutionRepository.UpdateSolution(solution);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteSolution(Solution solution) 
        { 
            _solutionRepository.DeleteSolution(solution);
            return RedirectToAction(nameof(Index));
        }
    }
}
