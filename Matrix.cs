﻿using MathExtended.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathExtended.Interfaces;
using System.Collections;
using MathExtended.Exceptions;

namespace MathExtended
{
    public class Matrix<T> : IEnumerator<T> 
    {
        #region Поля матрицы

        private T[,] matrix;

        private T mainDiagonal;



        private int rowsCount;

        private int collumnsCount;

        #endregion

        private bool disposedValue;

        private int _position;

        private int _position1;

        public int RowsCount
        {
            get => rowsCount;
        }

        public int CollumnsCount
        {
            get => collumnsCount;
        }

        public int Length
        {
            get => matrix.Length;
        }


        #region IEnumerable
        public T Current
        {
            get
            {
                if (CheckPositionOut(_position, _position1))
                {
                    throw new IndexOutOfRangeException();
                }
                return matrix[_position, _position1];
            }
        }

        object IEnumerator.Current => this.Current;

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var i in matrix)
            {
                yield return i;
            }
        }
        public bool MoveNext()
        {
            if (_position < matrix.GetUpperBound(0) + 1 && _position1 < matrix.Length / matrix.GetUpperBound(1) + 1)
            {
                _position++;
                _position1++;
                return true;
            }
            else
                return false;
        }

        public void Reset()
        {
            _position = -1;
            _position1 = -1;
        }

        #endregion



        public Matrix(int rows, int collumns)
        {
            rowsCount = rows;

            collumnsCount = collumns;

            matrix = new T[rowsCount, collumns];
        }

        private int GetLenght(T[,] matrix)
        {
            return matrix.Length - 1;
        }


        #region Индексатор
        public T this[int index, int index1]
        {
            get
            {
                return matrix[index, index1];
            }

            set
            {
                matrix[index, index1] = value;
            }
        }

        #endregion

        private bool CheckPositionOut(int position, int position1)
        {
            if (position == -1 || position >= matrix.Length || position1 == -1 || position1 >= matrix.Length)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        #region Matrixatrix Sum

        /// <summary>
        /// Суммирует две матрицы и возвращает 3-ю
        /// </summary>
        /// <param name="matrixA"></param>
        /// <param name="matrixB"></param>
        /// <returns>Сумма A и B</returns>
        public static double[,] SumMatrixatrix(double[,] matrixA, double[,] matrixB)
        {

            if (matrixA.Length == matrixB.Length)
            {
                var matrixC = new double[matrixA.GetLength(0), matrixB.GetLength(0)];

                for (var i = 0; i < matrixA.GetLength(0); i++)
                {
                    for (var j = 0; j < matrixB.GetLength(0); j++)
                    {
                        matrixC[i, j] = matrixA[i, j] + matrixB[i, j];
                    }
                }

                return matrixC;
            }
            else
            {
                throw new MatrixDifferentSizeException();
            }
        }
        #endregion


#if DEBUG
        /// <summary>
        /// Умножает матрицу на число
        /// </summary>
        /// <param name="multiplier"></param>
        /// <param name="matrixA"></param>
        /// <returns></returns>
        public Matrix<T> MultiplyMatrix(T multiplier, Matrix<T> matrixA)
        {
            var matrixB = new Matrix<T>(matrixA.RowsCount, matrixA.CollumnsCount);

            for (int row = 0; row < matrixA.RowsCount; row++)
            {
                for (int collumn = 0; collumn < matrixA.RowsCount; collumn++)
                {
                    matrixB[row, collumn] = matrixA[row, collumn] * multiplier;
                }
            }
            return matrixB;
        }



        /// <summary>
        /// Суммирует две матрицы и возвращает 3-ю
        /// </summary>
        /// <param name="matrixA"></param>
        /// <param name="matrixB"></param>
        /// <returns>Сумма A и B</returns>
        public static Matrix<T> Sum(Matrix<T> matrixA, Matrix<T> matrixB)
        {
            if (matrixA.CollumnsCount == matrixB.CollumnsCount && matrixA.RowsCount == matrixB.RowsCount)
            {
                var matrixC = new Matrix<T>(matrixA.RowsCount, matrixB.CollumnsCount);


                for (var i = 0; i < matrixA.Length; i++)
                {
                    for (var j = 0; j < matrixB.Length; j++)
                    {
                        matrixC[i, j] = matrixA[i, j] + matrixB[i, j];
                    }
                }
                return matrixC;
            }
            else
            {
                throw new MatrixDifferentSizeException();
            }


        }
#endif



        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    matrix = null;

                }

                // TODO: освободить неуправляемые ресурсы (неуправляемые объекты) и переопределить метод завершения
                // TODO: установить значение NULL для больших полей
                disposedValue = true;
            }
        }

        // // TODO: переопределить метод завершения, только если "Dispose(bool disposing)" содержит код для освобождения неуправляемых ресурсов
        // ~Matrix()
        // {
        //     // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Не изменяйте этот код. Разместите код очистки в методе "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

       


    }


   




}
