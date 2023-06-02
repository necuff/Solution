using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solution_1.Models
{
    public class Problem
    {
        public Problem() { 
            FinishDate = DateTime.Now;
        }        

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

        [Range(1, long.MaxValue, ErrorMessage = "Please select a Solution")]
        public long SolutionId { get; set; }
        
        public Solution Solution { get; set; }
    }
}
