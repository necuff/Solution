using System.ComponentModel.DataAnnotations;

namespace Solution_1.Models
{
    public class Problem
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Please enter a Name of problem")]
        public string Name { get; set; }
        
        public string FinishDate { get; set; }        
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        
        public long SolutionId { get; set; }        
        public Solution Solution { get; set; }
    }
}
