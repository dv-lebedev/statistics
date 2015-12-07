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
using System;

namespace Statistics.UnitTest
{
    [TestClass]
    public class MovingAveragesTest
    {
        [TestMethod]
        public void SMATest()
        {

            decimal[] values = { 1, 3, 5, 7, 9, 2, 4, 6, 8, 11, 13, 15, 24, 46, 68 };

            try
            {
                var smaResult = MovingAverages.SMA(values, 0);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("period <= 0", ex.Message);
            }


            try
            {
                var smaResult = MovingAverages.SMA(null, -1);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("values", ex.ParamName);
            }


            try
            {
                var result = MovingAverages.SMA(values, values.Length + 1);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("period > values.Lenght", ex.Message);
            }



            var sma5Result = MovingAverages.SMA(values, 5);

            decimal[] expectedValues = { 5, 5.2M, 5.4M, 5.6M, 5.8M, 6.2M, 8.4M, 10.6M, 14.2M, 21.8M, 33.2M };

            Assert.AreEqual(expectedValues.Length, sma5Result.Length);

            for (int i = 0; i < expectedValues.Length; i++)
            {
                Assert.AreEqual(expectedValues[i], sma5Result[i]);
            }

        }

        [TestMethod]
        public void WMATest()
        {
            decimal[] values = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 2, 3, 4, 5 };

            try
            {
                var smaResult = MovingAverages.WMA(values, 0);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("period <= 0", ex.Message);
            }


            try
            {
                var smaResult = MovingAverages.WMA(null, -1);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("values", ex.ParamName);
            }


            try
            {
                var result = MovingAverages.WMA(values, values.Length + 1);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("period > values.Lenght", ex.Message);
            }


            var wma3Result = MovingAverages.WMA(values, 3);

            double[] expectedValues = { 2.33, 3.33, 4.33, 5.33, 6.33, 7.33, 8.33, 4.83, 2.83, 2.33, 3.33, 4.33 };

            Assert.AreEqual(expectedValues.Length, wma3Result.Length);

            for (int i = 0; i < wma3Result.Length; i++)
            {
                Assert.AreEqual(expectedValues[i], (double)wma3Result[i], 0.01);
            }
        }

        [TestMethod]
        public void VMATest()
        {
            decimal[] values = { 11, 15, 19, 13, 14, 16, 23, 25, 29, 26, 35, 45 };
            long[] volumes = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };

            Assert.AreEqual(true, values.Length == volumes.Length);

            try
            {
                var smaResult = MovingAverages.VMA(values, volumes, 0);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("period <= 0", ex.Message);
            }


            try
            {
                var smaResult = MovingAverages.VMA(null, null, -1);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("values", ex.ParamName);
            }


            try
            {
                var smaResult = MovingAverages.VMA(values, null, -1);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("volumes", ex.ParamName);
            }


            try
            {
                var smaResult = MovingAverages.VMA(values, new long[] { 1, 3, 5 }, -1);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("values.Length != volumes.Length", ex.Message);
            }


            try
            {
                var result = MovingAverages.VMA(values, volumes, values.Length + 1);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("period > values.Lenght", ex.Message);
            }


            var sresult = MovingAverages.VMA(values, volumes, 4);

            double[] expectedValues = { 15, 14.9285, 15.2777, 17.2272, 20.2692, 23.9333, 25.9411, 29.1052, 34.4285 };

            Assert.AreEqual(expectedValues.Length, sresult.Length);

            for (int i = 0; i < expectedValues.Length; i++)
            {
                Assert.AreEqual(expectedValues[i], (double)sresult[i], 0.0001);
            }
        }
    }
}
