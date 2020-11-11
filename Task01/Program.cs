using System;
using System.IO;

/*
 * По массиву A целых чисел со значениями из диапазона [-10;10] создать массив булевских значений L.
 * Количество элементов в массивах совпадает.
 * На местах неотрицательных элементов в массиве A
 * в массиве L стоят значения true, на месте отрицательных – false.
 * Если хотя бы один из элементов массива А находится вне заданного диапазона - выводить Incorrect Input
 * в консоль. Гарантируется, что на вход подается N целых чисел.
 *
 * Пример входных данных:
 * 0 -1
 *
 * Пример выходных данных:
 * true false
 */

namespace _01_07_Files
{
    class Program
    {
        private const string inputPath = "input.txt";
        private const string outputPath = "output.txt";
        
        static int[] ReadFile(string path)
        {
            // TODO: implement this method
        }

        static bool CheckArray(int[] array)
        {
            // TODO: implement this method
        }
        
        static bool[] IntToBoolArray(int[] array)
        {
            // TODO: implement this method
        }
        
        static void WriteFile(string path, bool[] array)
        {
            // TODO: implement this method
        }

        // you do not need to fill your file, you can work with console input
        static void Main(string[] args)
        {
            // do not touch
            FillFile();
            
            int[] A;
            bool[] L;
            
            try
            {
                A = ReadFile(inputPath);
                
                if (!CheckArray(A))
                    // TODO: implement this case
                
                L = IntToBoolArray(A);
                WriteFile(outputPath, L);
            }
            // TODO: catch with meaningful message
            
            // do not touch
            ConsoleOutput();
        }

        #region Testing methods for Github Classroom, do not touch!

        static void FillFile()
        {
            try
            {
                File.WriteAllText(inputPath, Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ConsoleOutput()
        {
            try
            {
                Console.WriteLine(File.ReadAllText(outputPath));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        #endregion
    }
}