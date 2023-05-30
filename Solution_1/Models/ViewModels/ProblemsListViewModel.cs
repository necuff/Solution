using System.Collections.Generic;

namespace Solution_1.Models.ViewModels
{
    public class ProblemsListViewModel
    {
        public IEnumerable<Problem> Problems { get; set;}
        public PagingInfo PagingInfo { get; set;}
    }
}
