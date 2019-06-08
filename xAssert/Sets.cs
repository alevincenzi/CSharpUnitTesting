using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Sdk;

namespace CSharpUnitTesting.xAssert
{
    public class Sets
    {
        private readonly HashSet<string> _ab;
        private readonly HashSet<string> _abc;
        private readonly HashSet<string> _abcd;
        
        public Sets()
        {
            _ab   = new HashSet<string>() {"a", "b"};
            _abc  = new HashSet<string>() {"a", "b", "c"};
            _abcd = new HashSet<string>() {"a", "b", "c", "d"};
        }

        [Fact]
        public void Subset()
        {
            Assert.Subset(_abc, _ab);
            Assert.ProperSubset(_abc, _ab);

            Assert.Throws<SupersetException>(
                () => Assert.Superset(_abc, _ab)
            );
            Assert.Throws<ProperSupersetException>(
                () => Assert.ProperSuperset(_abc, _ab)
            );
        }

        [Fact]
        public void SameSet()
        {
            Assert.Subset(_abc, _abc);

            Assert.Throws<ProperSubsetException>(
                () => Assert.ProperSubset(_abc, _abc)
            );

            Assert.Superset(_abc, _abc);

            Assert.Throws<ProperSupersetException>(
                () => Assert.ProperSuperset(_abc, _abc)
            );
        }

        [Fact]
        public void Superset()
        {
            Assert.Superset(_abc, _abcd);
            Assert.ProperSuperset(_abc, _abcd);

            Assert.Throws<SubsetException>(
                () => Assert.Subset(_abc, _abcd)
            );
            Assert.Throws<ProperSubsetException>(
                () => Assert.ProperSubset(_abc, _abcd)
            );
        }
    }
}