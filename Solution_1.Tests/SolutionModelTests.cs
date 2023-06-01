using Solution_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;

namespace Solution_1.Tests
{
    public class SolutionModelTests
    {
        [Fact]
        public void ClassName_IsSolution()
        {
            //Arrange
            Solution solution = new Solution();

            //Act
            string resultClassType = solution.GetType().Name;

            //Assert
            Assert.Equal("Solution", resultClassType);
        }

        [Fact]
        public void Solution_Model_IsValid()
        {
            //Arrange
            Solution solution = new Solution();

            var properties = solution.GetType().GetProperties();

            Assert.Equal(2, properties.Length);
            Assert.Equal("Id", properties.First(p => p.Name == "Id").Name);
            Assert.Equal("Name", properties.First(p => p.Name == "Name").Name);
            Assert.Equal(typeof(long), properties.First(p => p.Name == "Id").PropertyType);
            Assert.Equal(typeof(string), properties.First(p => p.Name == "Name").PropertyType);
        }            
    }
}
