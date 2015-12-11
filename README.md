# statistics
Matrixes, moving averages, simple and multiple linear regressions etc.

![License](https://img.shields.io/badge/license-Apache 2.0-brightgreen.svg)
![.Net version](https://img.shields.io/badge/.NET%20Framework-v4.5.2-red.svg)

```c#
public void LinearRegression_Example()
{
    decimal[] x = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
    decimal[] y = { 8, 6, 10, 6, 10, 13, 9, 11, 15, 17 };

    var lr = new LinearRegression(x, y);

    Console.WriteLine("y = {0} + {1} * x + error", lr.Alpha, lr.Beta);
    Console.WriteLine("r_value = {0}", lr.RValue);
    Console.WriteLine("r_squared = {0}", lr.RSquared);
}

public void LogitRegression_Example()
{
	bool[] y = { true, true, true, false, true, false, false, true, false };
    decimal[] x = { 1, 3, 2, 23, 1, 36, 35, 5, 17 };

    var logitRegression = new LogitRegression(y, x);

    var result = logitRegression.PredictValue(new decimal[] { 17 });
    Console.WriteLine("Result = {0}", result);
}

public void SMA_Example()
{
    decimal[] values = { 1, 3, 5, 7, 9, 2, 4, 6, 8, 11, 13, 15, 24, 46, 68 };
    
    var result = MovingAverages.SMA(values, 5);
}

public void MatrixInverse_Example()
{
    decimal[][] m = new decimal[3][]
    {
        new decimal[3] {  1,   4,   10  },
        new decimal[3] {  1,   2,   8   },
        new decimal[3] {  0,   1,   4   }
    };
    
    var matrix = new Matrix(m, copy: true);

    var inversedMatrix = matrix.Inverse();   
}

```

**More examples in** https://github.com/dv-lebedev/statistics/tree/master/Statistics.UnitTest

## License
[Apache 2.0](LICENSE)