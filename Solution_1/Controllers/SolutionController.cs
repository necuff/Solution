using Microsoft.AspNetCore.Mvc;
using Solution_1.Models;
using Solution_1.Models.ViewModels;
using System.Linq;

namespace Solution_1.Controllers
{
    public class SolutionController : Controller
    {
        private ISolutionRepository _solutionRepository;

        private int _pageSize = 10;

        public SolutionController(ISolutionRepository solutionRepository) => _solutionRepository = solutionRepository;

        public IActionResult Index(int pageNum = 1)
            => View(new SolutionsListViewModel
            {
                Solutions = _solutionRepository.Solutions
                .OrderBy(p => p.Id)
                .Skip((pageNum - 1) * _pageSize)
                .Take(_pageSize)
                .ToList(),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = pageNum,
                    ItemsPerPage = _pageSize,
                    TotalItems = _solutionRepository.Solutions.Count()
                }
            });


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
