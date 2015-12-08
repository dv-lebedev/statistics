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
    public class AutoRegressionTest
    {
        [TestMethod]
        public void AutoTest()
        {
            decimal[] vector =
            {
                345113,
                441452,
                544153,
                720731,
                948056,
                913345,
                1082569,
                1302079,
                1459096
            };

            var autoRegression = new AutoRegression(vector, 1);

            Assert.AreEqual(113436.67, (double)autoRegression.Alpha, 0.01);
            Assert.AreEqual(1.0327, (double)autoRegression.Beta, 0.001);
            Assert.AreEqual(0.9713, (double)autoRegression.RValue, 0.001);
            Assert.AreEqual(0.9434, (double)autoRegression.RSquared, 0.001);
        }
    }
}
