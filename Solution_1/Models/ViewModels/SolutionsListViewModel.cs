using System.Collections.Generic;

namespace Solution_1.Models.ViewModels
{
    public class SolutionsListViewModel
    {
        public IEnumerable<Solution> Solutions { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
