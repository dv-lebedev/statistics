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

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Statistics.UnitTest
{
    [TestClass]
    public class NMatrixTest
    {
        [TestMethod]
        public void CreateTest()
        {
            var matrix = new Matrix(3, 2);

            Assert.AreEqual(3, matrix.Rows);
            Assert.AreEqual(2, matrix.Columns);
        }

        [TestMethod]
        public void CreateFromExistance()
        {
            decimal[][] m1 = new decimal[3][]
            {
                new decimal[3] {  0,   1,  10  },
                new decimal[3] {  1,   2,  3   },
                new decimal[3] { -10,  1,  4   }
            };


            //
            //  Create by copying
            //
            var matrix = new Matrix(m1, copy: true);

            Assert.AreEqual(m1.Length, matrix.Rows);
            Assert.AreEqual(m1[0].Length, matrix.Columns);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(m1[i][j], matrix[i, j]);
                }
            }


            //
            //  Create by using reference
            //
            var matrix2 = new Matrix(m1, copy: false);

            Assert.AreEqual(m1.Length, matrix2.Rows);
            Assert.AreEqual(m1[0].Length, matrix2.Columns);

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Assert.AreEqual(m1[i][j], matrix2[i, j]);
                }
            }
        }

        [TestMethod]
        public void AreEqualTest()
        {
            decimal[][] m1 = new decimal[3][]
            {
                new decimal[3] {  0,   1,  10  },
                new decimal[3] {  1,   2,  3   },
                new decimal[3] { -10,  1,  4   }
            };

            decimal[][] m2 = new decimal[3][]
            {
                new decimal[3] {  5,   0,   4   },
                new decimal[3] {  1,   15,  13  },
                new decimal[3] {  7,  -1,   35  }
            };

            var matrix1 = new Matrix(m1);

            var matrix2 = new Matrix(m2);

            Assert.AreEqual(true, matrix1.AreEqual(matrix1, epsilon: 0));
            Assert.AreEqual(false, matrix1.AreEqual(matrix2, epsilon: 0));

        }

        [TestMethod]
        public void ByMatrixTest()
        {
            decimal[][] m1 = new decimal[3][]
            {
                new decimal[3] {  0,   1,  10  },
                new decimal[3] {  1,   2,  3   },
                new decimal[3] { -10,  1,  4   }
            };


            decimal[][] expectedResult = new decimal[3][]
            {
                new decimal[3] {  101,  32,  41   },
                new decimal[3] {   32,  14,  4    },
                new decimal[3] {   41,  4,   117  }
            };

            var matrix1 = new Matrix(m1, copy: true);

            var matrixByMatrix = matrix1.ByMatrix();

            Assert.AreEqual(true, new Matrix(expectedResult).AreEqual(matrixByMatrix, 0));
        }

        [TestMethod]
        public void GetVectorTest()
        {
            decimal[][] m1 = new decimal[3][]
           {
                new decimal[3] {  0,   1,  10  },
                new decimal[3] {  1,   2,  3   },
                new decimal[3] { -10,  1,  4   }
           };

            decimal[] expectedVector = new decimal[] { 395, 175, 33 };

            var matrix = new Matrix(m1);

            var vector = matrix.GetVector(new decimal[] { 14, 25, 37 });

            Assert.AreEqual(expectedVector.Length, vector.Length);

            for (int i = 0; i < vector.Length; i++)
            {
                Assert.AreEqual(expectedVector[i], vector[i]);
            }
        }

        [TestMethod]
        public void VectorProductTest()
        {
            decimal[][] m1 = new decimal[3][]
            {
                new decimal[3] {  0,   1,  10  },
                new decimal[3] {  1,   2,  3   },
                new decimal[3] { -10,  1,  4   }
            };

            var matrix = new Matrix(m1, copy: true);

            var vectorExpected = new decimal[] { 25, 88, -3 };

            var vectorResult = matrix.VectorProduct(new decimal[] { 4, 45, -2 });

            for (int i = 0; i < vectorResult.Length; i++)
            {
                Assert.AreEqual(vectorExpected[i], vectorResult[i]);
                //System.Diagnostics.Debug.Write(vectorResult[i] + " ");
            }
        }

        [TestMethod]
        public void DuplicateTest()
        {
            decimal[][] m1 = new decimal[3][]
            {
                new decimal[3] {  0,   1,  10  },
                new decimal[3] {  1,   2,  3   },
                new decimal[3] { -10,  1,  4   }
            };

            var matrix = new Matrix(m1, copy: true);

            var matrixCopy = matrix.Duplicate();

            Assert.AreEqual(true, matrix.AreEqual(matrixCopy, 0));

        }

        [TestMethod]
        public void HelperSolveTest()
        {
            decimal[][] m1 = new decimal[3][]
            {
                new decimal[3] {  7,   1,  10  },
                new decimal[3] {  1,   2,  3   },
                new decimal[3] { -10,  1,  4   }
            };

            var matrix = new Matrix(m1, copy: true);

            var vector = new decimal[] { 1, 2, 7 };

            var expectedVector = new decimal[] { -4.7857M, -5.5M, 4 };

            var resultVector = matrix.HelperSolve(vector);

            for (int i = 0; i < resultVector.Length; i++)
            {
                Assert.AreEqual((double)expectedVector[i], (double)resultVector[i], 0.0001);
            }
        }

        [TestMethod]
        public void DecomposeTest()
        {
            decimal[][] m1 = new decimal[3][]
            {
                new decimal[3] {  1,   4,  10  },
                new decimal[3] {  1,   2,  8  },
                new decimal[3] {  0,   1,  4   }
            };

            decimal[][] expectedResult = new decimal[3][]
            {
                new decimal[3] {   1,   4,     10  },
                new decimal[3] {   1,  -2,    -2   },
                new decimal[3] {   0,  -0.5M,  3   }
            };

            var matrix1 = new Matrix(m1, copy: true);

            int[] perm;
            int toogle;

            var decomposeMatrix = matrix1.Decompose(out perm, out toogle);

            Assert.AreEqual(true, new Matrix(expectedResult).AreEqual(decomposeMatrix, 0));

        }

        [TestMethod]
        public void InverseTest()
        {
            decimal[][] m1 = new decimal[3][]
            {
                new decimal[3] {  1,   4,  10  },
                new decimal[3] {  1,   2,  8  },
                new decimal[3] {  0,   1,  4   }
            };

            decimal[][] expectedResult = new decimal[3][]
            {
                new decimal[3] {   0,         0.9999M,   -1.9999M   },
                new decimal[3] {   0.6666M,  -0.6666M,   -0.3333M   },
                new decimal[3] {  -0.1666M,   0.1666M,    0.3333M   }
            };

            var matrix1 = new Matrix(m1, copy: true);

            var inverseM = matrix1.Inverse();

            Assert.AreEqual(true, inverseM.AreEqual(new Matrix(expectedResult), 0.0001M));
        }
    }
}
