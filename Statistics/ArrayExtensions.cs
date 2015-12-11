using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics
{
    public static class ArrayExtensions
    {
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
