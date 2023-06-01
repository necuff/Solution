using Microsoft.AspNetCore.Mvc;
using Moq;
using Solution_1.Controllers;
using Solution_1.Models;
using Solution_1.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Solution_1.Tests
{
    public class SolutionControllerTests
    {
        [Fact]
        public static void CanPaginate_PageSize_3_Page_1()
        {
            Mock<ISolutionRepository> repository = new Mock<ISolutionRepository>();
            repository.Setup(rn => rn.Solutions).Returns((new List<Solution>
            {
                new Solution { Id = 1, Name = "S1"},
                new Solution { Id = 2, Name = "S2"},
                new Solution { Id = 3, Name = "S3"},
                new Solution { Id = 4, Name = "S4"},
                new Solution { Id = 5, Name = "S5"}
            }).AsQueryable<Solution>());

            SolutionController solutionController = new SolutionController(repository.Object);
            solutionController.PageSize = 3;

            SolutionsListViewModel result = solutionController.Index(1).ViewData.Model as SolutionsListViewModel;

            Solution[] solutions = result.Solutions.ToArray();
            Assert.True(solutions.Count() == 3);
            Assert.Equal("S1", solutions[0].Name);
            Assert.Equal("S2", solutions[1].Name);
            Assert.Equal("S3", solutions[2].Name);

        }

        [Fact]
        public static void CanPaginate_PageSize_2_Page_2()
        {
            Mock<ISolutionRepository> repository = new Mock<ISolutionRepository>();
            repository.Setup(rn => rn.Solutions).Returns((new List<Solution>
            {
                new Solution { Id = 1, Name = "S1"},
                new Solution { Id = 2, Name = "S2"},
                new Solution { Id = 3, Name = "S3"},
                new Solution { Id = 4, Name = "S4"},
                new Solution { Id = 5, Name = "S5"}
            }).AsQueryable<Solution>());

            SolutionController solutionController = new SolutionController(repository.Object);
            solutionController.PageSize = 2;

            SolutionsListViewModel result = solutionController.Index(2).ViewData.Model as SolutionsListViewModel;

            Solution[] solutions = result.Solutions.ToArray();
            Assert.True(solutions.Count() == 2);
            Assert.Equal("S3", solutions[0].Name);
            Assert.Equal("S4", solutions[1].Name);           
        }

        [Fact]
        public static void CanPaginate_Default_PageSize_10_Page_2()
        {
            Mock<ISolutionRepository> repository = new Mock<ISolutionRepository>();
            repository.Setup(rn => rn.Solutions).Returns((new List<Solution>
            {
                new Solution { Id = 1, Name = "S1"},
                new Solution { Id = 2, Name = "S2"},
                new Solution { Id = 3, Name = "S3"},
                new Solution { Id = 4, Name = "S4"},
                new Solution { Id = 5, Name = "S5"},
                new Solution { Id = 6, Name = "S6"},
                new Solution { Id = 7, Name = "S7"},
                new Solution { Id = 8, Name = "S8"},
                new Solution { Id = 9, Name = "S9"},
                new Solution { Id = 10, Name = "S10"},
                new Solution { Id = 11, Name = "S11"}
            }).AsQueryable<Solution>());

            SolutionController solutionController = new SolutionController(repository.Object);            


            SolutionsListViewModel result = solutionController.Index(2).ViewData.Model as SolutionsListViewModel;
            Solution[] solutions = result.Solutions.ToArray();

            Assert.True(solutions.Count() == 1);
            Assert.Equal("S11", solutions[0].Name);            
        }
    }
}
