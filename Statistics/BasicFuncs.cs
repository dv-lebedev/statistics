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

namespace Statistics
{
    public static class BasicFuncs
    {
        public static decimal[] GetError(decimal[] values)
        {
            decimal[] result = new decimal[values.Length - 1];

            for (int i = 1; i < values.Length; i++)
            {
                result[i - 1] = values[i] - values[i - 1];
            }

            return result;
        }

        public static decimal GetStandardDeviation(decimal[] values)
        {
            if (values == null) throw new ArgumentNullException("values");

            double[] arr = values.Select(i => (double)i).ToArray();

            double result = 0;

            double average = arr.Average();

            for (int i = 0; i < arr.Length; i++)
            {
                result += Math.Pow(arr[i] - average, 2);
            }
            return (decimal)Math.Sqrt(result /= (arr.Length -1 ));
        }

        public static decimal MultiplyArrays(decimal[] x, decimal[] y)
        {
            if (x == null) throw new ArgumentNullException("x");
            if (y == null) throw new ArgumentNullException("y");

            if (x.Length != y.Length)
                throw new DifferentLengthException();

            decimal result = 0;

            for (int i = 0; i < x.Length; i++)
            {
                result += x[i] * y[i];
            }

            return result;
        }

        public static decimal PowArray(decimal[] values)
        {
            if (values == null) throw new ArgumentNullException("values");

            double result = 0;

            for (int i = 0; i < values.Length; i++)
            {
                result += Math.Pow((double)values[i], 2);
            }

            return (decimal)result;
        }
    }
}
