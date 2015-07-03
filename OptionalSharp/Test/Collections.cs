using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace OptionSharp.Net
{
    public class Collections
    {
        [Test]
        public void CanMapOverACollection()
        {
            var l = new List<IOptional<int>>
            {
                Optional.Of(1),
                Optional.Of(2),
                Optional.Of(3)
            };

            var result = l.Select(o => o.Map( i=> i+1) );

            var expected = new List<IOptional<int>>
            {
                Optional.Of(2),
                Optional.Of(3),
                Optional.Of(4)
            };

            Assert.That(result, Is.EquivalentTo(expected));
        }

        [Test]
        public void Reduce()
        {
            var l = new List<IOptional<int>>
            {
                Optional.Of(1),
                Optional.Of(2),
                Optional.Of(3)
            };

            var result = l.Aggregate(Optional.Of(0),
                (acc, item) => acc.Match(
                    accValue => item.Map( itemValue => accValue + itemValue ),
                    Optional.AbsentOf<int>
                ));

            Assert.That(result, Is.EqualTo(Optional.Of(6)));
        }

        [Test]
        public void ReduceWithAbsent()
        {
            var l = new List<IOptional<int>>
            {
                Optional.Of(1),
                Optional.AbsentOf<int>(),
                Optional.Of(2),
                Optional.Of(3)
            };

            var result = l.Aggregate(Optional.Of(0),
                (acc, item) => acc.Match(
                    accValue => item.Map( itemValue => accValue + itemValue ),
                    Optional.AbsentOf<int>
                ));
            
            Assert.That(result, Is.EqualTo(Optional.Absent));
        }

    }
}