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

namespace Statistics.UnitTest
{
    [TestClass]
    public class BasicFuncsTest
    {
        [TestMethod]
        public void GetErrorTest()
        {
            decimal[] values = { 1, 2, 5, 7, 4, 6, 5, -3, 65, 2, -45, -4, 309.007773M };

            decimal[] expected = { 1, 3, 2, -3, 2, -1, -8, 68, -63, -47, 41, 313.007773M };

            var errorValues = MathUtils.GetError(values);

            for (int i = 0; i < values.Length - 1; i++)
            {
                Assert.AreEqual((double)expected[i], (double)errorValues[i], 0.001);
            }
        }

        [TestMethod]
        public void GetStandardDeviationTest()
        {
            decimal[] values = { 1, 3, 5, 7 };


            decimal result = MathUtils.GetStandardDeviation(values);

            Assert.AreEqual(2.5819, (double)result, 0.0001);


            values = new decimal[] { 1, 2, 4, 5 };

            result = MathUtils.GetStandardDeviation(values);

            Assert.AreEqual(1.8257, (double)result, 0.0001);
        }

        [TestMethod]
        public void MultiplyArraysTest()
        {
            decimal[] x = { 1, 3, 5, 7, 9, 11, 15, 17, 19, 35 };

            decimal[] y = { -1001, 2, 6, 98, 23, -56, -34, 56, -345, 7 };

            Assert.AreEqual(true, x.Length == y.Length);


            decimal result = MathUtils.MultiplyArrays(x, y);

            Assert.AreEqual(-6556, result);
        }


        [TestMethod]
        public void PowArrayTest()
        {
            decimal[] values = { 12, 65, 83, 55, 100, 248, 201, 0, 0, -3, -255 };


            decimal result = MathUtils.PowArray(values);

            Assert.AreEqual(191222, result);
        }
    }
}
