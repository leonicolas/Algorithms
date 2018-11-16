using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Algorithms
{
    public class ArrayIncrementProblem
    {
        public static int[] Increment(int[] value)
        {
            if (value == null || value.Length <= 0)
            {
                return value;
            }

            int length = value.Length;
            int position = length;
            int increment = 1;
            int maxNumber = 9;

            while (position > 0)
            {
                position--;

                int number = value[position];
                int result = number + increment;

                if (result > maxNumber)
                {
                    increment = 1;
                    value[position] = 0;
                }
                else
                {
                    increment = 0;
                    value[position] = result;
                }

                if (position == 0 &&
                    result > maxNumber &&
                    result % maxNumber > 0)
                {

                    int[] arr = new int[length + 1];
                    arr[0] = 1;

                    return arr;
                }
            };

            return value;
        }
    }

    [TestClass]
    public class ArrayIncrementProblemTests
    {
        [TestMethod]
        public void Should_return_null_when_argument_is_null()
        {
            int[] sequence = null;
            int[] result = ArrayIncrementProblem.Increment(sequence);
            result.Should().BeNull();
        }

        [TestMethod]
        public void Should_return_empty_when_argument_is_enpty()
        {
            int[] sequence = new int[] { };
            int[] expectedSequence = new int[] { };
            int[] result = ArrayIncrementProblem.Increment(sequence);
            Enumerable.SequenceEqual(result, expectedSequence).Should().BeTrue();
        }

        [TestMethod]
        public void After_incrementing_it_must_have_the_expected_sequence_1()
        {
            int[] sequence = new int[] { 1, 0 };
            int[] expectedSequence = new int[] { 1, 1 };
            int[] result = ArrayIncrementProblem.Increment(sequence);
            Enumerable.SequenceEqual(result, expectedSequence).Should().BeTrue();
        }

        [TestMethod]
        public void After_incrementing_it_must_have_the_expected_sequence_2()
        {
            int[] sequence = new int[] { 1, 3 };
            int[] expectedSequence = new int[] { 1, 4 };
            int[] result = ArrayIncrementProblem.Increment(sequence);
            Enumerable.SequenceEqual(result, expectedSequence).Should().BeTrue();
        }

        [TestMethod]
        public void After_incrementing_it_must_have_the_expected_sequence_3()
        {
            int[] sequence = new int[] { 1, 8 };
            int[] expectedSequence = new int[] { 1, 9 };
            int[] result = ArrayIncrementProblem.Increment(sequence);
            Enumerable.SequenceEqual(result, expectedSequence).Should().BeTrue();
        }

        [TestMethod]
        public void After_incrementing_it_must_have_the_expected_sequence_4()
        {
            int[] sequence = new int[] { 1, 9 };
            int[] expectedSequence = new int[] { 2, 0 };
            int[] result = ArrayIncrementProblem.Increment(sequence);
            Enumerable.SequenceEqual(result, expectedSequence).Should().BeTrue();
        }

        [TestMethod]
        public void After_incrementing_it_must_have_the_expected_sequence_5()
        {
            int[] sequence = new int[] { 9, 9 };
            int[] expectedSequence = new int[] { 1, 0, 0 };
            int[] result = ArrayIncrementProblem.Increment(sequence);
            Enumerable.SequenceEqual(result, expectedSequence).Should().BeTrue();
        }

        [TestMethod]
        public void After_incrementing_it_must_have_the_expected_sequence_6()
        {
            int[] sequence = new int[] { 8, 9, 9 };
            int[] expectedSequence = new int[] { 9, 0, 0 };
            int[] result = ArrayIncrementProblem.Increment(sequence);
            Enumerable.SequenceEqual(result, expectedSequence).Should().BeTrue();
        }

        [TestMethod]
        public void After_incrementing_it_must_have_the_expected_sequence_7()
        {
            int[] sequence = new int[] { 9, 9, 9, 8, 9, 9, 9, 9, 9 };
            int[] expectedSequence = new int[] { 9, 9, 9, 9, 0, 0, 0, 0, 0 };
            int[] result = ArrayIncrementProblem.Increment(sequence);
            Enumerable.SequenceEqual(result, expectedSequence).Should().BeTrue();
        }

        [TestMethod]
        public void After_incrementing_it_must_have_the_expected_sequence_8()
        {
            int[] sequence = new int[] { 9, 9, 9, 9, 9, 9, 9, 9, 9 };
            int[] expectedSequence = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] result = ArrayIncrementProblem.Increment(sequence);
            Enumerable.SequenceEqual(result, expectedSequence).Should().BeTrue();
        }


        [TestMethod]
        public void After_incrementing_it_must_have_the_expected_sequence_9()
        {
            int[] sequence = new int[] { 8, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9 };
            int[] expectedSequence = new int[] { 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] result = ArrayIncrementProblem.Increment(sequence);
            Enumerable.SequenceEqual(result, expectedSequence).Should().BeTrue();
        }
    }
}