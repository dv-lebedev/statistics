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

namespace Statistics.UnitTest.Models
{
    [TestClass]
    public class LogitRegressionTest
    {
        [TestMethod]
        public void LogitTest()
        {
            bool[] y = { true, true, true, false, true, false, false, true, false };
            decimal[] x = { 1, 3, 2, 23, 1, 36, 35, 5, 17 };

            var logitRegression = new LogitRegression(y, x);

            Assert.AreEqual(1.0089, (double)logitRegression.Coefs[0], 0.001);
            Assert.AreEqual(-0.0331, (double)logitRegression.Coefs[1], 0.001);
            Assert.AreEqual(-0.9170, (double)logitRegression.RValues[0], 0.001);
            Assert.AreEqual(0.8410, (double)logitRegression.RSquaredValues[0], 0.001);

            Assert.AreEqual(0.7262, (double)logitRegression.PredictValue(new decimal[] { 1 }), 0.001);
            Assert.AreEqual(0.0904, (double)logitRegression.PredictValue(new decimal[] { 100 }), 0.001);
        }
    }
}
