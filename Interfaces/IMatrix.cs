﻿using MathExtended.Matrices.Structures.CellsCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended.Interfaces
{
    /// <summary>
    /// Определяет основную структуру матрицы
    /// </summary>
    /// <typeparam name="T">Числовой тип</typeparam>
    public interface IMatrix<T> where T: IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        /// <summary>
        ///  Главная диагональ
        /// </summary>
        MainDiagonal<T> MainDiagonal { get;}

        /// <summary>
        /// Метод нахождения диагонали
        /// </summary>
        /// <returns>Массив определяющийся главной диагональю матрицы</returns>
        T[] FindDiagonal();

        /// <summary>
        /// Количество строк
        /// </summary>
        int RowsCount { get;}

        /// <summary>
        /// Количество столбцов
        /// </summary>
        int ColumnsCount { get; }

        
    }
}
