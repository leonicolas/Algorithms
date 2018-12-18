using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Algorithms
{
    public class RevertInteger
    {
        public static int Revert(long value)
        {
            long retVal = 0;
            while (value != 0)
            {
                retVal = retVal * 10 + value % 10;
                value /= 10;
            }
            return retVal < int.MinValue || retVal > int.MaxValue ? 0 : (int)retVal;
        }
    }

    [TestClass]
    public class RevertIntegerTest
    {
        [TestMethod]
        public void Should_Return_Reverted_Integer()
        {
            RevertInteger.Revert(0).Should().Be(0);

            RevertInteger.Revert(1).Should().Be(1);
            RevertInteger.Revert(-1).Should().Be(-1);

            RevertInteger.Revert(10).Should().Be(1);
            RevertInteger.Revert(-10).Should().Be(-1);

            RevertInteger.Revert(123).Should().Be(321);
            RevertInteger.Revert(-123).Should().Be(-321);

            RevertInteger.Revert(123456789).Should().Be(987654321);
            RevertInteger.Revert(-123456789).Should().Be(-987654321);

            RevertInteger.Revert(999900).Should().Be(9999);
            RevertInteger.Revert(-999900).Should().Be(-9999);

            RevertInteger.Revert(9999001).Should().Be(1009999);
            RevertInteger.Revert(-9999001).Should().Be(-1009999);

            RevertInteger.Revert(7463847412).Should().Be(int.MaxValue);
            RevertInteger.Revert(-8463847412).Should().Be(int.MinValue);
        }

        [TestMethod]
        public void Should_Return_Zero_When_Int_Overflow_And_Underflow()
        {
            RevertInteger.Revert(int.MinValue).Should().Be(0);
            RevertInteger.Revert(int.MaxValue).Should().Be(0);

            RevertInteger.Revert(8463847412).Should().Be(0);
            RevertInteger.Revert(-9463847412).Should().Be(0);
        }
    }
}
