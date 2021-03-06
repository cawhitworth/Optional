﻿using NUnit.Framework;
using OptionSharp;

namespace OptionalSharp.Test
{
    public class Presence
    {
        [Test]
        public void AnOptionalOfIntIsPresent()
        {
            var a = Optional.Of(1);

            Assert.That(a.IsPresent, Is.True);
        }

        [Test]
        public void AnAbsentIsNotPresent()
        {
            var a = Optional.Absent;
            Assert.That(a.IsPresent, Is.False);
        }
    }
}