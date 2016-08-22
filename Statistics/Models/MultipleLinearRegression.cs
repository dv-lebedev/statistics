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

using Statistics.Methods;

namespace Statistics.Models
{
    public class MultipleLinearRegression : IRegression
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

        public MultipleLinearRegression()
        {
            RegressionMethod = new OrdinaryLeastSquares();
        }

        public void Compute(decimal[] y, params decimal[][] xn)
        {
            RegressionMethod.Compute(y, xn);
        }
    }
}
