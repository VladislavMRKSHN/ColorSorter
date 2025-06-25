using System;
using System.Collections.Generic;
using ColorSort.Models;
using ColorSort.Models;

namespace ColorSort.Services
{
    public static class ColorSorter
    {
        public static ColorObject[] Sort(ColorObject[] objectsToSort, ColorObject[] sortingOrder)  // Метод сортировки
        {
            ValidateInput(objectsToSort, sortingOrder);  // Проверка входных данных

            ColorObject[] sortedObjects = (ColorObject[])objectsToSort.Clone();  // Создание копии массива для сортировки
            PerformBubbleSort(sortedObjects, sortingOrder);  // Сортировка

            return sortedObjects;  // Возвращение отсортированного массива
        }

        private static void ValidateInput(ColorObject[] objects, ColorObject[] order)  // Проверка входных параметров
        {
            if (objects == null) throw new ArgumentNullException(nameof(objects));
            if (order == null) throw new ArgumentNullException(nameof(order));
            if (order.Length == 0) throw new ArgumentException("Массив порядка сортировки не может быть пустым");
        }

        private static void PerformBubbleSort(ColorObject[] array, ColorObject[] order)  // Пузырьковая сортировка
        {
            var orderDict = CreateOrderDictionary(order);  // Создание словаря порядка

            for (int i = 0; i < array.Length - 1; i++)  // Внешний цикл сортировки
            {
                for (int j = 0; j < array.Length - i - 1; j++)  // Внутренний цикл сравнения
                {
                    if (Compare(array[j], array[j + 1], orderDict) > 0)  // Сравнение элементов
                    {
                        Swap(ref array[j], ref array[j + 1]);  // Обмен элементов местами
                    }
                }
            }
        }

        private static Dictionary<ColorObject, int> CreateOrderDictionary(ColorObject[] order)  // Создание словаря приоритетов
        {
            var dict = new Dictionary<ColorObject, int>();  // Инициализация словаря
            for (int i = 0; i < order.Length; i++)  // Заполнение словаря
            {
                dict[order[i]] = i;  // Цвет - позиция в порядке сортировки
            }
            return dict;  //  Возвращение готового словаря
        }

        private static int Compare(ColorObject x, ColorObject y, Dictionary<ColorObject, int> orderDict)  // Сравнение двух цветов
        {
            int xOrder = orderDict.TryGetValue(x, out int xVal) ? xVal : int.MaxValue;  // Порядок для x
            int yOrder = orderDict.TryGetValue(y, out int yVal) ? yVal : int.MaxValue;  // Порядок для y
            return xOrder.CompareTo(yOrder);  // Сравнение порядков
        }

        private static void Swap(ref ColorObject a, ref ColorObject b)  // Обмен значений
        {
            (a, b) = (b, a);
        }
    }
}