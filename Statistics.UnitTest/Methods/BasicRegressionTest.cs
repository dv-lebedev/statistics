/*
Copyright 2015-2016 Denis Lebedev

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
using Statistics.Methods;
using Statistics.Models;

namespace Statistics.UnitTest.Methods
{
    [TestClass]
    public class BasicRegressionTest
    {
        [TestMethod]
        public void BasicReg_Test()
        {
            decimal[] x = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            decimal[] y = { 8, 6, 10, 6, 10, 13, 9, 11, 15, 17 };

            var linearRegression = new LinearRegression();
            linearRegression.RegressionMethod = new BasicRegression();

            linearRegression.Compute(x, y);

            Assert.AreEqual(0.8141, (double)linearRegression.RValue, 0.0001);
            Assert.AreEqual(0.6628, (double)linearRegression.RSquared, 0.0001);
            Assert.AreEqual(5.1333, (double)linearRegression.Alpha, 0.0001);
            Assert.AreEqual(0.9757, (double)linearRegression.Beta, 0.0001);
        }
    }
}
