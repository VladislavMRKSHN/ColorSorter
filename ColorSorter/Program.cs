using System;
using System.Linq;
using ColorSort.Models;
using ColorSort.Services;

namespace ColorSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Сортировка объектов по цвету");
            Console.WriteLine("----------------------------");

            try
            {
                ColorObject[] objectsToSort = GetObjectsToSortFromUser(); // Получение входных данных
                ColorObject[] sortingOrder = GetSortingOrderFromUser();

                ColorObject[] sortedObjects = ColorSorter.Sort(objectsToSort, sortingOrder); // Обработка и вывод результата
                DisplaySortedObjects(sortedObjects);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private static ColorObject[] GetObjectsToSortFromUser() // Получение последовательности цветов для сортировки
        {
            Console.WriteLine("Введите объекты для сортировки (К - красный, С - синий, З - зелёный):");
            string input = Console.ReadLine()?.ToUpper() ?? "";
            return ParseColorSequence(input);
        }

        private static ColorObject[] GetSortingOrderFromUser() // Получение порядка сортировки
        {
            Console.WriteLine("Введите порядок сортировки (например, С>К>З):");
            string orderInput = Console.ReadLine()?.ToUpper() ?? "";
            return ParseOrderSequence(orderInput);
        }

        private static ColorObject[] ParseColorSequence(string input) // Преобразование строки в массив цветов
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("Не введены объекты для сортировки");

            return input.Select(ConvertToColorObject).ToArray();
        }

        private static ColorObject[] ParseOrderSequence(string orderInput) // Разбор строки с порядком сортировки
        {
            if (string.IsNullOrWhiteSpace(orderInput))
                throw new ArgumentException("Не введён порядок сортировки");

            string[] parts = orderInput.Split('>');
            if (parts.Length < 2)
                throw new ArgumentException("Неверный формат порядка сортировки");

            return parts.Select(p => ConvertToColorObject(p.Trim())).ToArray();
        }

        private static ColorObject ConvertToColorObject(char colorSymbol) // Конвертация символа в ColorObject
        {
            return colorSymbol switch
            {
                'К' => ColorObject.Red,
                'С' => ColorObject.Blue,
                'З' => ColorObject.Green,
                _ => throw new ArgumentException($"Недопустимый символ цвета: {colorSymbol}")
            };
        }

        private static ColorObject ConvertToColorObject(string colorSymbol) // Конвертация строки в ColorObject
        {
            if (colorSymbol.Length != 1)
                throw new ArgumentException($"Недопустимый формат цвета: {colorSymbol}");

            return ConvertToColorObject(colorSymbol[0]);
        }

        private static void DisplaySortedObjects(ColorObject[] objects) // Отображение отсортированных объектов
        {
            Console.WriteLine("Отсортированные объекты:");
            Console.WriteLine(string.Join("", objects.Select(ConvertToColorSymbol)));
        }

        private static string ConvertToColorSymbol(ColorObject color) // Конвертация ColorObject в символьное представление
        {
            return color switch
            {
                ColorObject.Red => "К",
                ColorObject.Blue => "С",
                ColorObject.Green => "З",
                _ => "?"
            };
        }
    }
}