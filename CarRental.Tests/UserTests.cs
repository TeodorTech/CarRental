using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRental.Tests;
using CarRental.Domain;
using CarRental.Domain.Exceptions;

namespace CarRental.Tests
{
   public class UserTests
    {
        [Fact]
        public void CheckAge_ShouldNotThrowExceptionIFLegal()
        {
            //Assemble
            User user = new User();
            string expected = "You can drive <3";


            //Act
            string actual = user.CheckAge(20);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(-10)]
        [InlineData(100)]
        public void CheckAge_ShouldThrowExceptionsIfUnderage(int age)
        {
            //Assemble
            User user = new User();

            //Act
            

            //Assert
            Assert.Throws<ExceptionAge>(() =>  user.CheckAge(age));
        }
    }
}
