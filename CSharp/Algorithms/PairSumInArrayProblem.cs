using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class PairSumInArrayProblem
    {
        public bool HasPairSumInArray(int[] values, int sum)
        {
            return false;
        }
    }

    [TestClass]
    public class PairSumInArrayProblemTest
    {
        [TestMethod]
        public void Should_Return_False_If_Array_Is_Null_Or_Empty()
        {
            PairSumInArrayProblem suject = new PairSumInArrayProblem();

            suject.HasPairSumInArray(null, 0).Should().BeFalse();
            suject.HasPairSumInArray(null, 10).Should().BeFalse();

            suject.HasPairSumInArray(new int[] { }, 0).Should().BeFalse();
            suject.HasPairSumInArray(new int[] { }, 10).Should().BeFalse();
        }

        [TestMethod]
        public void Should_Return_False_If_Pair_Sum_Is_Not_Present()
        {
            // Arrange.
            int[] bigArray = this.GenerateBigRandomArray();
            PairSumInArrayProblem suject = new PairSumInArrayProblem();

            // Assert.
            suject.HasPairSumInArray(new int[] { 0 }, 0).Should().BeFalse();
            suject.HasPairSumInArray(new int[] { 7, 1, 7, 10, 2, 55, 31, 77 }, 15).Should().BeFalse();
            suject.HasPairSumInArray(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }, 3).Should().BeFalse();
            suject.HasPairSumInArray(bigArray, 999).Should().BeFalse();
        }

        [TestMethod]
        public void Should_Have_Small_Execution_Time()
        {
            // Arrange.
            int[] bigArray = this.GenerateBigRandomArray();
            PairSumInArrayProblem suject = new PairSumInArrayProblem();

            // Assert.
            suject.ExecutionTimeOf(s => s.HasPairSumInArray(bigArray, 999))
                .Should().BeLessOrEqualTo(TimeSpan.FromSeconds(1000));
        }

        [TestMethod]
        public void Should_Return_True_If_Pair_Sum_Is_Present()
        {
            // Arrange.
            int[] bigArray = this.GenerateBigRandomArray();
            bigArray[1_000_000] = 9;
            bigArray[5_000_000] = 7;
            PairSumInArrayProblem suject = new PairSumInArrayProblem();

            // Assert.
            suject.HasPairSumInArray(new int[] { 0, 0 }, 0).Should().BeTrue();
            suject.HasPairSumInArray(new int[] { 7, 1, 7, 10, 2, 55, 31, 77 }, 57).Should().BeTrue();
            suject.HasPairSumInArray(new int[] { 1, 1, 1, 1, 1, 1, 1, 1 }, 2).Should().BeTrue();
            suject.HasPairSumInArray(new int[] { 1, 1, 1, 1, 998, 1, 1, 1 }, 999).Should().BeTrue();
            suject.HasPairSumInArray(bigArray, 16).Should().BeTrue();
        }

        #region Test fixtures

        private int[] GenerateBigRandomArray()
        {
            Random rnd = new Random();
            int[] randomData = new int[10_000_000];
            for (int i = 0; i < randomData.Length; i++)
            {
                randomData[i] = rnd.Next() % 10;
            }
            return randomData;
        }

        #endregion
    }
}
