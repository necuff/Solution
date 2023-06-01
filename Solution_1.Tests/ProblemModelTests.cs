using Solution_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Solution_1.Tests
{
    public class ProblemModelTests
    {
        [Fact]
        public void ClassName_IsProblem()
        {
            //Arrange
            Problem problem = new Problem();

            //Act
            string resultClassType = problem.GetType().Name;

            //Assert
            Assert.Equal("Problem", resultClassType);
        }

        [Fact]
        public void Problem_Model_IsValid()
        {
            //Arrange
            Problem problem = new Problem();

            var properties = problem.GetType().GetProperties();

            Assert.Equal(7, properties.Length);
            Assert.Equal("Id", properties.First(p => p.Name == "Id").Name);
            Assert.Equal("Name", properties.First(p => p.Name == "Name").Name);
            Assert.Equal("FinishDate", properties.First(p => p.Name == "FinishDate").Name);
            Assert.Equal("Description", properties.First(p => p.Name == "Description").Name);
            Assert.Equal("Email", properties.First(p => p.Name == "Email").Name);
            Assert.Equal("SolutionId", properties.First(p => p.Name == "SolutionId").Name);
            Assert.Equal("Solution", properties.First(p => p.Name == "Solution").Name);

            Assert.Equal(typeof(long), properties.First(p => p.Name == "Id").PropertyType);
            Assert.Equal(typeof(string), properties.First(p => p.Name == "Name").PropertyType);
            Assert.Equal(typeof(DateTime), properties.First(p => p.Name == "FinishDate").PropertyType);
            Assert.Equal(typeof(string), properties.First(p => p.Name == "Description").PropertyType);
            Assert.Equal(typeof(string), properties.First(p => p.Name == "Email").PropertyType);
            Assert.Equal(typeof(long), properties.First(p => p.Name == "SolutionId").PropertyType);
            Assert.Equal(typeof(Solution), properties.First(p => p.Name == "Solution").PropertyType);
        }
    }
}
