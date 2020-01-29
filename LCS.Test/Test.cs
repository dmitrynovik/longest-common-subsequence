using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace LCS.Test
{
    [TestFixture]
    public class LCSTest
    {
        [Test]
        public void LCS_of_2_null_strings_is_empty() => Compute(null, null).Should().BeEmpty();

        [Test]
        public void LCS_of_2_empty_strings_is_empty() => Compute("", "").Should().BeEmpty();

        [Test]
        public void LCS_of_1_empty_string_is_empty() => Compute("ABCD", "").Should().BeEmpty();

        [Test]
        public void LCS_of_10010101_and_BDCABA_is_BCBA() => Compute("10010101", "010110110").Should().Be("100110");

        [Test]
        public void LCS_of_ABCBDAB_and_BDCABA_is_BCBA() => Compute("ABCBDAB", "BDCABA").Should().Be("BCBA");

        [Test]
        public void LCS_of_ACCGGTCGAGTGCGCGGAAGCCGGCCGAA_and_GTCGTTCGGAATGCCGTTGCTCTGTAAA_is_GTCGTCGGAAGCCGGCCGAA() => 
            Compute("ACCGGTCGAGTGCGCGGAAGCCGGCCGAA", "GTCGTTCGGAATGCCGTTGCTCTGTAAA").Should().Be("GTCGTCGGAAGCCGGCCGAA");

        private string Compute(string x, string y) => LongestCommonSubsequence.Compute(x, y);
    }
}
