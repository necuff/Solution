using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using Solution_1.Models;
using Solution_1.Models.ViewModels;
using System.Linq;

namespace Solution_1.Controllers
{
    public class ProblemController : Controller
    {
        private IProblemRepository _problemRepository;
        private ISolutionRepository _solutionRepository;

        private int _pageSize = 10;

        public ProblemController(IProblemRepository problemRepository, ISolutionRepository solutionRepository)
        {
            _problemRepository = problemRepository;
            _solutionRepository = solutionRepository;
        }

        public IActionResult Index(int pageNum = 1) 
            => View(new ProblemsListViewModel
            {
                Problems = _problemRepository.Problems
                .OrderBy(p => p.Id)
                .Skip((pageNum - 1) * _pageSize)
                .Take(_pageSize)
                .ToList(),                
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = _pageSize,
                    TotalItems = _problemRepository.Problems.Count()
                }
            });


        public IActionResult AddProblem(Problem problem)
        {
            if (!ModelState.IsValid)
            {                
                return View(problem);
            }
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
            if (!ModelState.IsValid)
            {
                ViewBag.Solutions = _solutionRepository.Solutions;
                return View(problem);
            }
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
