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

using System;
using System.Linq;

namespace Statistics.Models
{
    public class LogitRegression : IRegression
    {

        public IRegressionMethod RegressionMethod { get; set; }

        public decimal[] Coefs
        {
            get { return RegressionMethod.Coefs; }
        }

        public decimal[] RValues
        {
            get { return RegressionMethod.RValues; }
        }

        public decimal[] RSquaredValues
        {
            get { return RegressionMethod.RSquaredValues; }
        }

        public LogitRegression()
        {
            RegressionMethod = new OrdinaryLeastSquares();
        }

        public void Compute(bool[] y, params decimal[][] xn)
        {
            RegressionMethod.Compute(y.Select(i => Convert.ToDecimal(i)).ToArray(), xn);
        }

        public decimal PredictValue(params decimal[] xValues)
        {
            if (xValues.Length != Coefs.Length - 1)
                throw new DifferentLengthException();

            decimal y = Coefs[0];

            for (int i = 0; i < xValues.Length; i++)
            {
                y += Coefs[i + 1] * xValues[i];
            }

            return (decimal)(1 / (1 + Math.Pow(Math.E, (double)-y)));
        }

        public bool TryPredictValue(out decimal result, params decimal[] xValues)
        {
            result = 0;

            if (xValues.Length == Coefs.Length - 1)
            {
                result = PredictValue(xValues);

                return true;
            }

            return false;
        }
    }
}
