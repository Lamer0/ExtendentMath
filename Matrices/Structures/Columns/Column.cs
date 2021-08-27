﻿using MiscUtil;
using System;
using MathExtended.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathExtended.Matrices.Structures.CellsCollection;
using MathExtended.Matrices.Structures.Rows;

namespace MathExtended.Matrices.Structures.Columns
{
    /// <summary>
    /// Описывает столбец матрицы
    /// </summary>
    /// <typeparam name="T">Тип содержимого строки</typeparam>
    public class Column<T> : BaseCellsCollection<T> where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        /// <summary>
        /// Создает столбец с указанными размерами
        /// </summary>
        /// <param name="height"></param>
       public Column(int height) : base(height) { }
       /// <summary>
       /// Создает столбец на основе массива
       /// </summary>
       /// <param name="array"></param>
       public Column(T[] array) : base(array) { }

       /// <summary>
       /// Не явным образом приводит масив к столбцу
       /// </summary>
       /// <param name="array">Приводимый массив</param>
       public static implicit operator Column<T>(T[] array)
       {
            return new Column<T>(array);
       }

        /// <summary>
        /// Умножает число на столбец
        /// </summary>
        /// <param name="multiplier">Множитель</param>
        /// <param name="column">Столбец</param>
        /// <returns>Умноженый столбец</returns>
        public static Column<T> operator *(T multiplier, Column<T> column)
        {
            Column<T> multipliedColumn = new Column<T>(column.Size);

            int i = 0;

            column.ForEach((cell) => multipliedColumn[i++] = Operator.Multiply(cell, multiplier));

            return multipliedColumn;
        }

        /// <summary>
        /// Умножает число на столбец
        /// </summary>
        /// <param name="multiplier">Множитель</param>
        /// <param name="column">Столбец</param>
        /// <returns>Умноженный столбец</returns>
        public static Column<T> operator *(Column<T> column, T multiplier)
        {
            Column<T> multipliedColumn = new Column<T>(column.Size);

            int i = 0;

            column.ForEach((cell) => multipliedColumn[i++] = Operator.Multiply(cell, multiplier));

            return multipliedColumn;
        }

        /// <summary>
        /// Складывает столбцы
        /// </summary>
        /// <param name="columnA">Первый столбец</param>
        /// <param name="columnB">Второй столбец</param>
        /// <returns>Сумма двух столбцов</returns>
        public static Column<T> operator +(Column<T> columnA, Column<T> columnB)
        {
            if (columnA.Size == columnB.Size)
            {
                Column<T> summedColumn = new Column<T>(columnA.Size);

                int i = 0;

                summedColumn.ForEach((cell) => summedColumn[i++] = Operator.Add(columnA[i++], columnB[i++]));

                return summedColumn;
            }
            else
            {
                throw new ColumnsOfDifferentSizesException();
            }
        }

        /// <summary>
        /// Вычетает столбцы
        /// </summary>
        /// <param name="columnA">Первый столбец</param>
        /// <param name="columnB">Второй столбец </param>
        /// <returns>Разность двух столбцов</returns>
        public static Column<T> operator -(Column<T> columnA, Column<T> columnB)
        {
            if (columnA.Size == columnB.Size)
            {
                Column<T> summedColumn = new Column<T>(columnA.Size);

                int i = 0;

                summedColumn.ForEach((cell) => summedColumn[i++] = Operator.Subtract(columnA[i++], columnB[i++]));

                return summedColumn;
            }
            else
            {
                throw new ColumnsOfDifferentSizesException();
            }
        }

        /// <summary>
        /// Явно приводит <see cref="ReadOnlyColumn{T}"/> к <see cref="Column{T}"/>
        /// Делая пригодным для записи
        /// </summary>
        /// <param name="readOnlyColumn">Привидимый столбец</param>
        public static explicit operator Column<T>(ReadOnlyColumn<T> readOnlyColumn)
        {
            Column<T> column = new Column<T>(readOnlyColumn.Size);

            int i = 0;

            readOnlyColumn.ForEach((cell) =>
            {
                column[i] = cell;
            });

            return column;
        }

        /// <summary>
        /// Транспонирует столбец
        /// </summary>
        /// <returns><see cref="Row{T}"/> Строка</returns>
        public Row<T> Transponate()
        {
           return new Row<T>(_cells);
        }
    }
}