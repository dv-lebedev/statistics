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

namespace Statistics
{
    public class OrdinaryLeastSquares : IRegressionMethod
    {
        public decimal[] Coefs { get; protected set; }

        public decimal[] RValues { get; protected set; }

        public decimal[] RSquaredValues { get; protected set; }

        public OrdinaryLeastSquares() { }

        public void Compute(decimal[] y, params decimal[][] xn)
        {
            decimal[] ones = new decimal[xn[0].Length];

            for (int i = 0; i < xn[0].Length; i++)
            {
                ones[i] = 1;
            }

            decimal[][] matrix = new decimal[xn.Length + 1][];

            matrix[0] = ones;

            for (int i = 1; i < matrix.Length; i++)
            {
                matrix[i] = xn[i - 1];
            }

            Matrix nMatrix = new Matrix(matrix);

            var XX = nMatrix.ByMatrix();

            decimal[] vector = nMatrix.GetVector(y);

            Coefs = XX.Inverse().VectorProduct(vector);

            RValues = new decimal[Coefs.Length - 1];
            RSquaredValues = new decimal[Coefs.Length - 1];

            decimal ySd = BasicFuncs.GetStandardDeviation(y);

            for (int i = 0; i < RValues.Length; i++)
            {
                RValues[i] = Coefs[i + 1] * (BasicFuncs.GetStandardDeviation(xn[i]) / ySd);

                RSquaredValues[i] = (decimal)Math.Pow((double)RValues[i], 2);
            }

        }
    }
}
