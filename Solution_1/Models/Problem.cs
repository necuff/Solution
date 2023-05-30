namespace Solution_1.Models
{
    public class Problem
    {
        public long Id { get; set; }
        public string Name { get; set; }        

        public string FinishDate { get; set; }        
        public string Description { get; set; }
        public string Email { get; set; }

        public long SolutionId { get; set; }
        public Solution Solution { get; set; }
    }
}
