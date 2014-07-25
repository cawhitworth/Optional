using NUnit.Framework;

namespace Optional
{
    public class Mapping
    {
        [Test]
        public void MappingToPresentIsValid()
        {
            var a = Optional.Of(1);

            var b = a.Map(i => i + 1);

            Assert.That(b, Is.EqualTo(Optional.Of(2)));
        }

    }
}
