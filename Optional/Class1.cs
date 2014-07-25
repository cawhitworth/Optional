using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Optional
{
    public class Tests
    {
        [Test]
        public void CanConstructAnOptionalOfInt()
        {
            var a = Optional.Of(1);
        }
    }


    public class Class1
    {
    }
}
