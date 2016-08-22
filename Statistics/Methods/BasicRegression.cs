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

using System;
using System.Linq;

namespace Statistics.Methods
{
    public class BasicRegression : IRegressionMethod
    {
        private decimal b0;
        private decimal b1;
        private decimal rValue;
        private decimal rSquared;

        public decimal[] Coefs
        {
            get
            {
                return new decimal[] { b0, b1 };
            }
        }

        public decimal[] RSquaredValues
        {
            get
            {
                return new decimal[] { rSquared };
            }
        }

        public decimal[] RValues
        {
            get
            {
                return new decimal[] { rValue };
            }
        }

        public void Compute(decimal[] y, params decimal[][] xn)
        {
            if (y == null) throw new ArgumentNullException("y");
            if (xn == null) throw new ArgumentNullException("xn");
            if (xn.Length > 1) throw new ArgumentException("Number of arrays is more than 1.");
            if (y.Length != xn[0].Length) throw new DifferentLengthException();

            decimal[] x = xn[0];

            int N = x.Length;
            decimal xAverage = x.Average();
            decimal yAverage = y.Average();
            decimal sx2 = MathUtils.Pow(x, 2) / N - Math.Pow(xAverage.ToDouble(), 2).ToDecimal();
            decimal xy = MathUtils.MultiplyArrays(x, y);
            decimal covariation = xy / N - xAverage * yAverage;
            b1 = covariation / sx2;
            b0 = yAverage - b1 * xAverage;
            rValue = b1 * (MathUtils.GetStandardDeviation(x) / MathUtils.GetStandardDeviation(y));
            rSquared = Math.Pow(rValue.ToDouble(), 2).ToDecimal();
        }
    }
}
