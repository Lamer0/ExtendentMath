﻿using MiscUtil;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathExtended.Matrices.Structures.CellsCollection
{
    /// <summary>
    /// Описывает коллекцию ячеек
    /// </summary>
    /// <typeparam name="T">Числовой тип</typeparam>
    public class BaseCellsCollection<T> : IEnumerator<T> where T : IComparable, IFormattable, IConvertible, IComparable<T>, IEquatable<T>
    {
        /// <summary>
        /// Массив ячеек
        /// </summary>
        protected T[] _cells;

        private int _size;
        private bool disposedValue;
        private int _position;

        /// <summary>
        /// Индексатор.По индексу возвращает или задает значение ячейки
        /// </summary>
        /// <param name="index">Индекс элемента</param>
        /// <returns>Элемент по индексу</returns>
        public virtual T this[int index]
        {
            get
            {
                return _cells[index];
            }

            set
            {
                _cells[index] = value;
            }
        }

        /// <summary>
        /// Размер коллекции
        /// </summary>
        public int Size
        {
            get => _cells.Length;
        }

        /// <summary>
        /// Создает коллекцию с указанным размером
        /// </summary>
        /// <param name="size">Размер коллекции</param>
        public BaseCellsCollection(int size)
        {
            _cells = new T[size];
        }

        /// <summary>
        /// Создает коллекцию ячеек на основе массива
        /// </summary>
        /// <param name="array">Входной массив</param>
        public BaseCellsCollection(T[] array)
        {
            _cells = array;
            _size = array.Length;
        }

        /// <summary>
        /// Применяет действие ко всем элементам
        /// </summary>
        /// <param name="action">Действие</param>
        public virtual void ForEach(Action<T> action)
        {
            foreach (T cell in _cells)
            {
                action(cell);
            }
        }

        #region IEnumerable
        /// <summary>
        /// Текуший элемент
        /// </summary>
        public T Current
        {
            get
            {
                return _cells[_position];
            }
        }

        object IEnumerator.Current => Current;

        /// <summary>
        /// Перечислитель
        /// </summary>
        /// <returns>Перечислитель матрицы</returns>
        public IEnumerator<T> GetEnumerator()
        {
            foreach (var i in _cells)
            {

                yield return i;
            }
        }

        /// <summary>
        /// Перемещает индексатор на одну позицию вперед
        /// </summary>
        /// <returns>true или false в зависимости ли можно переместить индексатор</returns>
        public bool MoveNext()
        {

            if (_position < this.Size - 1)
            {
                return true;
            }
            else
            {
                return false;
            }



        }

        /// <summary>
        /// Перемещает индексатор в начало матрицы
        /// </summary>
        public void Reset()
        {
            _position = -1;
        }

        /// <summary>
        /// Высвобождает использованные ресурсы
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _cells = null;
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

        /// <summary>
        /// Освобождает использованные ресурсы
        /// </summary>
        public void Dispose()
        {
            // Не изменяйте этот код.  Разместите код очистки в методе "Dispose(bool disposing)".
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}