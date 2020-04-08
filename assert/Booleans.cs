using Xunit;
using Xunit.Sdk;

// 01 - Booleans
//
// Basic boolean expressions or null
//
// Use these for assertions like LessThan, AtLeast, EqualTo .. etc
//
// Or, use libraries that implements static extensions to get things like
//
// int variable = 5;
// variable.ShouldBe().GreatherThan(4);

namespace CSharpUnitTesting.assert
{
    public class Booleans
    {
       [Fact]
        public void False()
        {
            Assert.False(0 == 1);
            
            // These wont compile!
            //
            // Assert.False(0);
            // Assert.False((bool) 0);
            // Assert.False("");
            //
            // int iValue = 0;
            // Assert.False(iValue);
            //
            // string sValue = "";
            // Assert.False(sValue);
            //
            // string[] saValue = new string[] {}; 
            // Assert.False(saValue);
            //
            // Use assert on empty collections!
        }

        [Fact]
        public void False_ThrowsException_WhenNull()
        {
            Assert.Throws<FalseException>(
                () => Assert.False(null)
            );
        }

        [Fact]
        public void True()
        {
            Assert.True(1 == 1);
        }

        [Fact]
        public void True_ThrowsException_WhenNull()
        {
            Assert.Throws<TrueException>(
                () => Assert.True(null)
            );
        }
    }
}