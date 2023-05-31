using System;
using System.ComponentModel.DataAnnotations;

namespace Solution_1.Models
{
    public class Problem
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Please enter a Name of problem")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter finish date")]
        [DataType(DataType.DateTime, ErrorMessage = "The FinishDate field must be in the format {dd.MM.yyyy}")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]  //Можно было написать свой валидатор, как вариант      
        public DateTime FinishDate { get; set; }        
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        
        public long SolutionId { get; set; }        
        public Solution Solution { get; set; }
    }
}
