using Microsoft.VisualStudio.TestTools.UnitTesting;
using Statistics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics.UnitTest.Models
{
    [TestClass]
    public class MultipleLinearRegressionTest
    {
        [TestMethod]
        public void MultipleTest()
        {
            decimal[] y = { 0.9M, 1.7M, 0.7M, 1.7M, 2.6M, 1.3M, 4.1M, 1.6M, 6.9M, 0.4M };

            decimal[] x1 = { 31.3M, 13.4M, 4.5M, 10, 20, 15, 137.1M, 17.9M, 165.4M, 2 };
            decimal[] x2 = { 18.9M, 13.7M, 18.5M, 4.8M, 21.8M, 5.8M, 99, 20.1M, 60.6M, 1.4M };


            var mlr = new MultipleLinearRegression(y, x1, x2);

            Assert.AreEqual(1.0841, (double)mlr.Coefs[0], 0.0001);
            Assert.AreEqual(0.0431, (double)mlr.Coefs[1], 0.0001);
            Assert.AreEqual(-0.0261, (double)mlr.Coefs[2], 0.0001);

            Assert.AreEqual(0.9280, (double)mlr.RValues[0], 0.0001);
            Assert.AreEqual(0.7508, (double)mlr.RValues[1], 0.0001);

        }
    }
}
