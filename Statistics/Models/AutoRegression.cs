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
    public class AutoRegression : IRegression
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

        public AutoRegression()
        {
            RegressionMethod = new OrdinaryLeastSquares();
        }

        public void Compute(decimal[] vectror, int lag)
        {
            if (vectror == null)
                throw new ArgumentNullException("vector");

            if (lag >= vectror.Length)
                throw new IndexOutOfRangeException("lag can't be more or equal x.Length");

            decimal[] x = new decimal[vectror.Length - lag];

            for(int i = 0; i < vectror.Length - lag; i++ )
            {
                x[i] = vectror[i];
            }

            decimal[] y = new decimal[vectror.Length - lag];

            for (int i = lag; i < vectror.Length; i++)
            {
                y[i - lag] = vectror[i];
            }

            RegressionMethod.Compute(y, x);
        }
    }
}
