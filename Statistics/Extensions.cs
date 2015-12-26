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

namespace Statistics
{
    public static class Extensions
    { 
        public static double ToDouble(this decimal value)
        {
            return (double)value;
        }

        public static decimal ToDecimal(this double value)
        {
            return (decimal)value;
        }

        public static double[] ToDouble(this decimal[] array)
        {
            int size = array.Length;

            double[] result = new double[size];

            for (int i = 0; i < size; i++)
            {
                result[i] = (double)array[i];
            }

            return result;
        }

        public static decimal[] ToDecimal(this double[] array)
        {
            int size = array.Length;

            decimal[] result = new decimal[size];

            for (int i = 0; i < size; i++)
            {
                result[i] = (decimal)array[i];
            }

            return result;
        }
    }
}
