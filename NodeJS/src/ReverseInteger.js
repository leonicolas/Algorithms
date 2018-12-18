let should = require('chai').should();

function reverseInteger(value) {
    if(!value) return 0;
    let retVal = 0;
    while(value !== 0) {
        retVal = retVal * 10 + value % 10;
        value = (value / 10) | 0;
    }
    let intEdge = Math.pow(2, 31);
    return retVal < -intEdge || retVal > intEdge - 1 ? 0 : retVal;
}

describe('PairSumInArrayProblem', function () {
    let intEdge = Math.pow(2, 31);
    let intMaxValue = intEdge - 1;
    let intMinValue = -intEdge;

    it('Should return zero when value is null or empty', function () {
        reverseInteger(null).should.be.equal(0);
        reverseInteger(undefined).should.be.equal(0);
    });

    it('Should return inverted int', function () {
        reverseInteger(0).should.be.equal(0);

        reverseInteger(1).should.be.equal(1);
        reverseInteger(-1).should.be.equal(-1);

        reverseInteger(10).should.be.equal(1);
        reverseInteger(-10).should.be.equal(-1);

        reverseInteger(123).should.be.equal(321);
        reverseInteger(-123).should.be.equal(-321);

        reverseInteger(123456789).should.be.equal(987654321);
        reverseInteger(-123456789).should.be.equal(-987654321);

        reverseInteger(999900).should.be.equal(9999);
        reverseInteger(-999900).should.be.equal(-9999);

        reverseInteger(9999001).should.be.equal(1009999);
        reverseInteger(-9999001).should.be.equal(-1009999);

        reverseInteger(7463847412).should.be.equal(intMaxValue);
        reverseInteger(-8463847412).should.be.equal(intMinValue);
    });

    it('Should return zero when overflow or underflow', function () {
        reverseInteger(intMaxValue).should.be.equal(0);
        reverseInteger(intMinValue).should.be.equal(0);

        reverseInteger(8463847412).should.be.equal(0);
        reverseInteger(-9463847412).should.be.equal(0);
    });
});
