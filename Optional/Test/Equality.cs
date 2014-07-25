using NUnit.Framework;

namespace Optional
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
        public void AnOptionalIsNotEqualToAnAbsentOfTheSameType()
        {
            var a = Optional.Of(10);
            var b = Optional.Absent<int>();

            Assert.That(a, Is.Not.EqualTo(b));
        }

        [Test]
        public void AnOptionalIsNotEqualToAnAbsentOfAnotherType()
        {
            var a = Optional.Of(10);
            var b = Optional.Absent<bool>();


            Assert.That(a, Is.Not.EqualTo(b));
        }

        [Test]
        public void TwoAbsentsOfTheSameTypeAreEqual()
        {
            var a = Optional.Absent<int>();
            var b = Optional.Absent<int>();

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void TwoAbsentsOfDifferentTypesAreEqual()
        {
            var a = Optional.Absent<int>();
            var b = Optional.Absent<bool>();

            Assert.That(a, Is.EqualTo(b));
        }
    }
}