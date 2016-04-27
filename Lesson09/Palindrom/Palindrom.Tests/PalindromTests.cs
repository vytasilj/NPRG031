using System;
using NUnit.Framework;

namespace Palindrom.Tests
{
    [TestFixture]
    public class PalindromTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetMaxLength_NullInput_ThrowException()
        {
            new Palindrom().GetMaxLength(null);
        }

        [Test]
        public void GetMaxLength_EmptyInput_ResultIsZero()
        {
            Assert.That(new Palindrom().GetMaxLength(""), Is.EqualTo(0));
        }

        [TestCase("aaa", Result = 3)]
        [TestCase("abab", Result = 3)]
        public int GetMaxLength_ValidInput_PositiveResult(string input)
        {
            int length = new Palindrom().GetMaxLength(input);
            Assert.That(length, Is.Positive);
            return length;
        }
    }
}
