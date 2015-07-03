using NUnit.Framework;

namespace OptionSharp.Net
{
    public class Equality
    {

        [Test]
        public void TwoOptionalsOfTheSameValueAreEqual()
        {
            var a = Optional.Of(10);
            var b = Optional.Of(10);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void AnOptionalIsNotEqualToAnUntypedAbsent()
        {
            var a = Optional.Of(10);
            var b = Optional.Absent;

            Assert.That(a, Is.Not.EqualTo(b));
        }

        [Test]
        public void AnOptionalIsNotEqualToAnAbsent()
        {
            var a = Optional.Of(10);
            var b = Optional.Absent;

            Assert.That(a, Is.Not.EqualTo(b));
        }

        [Test]
        public void TwoAbsentAreEqual()
        {
            var a = Optional.Absent;
            var b = Optional.Absent;

            Assert.That(a, Is.EqualTo(b));
        }
    }
}
