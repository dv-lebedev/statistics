﻿/*
Copyright 2015 Denis Lebedev

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Statistics.UnitTest
{
    [TestClass]
    public class BasicFuncsTest
    {

        [TestMethod]
        public void GetStandardDeviationTest()
        {
            decimal[] values = { 1, 3, 5, 7 };


            decimal result = BasicFuncs.GetStandardDeviation(values);

            Assert.AreEqual(2.5819, (double)result, 0.0001);


            values = new decimal[] { 1, 2, 4, 5 };

            result = BasicFuncs.GetStandardDeviation(values);

            Assert.AreEqual(1.8257, (double)result, 0.0001);

        }


        [TestMethod]
        public void MultiplyArraysTest()
        {
            decimal[] x = { 1, 3, 5, 7, 9, 11, 15, 17, 19, 35 };

            decimal[] y = { -1001, 2, 6, 98, 23, -56, -34, 56, -345, 7 };

            Assert.AreEqual(true, x.Length == y.Length);


            decimal result = BasicFuncs.MultiplyArrays(x, y);

            Assert.AreEqual(-6556, result);
        }


        [TestMethod]
        public void PowArrayTest()
        {
            decimal[] values = { 12, 65, 83, 55, 100, 248, 201, 0, 0, -3, -255 };


            decimal result = BasicFuncs.PowArray(values);

            Assert.AreEqual(191222, result);
        }
    }
}