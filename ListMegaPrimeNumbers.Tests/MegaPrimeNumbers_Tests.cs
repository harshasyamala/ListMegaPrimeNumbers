using NUnit.Framework;
using ListMegaPrimeNumbers;
using System.Collections.Generic;
using System.Linq;

namespace ListMegaPrimeNumbers.Tests
{
    [TestFixture]
    public class MegaPrimeNumbers_Tests
    {

        private MegaPrimeNumbers _MegaPrimeNumbers_Service;

        [SetUp]
        public void SetUp()
        {
            _MegaPrimeNumbers_Service = new MegaPrimeNumbers();
        }

        [Test]
        public void TestMegaPrimeNumbers_ZeroAsInput_ReturnsEmptyArray()
        {
            uint input = 0;
            var result = _MegaPrimeNumbers_Service.FindMegaPrimeNumbersV2(input).Count();
            Assert.IsTrue(result == 0, $"{result} number of MegaPrimenumbers are present for {input}");
        }

        [Test]
        public void TestMegaPrimeNumbers_OneAsInput_ReturnsEmptyArray()
        {
            uint input = 1;
            var result = _MegaPrimeNumbers_Service.FindMegaPrimeNumbersV2(input).Count();
            Assert.IsTrue(result == 0, $"{result} number of MegaPrimenumbers are present for {input}");
        }

        [Test]
        public void TestMegaPrimeNumbers_TwoAsInput_ReturnsArrayWithDigit2()
        {
            uint input = 2;
            var result = _MegaPrimeNumbers_Service.FindMegaPrimeNumbersV2(input).Count();
            Assert.IsTrue(result == 1, $"{result} number of MegaPrimenumbers are present for {input}");
        }

        [Test]
        public void TestIsPrimeNumbers_ZeroAsInput_ReturnsEmptyArray()
        {
            uint input = 0;
            var result = _MegaPrimeNumbers_Service.FindMegaPrimeNumbersV2(input).Count();
            Assert.IsTrue(result == 0, $"{result} number of MegaPrimenumbers are present for {input}");
        }

        [Test]
        public void TestIsPrimeNumbers_OneAsInput_ReturnsEmptyArray()
        {
            uint input = 1;
            var result = _MegaPrimeNumbers_Service.FindMegaPrimeNumbersV2(input).Count();
            Assert.IsTrue(result == 0, $"{result} number of MegaPrimenumbers are present for {input}");
        }

        [Test]
        public void TestIsPrimeNumbers_TwoAsInput_ReturnsArrayWithDigit2()
        {
            uint input = 2;
            var result = _MegaPrimeNumbers_Service.FindMegaPrimeNumbersV2(input).Count();
            Assert.IsTrue(result == 1, $"{result} number of MegaPrimenumbers are present for {input}");
        }

        [Test]
        public void TestGetRange_RandomNumberAsInput_ReturnsArrayWithAllPrimes()
        {
            uint input = 1000;
            var result = _MegaPrimeNumbers_Service.FindMegaPrimeNumbersV2(input).Count();
            Assert.IsTrue(result > 0, $"{result} number of MegaPrimenumbers are present for {input}");
        }        

        [Test]
        public void TestGetRange_ZeroAsInput_ReturnsArrayWithAllPrimes()
        {
            uint input = 1;
            var result = _MegaPrimeNumbers_Service.FindMegaPrimeNumbersV2(input).Count();
            Assert.IsTrue(result == 0, $"{result} number of MegaPrimenumbers are present for {input}");
        }

        [Test]
        public void TestGetDigits_RandomNumberAsInput_ReturnsArrayWithAllPrimes()
        {
            uint input = 123456;
            var result = _MegaPrimeNumbers_Service.FindMegaPrimeNumbersV2(input).Count();
            Assert.IsTrue(result > 0, $"{result} number of MegaPrimenumbers are present for {input}");
        }

        //[Test]
        //public void TestGetRange_MaxAsInput_ReturnsArrayWithAllPrimes()
        //{
        //    uint input = uint.MaxValue;
        //    var result = _MegaPrimeNumbers_Service.FindMegaPrimeNumbersV2(input).Count();
        //    Assert.IsTrue(result > 0, $"{result} number of MegaPrimenumbers are present for {input}");
        //}

    }
}