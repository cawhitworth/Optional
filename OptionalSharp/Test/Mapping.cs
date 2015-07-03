using System;
using NUnit.Framework;
using OptionSharp;

namespace OptionalSharp.Test
{
    public class Mapping
    {

        [Test]
        public void MappingToPresentIsValid()
        {
            var a = Optional.Of(1);

            var b = a.Map( i => i + 1);

            Assert.That(b, Is.EqualTo(Optional.Of(2)));
        }

        [Test]
        public void MappingAnAbsentReturnsAnAbsent()
        {
            var a = Optional.Absent;

            var b = a.Map( (int i) => i + 1);

            Assert.That(b, Is.EqualTo(Optional.Absent));
        }

        [Test]
        public void FlatMappingToPresentIsValid()
        {
            var a = Optional.Of(1);
            var b = a.FlatMap( i => Optional.Of(i + 1));

            Assert.That(b, Is.EqualTo(Optional.Of(2)));
        }

        [Test]
        public void FlatMappingAbsentReturnsAbsent()
        {
            var a = Optional.Absent;

            var b = a.FlatMap((int i) => Optional.Of(i + 1));

            Assert.That(b, Is.EqualTo(Optional.Absent));
        }

        [Test]
        public void FlatMappingCanReturnAnAbsent()
        {
            var a = Optional.Of(1);
            var b = a.FlatMap(i => Optional.AbsentOf<int>());

            Assert.That(b, Is.EqualTo(Optional.Absent));
        }

        [Test]
        public void MappingDoesNotRequireTheSameTypeOnBothSides()
        {
            var a = Optional.Of(1);
            var b = a.Map(i => i.ToString());

            Assert.That(b, Is.EqualTo( Optional.Of("1")));
        }

        [Test]
        public void FlatMappingDoesNotRequireTheSameTypeOnBothSides()
        {
            var a = Optional.Of(1);
            var b = a.FlatMap(i => Optional.Of( String.Format("It is {0}", i) ));

            Assert.That(b, Is.EqualTo( Optional.Of("It is 1")));
        }

        [Test]
        public void MapThroughReturnsTheSameOptional()
        {
            var a = Optional.Of(1);
            var b = a.MapThrough(i => { });
            Assert.That(b, Is.EqualTo(a));
        }

        [Test]
        public void MapThroughPassesValueIntoFunction()
        {
            var value = 1;
            var pass = false;
            var a = Optional.Of(value);
            a.MapThrough(i =>
            {
                Assert.That(i, Is.EqualTo(value));
                pass = true;
            });
            Assert.That(pass, Is.True, "MapThrough function was not called");
        }

        [Test]
        public void MapThroughOfAbsentReturnsAbsent()
        {
            var a = Optional.AbsentOf<int>();
            var b = a.MapThrough(i => { });

            Assert.That(b, Is.EqualTo(Optional.Absent));
        }

        [Test]
        public void MapThroughOfAbsentDoesNotCallFunction()
        {
            var a = Optional.AbsentOf<int>();
            var b = a.MapThrough(i => { Assert.Fail("This should never be called"); });
        }
    }
}
