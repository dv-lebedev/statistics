/*
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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Statistics.Models;
using System;

namespace Statistics.UnitTest.Models
{
    [TestClass]
    public class LinearRegressionTest
    {
        [TestMethod]
        public void Test()
        {
            decimal[] x = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            decimal[] y = { 60, 61, 62, 63, 64, 65, 66, 67, 68, 69 };


            try
            {
                var modelDara = new LinearRegression(null, y);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("x", ex.ParamName);
            }


            try
            {
                var modelDara = new LinearRegression(x, null);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("y", ex.ParamName);
            }


            try
            {
                var modelDara = new LinearRegression(x, new decimal[] { 1, 3, 5, -100 });
            }
            catch (Exception ex)
            {
                Assert.AreEqual(typeof(DifferentLengthException), ex.GetType());
            }


            var regression = new LinearRegression(x, y);

            Assert.AreEqual(1, (double)regression.RValue, 0.0000001);
            Assert.AreEqual(1, (double)regression.RSquared, 0.0000001);
            Assert.AreEqual(59, (double)regression.Alpha, 0.0000001);
            Assert.AreEqual(1, (double)regression.Beta, 0.0000001);
        }
    }
}
