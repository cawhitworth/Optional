using System;
using NUnit.Framework;

namespace Optional
{
    public class Matching
    {
        [Test]
        public void MatchingOnAPresentExecutesTheRightCode()
        {
            var a = Optional.Of(1);

            var result = a.Match(
                v => true,
                () => { throw new Exception("Wrong code path taken"); }
            );

            Assert.That(result, Is.True);
        }

        
        [Test]
        public void MatchingOnAnAbsentExecutesTheRightCode()
        {
            var a = Optional.Absent;

            var result = a.Match(
                (int v) => { throw new Exception("Wrong code path taken"); },
                () => true
            );

            Assert.That(result, Is.True);
        }
    }
}