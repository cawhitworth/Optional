using NUnit.Framework;

namespace Optional
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
    }
}
