require('chai').should();

function hasPairSumInArray(values, sum) {
    return false;
}

describe('PairSumInArrayProblem', function () {
    it('Should return false when array or sum is null or empty', function () {
        hasPairSumInArray(null, null).should.be.false;
        hasPairSumInArray(null, 0).should.be.false;
        hasPairSumInArray(null, 10).should.be.false;

        hasPairSumInArray([], 0).should.be.false;
        hasPairSumInArray([], 10).should.be.false;
    });

    it('Should return false when sum pair is not found', function () {
        let bigArray = generateBigRandomArray();

        hasPairSumInArray([0], 0).should.be.false;
        hasPairSumInArray([7, 1, 7, 10, 2, 55, 31, 77], 15).should.be.false;
        hasPairSumInArray([1, 1, 1, 1, 1, 1, 1, 1], 3).should.be.false;
        hasPairSumInArray(bigArray, 999).should.be.false;
    });

    it('Should have a small execution time', function () {
        let bigArray = generateBigRandomArray();

        let startTime = new Date();
        hasPairSumInArray(bigArray, 999).should.be.false;
        let finishTime = new Date() - startTime;

        finishTime.should.be.below(800); // ms
    });

    it('Should return true when sum pair is found', function () {
        let bigArray = generateBigRandomArray();
        bigArray[100000] = 9;
        bigArray[500000] = 7;

        // Assert.
        hasPairSumInArray([0, 0], 0).should.be.true;
        hasPairSumInArray([7, 1, 7, 10, 2, 55, 31, 77], 57).should.be.true;
        hasPairSumInArray([1, 1, 1, 1, 1, 1, 1, 1], 2).should.be.true;
        hasPairSumInArray([1, 1, 1, 1, 998, 1, 1, 1], 999).should.be.true;
        hasPairSumInArray(bigArray, 16).should.be.true;
    });
});

function generateBigRandomArray() {
    return Array.from(Array(Math.pow(10, 6)))
        .map(() => Math.floor(Math.random() * 10) + 1);
}
