using System;
using System.Text.RegularExpressions;
using Xunit;
using Xunit.Sdk;

namespace CSharpUnitTesting.xAssert
{
    public class Strings
    {
        [Theory]
        [InlineData("",    "")]
        [InlineData("",    "subString")]
        [InlineData("sub", "sub")]
        [InlineData("sub", "subString")]
        [InlineData("sub", "middlesubString")]
        [InlineData("sub", "endStringsub")]
        public void Contains(string subString, string inString)
        {
            Assert.Contains(subString, inString);
        }

        [Fact]
        public void Contains_DefaultIs_CaseSensitive()
        {
            Assert.Throws<ContainsException>(
                () => Assert.Contains("sub", "SUBString")
            );
        }

        [Fact]
        public void Contains_WithComparison()
        {
            Assert.Contains("sub", "SUBString", StringComparison.CurrentCultureIgnoreCase);
        }
        
        [Fact]
        public void Contains_ThrowsException_WhenStringIsNull()
        {
            string inString = null;

            Assert.Throws<ContainsException>(
                () => Assert.Contains("sub", inString)
            );
        }

        [Theory]
        [InlineData("sub", "")]
        [InlineData("sub", "SubString")]
        [InlineData("sub", "middleSubString")]
        [InlineData("sub", "endStringSub")]
        public void DoesNotContain(string subString, string inString)
        {
            Assert.DoesNotContain(subString, inString);
        }

        [Fact]
        public void DoesNotContain_DefaultIs_CaseSensitive()
        {
            Assert.DoesNotContain("sub", "SUBString");
        }
        
        [Fact]
        public void DoesNotContain_WithComparison()
        {
            Assert.Throws<DoesNotContainException>(
                () => Assert.DoesNotContain("sub", "SUBString", StringComparison.CurrentCultureIgnoreCase)
            );
        }
        
        [Fact]
        public void DoesNotContain_DoesNotThrowException_WhenStringIsNull()
        {
            string inString = null;

            Assert.DoesNotContain("sub", inString);
        }

        [Theory]
        [InlineData("",    "")]
        [InlineData("",    "anyString")]
        [InlineData("a",   "anyString")]
        [InlineData("any", "anyString")]
        public void StartsWith(string start, string inString)
        {
            Assert.StartsWith(start, inString);
        }
        
        [Fact]
        public void StartsWith_DefaultIs_CaseSensitive()
        {
            Assert.Throws<StartsWithException>(
                () => Assert.StartsWith("any", "ANYString")
            );
        }

        [Fact]
        public void StartsWith_WithComparison()
        {
            Assert.StartsWith("any", "ANYString", StringComparison.CurrentCultureIgnoreCase);
        }

        [Fact]
        public void StartsWith_ThrowsException_WhenStringIsNull()
        {
            string inString = null;

            Assert.Throws<StartsWithException>(
                () => Assert.StartsWith("any", inString)
            );
        }

        [Theory]
        [InlineData("",       "")]
        [InlineData("",       "anyString")]
        [InlineData("g",      "anyString")]
        [InlineData("String", "anyString")]
        public void EndsWith(string start, string inString)
        {
            Assert.EndsWith(start, inString);
        }

        [Fact]
        public void EndsWith_DefaultIs_CaseSensitive()
        {
            Assert.Throws<EndsWithException>(
                () => Assert.EndsWith("String", "anySTRING")
            );
        }

        [Fact]
        public void EndsWith_WithComparison()
        {
            Assert.EndsWith("String", "anySTRING", StringComparison.CurrentCultureIgnoreCase);
        }

        [Fact]
        public void EndsWith_ThrowsException_WhenStringIsNull()
        {
            string inString = null;

            Assert.Throws<EndsWithException>(
                () => Assert.EndsWith("String", inString)
            );
        }

        [Theory]
        [InlineData("[0-9]",  "1")]
        [InlineData("[0-9]*", "")]
        [InlineData("[0-9]+", "123")]
        public void MatchesString(string pattern, string inString)
        {
            Assert.Matches(pattern, inString);
        }

        [Fact]
        public void MatchesString_ThrowsException_WhenStringIsNull()
        {
            string inString = null;

            Assert.Throws<MatchesException>(
                () => Assert.Matches("[0-9]", inString)
            );
        }

        [Fact]
        public void MatchesRegex()
        {
            Assert.Matches(new Regex("[0-9]+"), "1234");
        }

        [Fact]
        public void MatchesRegex_ThrowsException_WhenStringIsNull()
        {
            string inString = null;

            Assert.Throws<MatchesException>(
                () => Assert.Matches(new Regex("[0-9]+"), inString)
            );
        }

        [Theory]
        [InlineData("[0-9]",  "a")]
        [InlineData("[0-9]+", "abc")]
        public void DoesNotMatchString(string pattern, string inString)
        {
            Assert.DoesNotMatch(pattern, inString);
        }

        [Fact]
        public void DoesNotMatchString_DoesNotThrowException_WhenStringIsNull()
        {
            string inString = null;
            Assert.DoesNotMatch("[0-9]", inString);
        }

        [Fact]
        public void DoesNotMatchRegex()
        {
            Assert.DoesNotMatch(new Regex("[0-9]+"), "abc");
        }

        [Fact]
        public void DoesNotMatchRegex_DoesNotThrowException_WhenStringIsNull()
        {
            string inString = null;
            Assert.DoesNotMatch(new Regex("[0-9]+"), inString);
        }

        [Theory]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("string", "string")]
        [InlineData("str\ning", "str\ning")]
        public void Equal(string expected, string actual)
        {
            Assert.Equal(expected, actual);
            Assert.Equal(actual, expected);
        }

        [Fact]
        public void Equal_DefaultIs_CaseSensitive()
        {
            Assert.Throws<EqualException>(
                () => Assert.Equal("string", "STRING")
            );
        }

        [Fact]
        public void Equal_IgnoreCase()
        {
            Assert.Equal("string", "STRING", ignoreCase : true);
        }

        [Theory]
        [InlineData("str\ning",   "str\r\ning")]
        [InlineData("str\ning",   "str\ring")]
        [InlineData("str\ring",   "str\r\ning")]
        [InlineData("str\ring",   "str\ning")]
        [InlineData("str\r\ning", "str\ring")]
        [InlineData("str\r\ning", "str\ning")]
        public void Equal_IgnoreLineEnding(string expected, string actual)
        {
            Assert.Equal(expected, actual, ignoreLineEndingDifferences : true);
        }

        [Theory]
        [InlineData(" ",       "\t")]
        [InlineData("str ing", "str\ting")]
        public void Equal_IgnoreSpaces(string expected, string actual)
        {
            Assert.Equal(expected, actual, ignoreWhiteSpaceDifferences : true);
        }

        [Fact]
        public void Equal_ThrowsException_WhenStringIsNull()
        {
            string inString = null;

            Assert.Throws<EqualException>(
                () => Assert.Equal("string", inString)
            );
        }
    }
}