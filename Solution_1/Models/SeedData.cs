using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace Solution_1.Models
{
    public static class SeedData
    {
        public static void InitMigrate(IApplicationBuilder app)
        {
            DataContext dataContext = app.ApplicationServices.GetRequiredService<DataContext>();
            dataContext.Database.Migrate();
            FillSolutions(dataContext);
            FillProblems(dataContext);
        }

        private static void FillSolutions(DataContext dataContext)
        {
            if (!dataContext.Solutions.Any())
            {
                dataContext.Solutions.AddRange(
                new Solution { Name = "Solution 1" },
                new Solution { Name = "Solution 2" },
                new Solution { Name = "Solution 3" },
                new Solution { Name = "Solution 4" },
                new Solution { Name = "Solution 5" },
                new Solution { Name = "Solution 6" },
                new Solution { Name = "Solution 7" },
                new Solution { Name = "Solution 8" },
                new Solution { Name = "Solution 9" },
                new Solution { Name = "Solution 10" },
                new Solution { Name = "Solution 11" },
                new Solution { Name = "Solution 12" }
            );
                dataContext.SaveChanges();
            }            
        }

        private static void FillProblems(DataContext dataContext)
        {
            if (!dataContext.Problems.Any())
            {
                dataContext.Problems.AddRange(
                    new Problem { Name = "Problem 1", Description = "Description" , SolutionId = 1, Email = "aaa@bbb.cc"},
                    new Problem { Name = "Problem 2", Description = "Description" , SolutionId = 1, Email = "aaa@bbb.cc" },
                    new Problem { Name = "Problem 3", Description = "Description" , SolutionId = 1, Email = "aaa@bbb.cc" },
                    new Problem { Name = "Problem 4", Description = "Description" , SolutionId = 2, Email = "aaa@bbb.cc" },
                    new Problem { Name = "Problem 5", Description = "Description", SolutionId = 2, Email = "aaa@bbb.cc" },
                    new Problem { Name = "Problem 6", Description = "Description", SolutionId = 2, Email = "aaa@bbb.cc" },
                    new Problem { Name = "Problem 7", Description = "Description", SolutionId = 2, Email = "aaa@bbb.cc" },
                    new Problem { Name = "Problem 8", Description = "Description", SolutionId = 1, Email = "aaa@bbb.cc" },
                    new Problem { Name = "Problem 9", Description = "Description", SolutionId = 3, Email = "aaa@bbb.cc" },
                    new Problem { Name = "Problem 10", Description = "Description", SolutionId = 4, Email = "aaa@bbb.cc" },
                    new Problem { Name = "Problem 11", Description = "Description", SolutionId = 5, Email = "aaa@bbb.cc" },
                    new Problem { Name = "Problem 12", Description = "Description", SolutionId = 1, Email = "aaa@bbb.cc" }
                    );
                dataContext.SaveChanges();
            }
        }
    }
}
