using FluentAssertions;
using NUnit.Framework;

namespace LCS.Test
{
    [TestFixture]
    public class LongestPalindromeSubsequenceTest
    {
        [Test]
        public void Character_Is_Carac() => Compute("character").Should().Be("carac");

        [Test]
        public void Civic_Is_Civic() => Compute("civic").Should().Be("civic");

        [Test]
        public void Aaaa_Is_Aaaa() => Compute("aaaa").Should().Be("aaaa");

        private string Compute(string x) => LongestPalindromeSusequence.Compute(x);
    }
}
