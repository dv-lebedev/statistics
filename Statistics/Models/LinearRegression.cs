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

namespace Statistics.Models
{
    public class LinearRegression : IRegression
    {
        public IRegressionMethod RegressionMethod { get; set; }

        public decimal Alpha
        {
            get { return RegressionMethod.Coefs[0]; }
        }

        public decimal Beta
        {
            get { return RegressionMethod.Coefs[1]; }
        }

        public decimal RValue
        {
            get { return RegressionMethod.RValues[0]; }
        }

        public decimal RSquared
        {
            get { return RegressionMethod.RSquaredValues[0]; }
        }

        public LinearRegression()
        {
            RegressionMethod = new OrdinaryLeastSquares();
        }

        public void Compute(decimal[] x, decimal[] y)
        {
            if (x == null) throw new ArgumentNullException("x");
            if (y == null) throw new ArgumentNullException("y");
            if (x.Length != y.Length) throw new DifferentLengthException();

            RegressionMethod.Compute(y, x);
        }
    }
}
