using System;
using System.IO;
using System.Text;

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
            string[] numberStr = File.ReadAllText(path).Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int[] numbers = new int[numberStr.Length];
            for (int i = 0; i < numbers.Length; ++i)
            {
                numbers[i] = int.Parse(numberStr[i]);
            }
            return numbers;
        }

        static bool CheckArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 10 || array[i] < -10)
                {
                    return false;
                }
            }
            return true;
        }
        
        static bool[] IntToBoolArray(int[] array)
        {
            bool[] L = new bool[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    L[i] = false;
                }
                else
                {
                    L[i] = true;
                }
            }
            return L;
        }
        
        static void WriteFile(string path, bool[] array)
        {
            StringBuilder ans = new StringBuilder();
            for(int i = 0; i < array.Length; i++)
            {
                ans.Append(array[i].ToString().ToLower()).Append(" ");
            }
            File.WriteAllText(outputPath, ans.ToString());
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
                {
                    Console.WriteLine("Incorrect Input");
                    return;
                }
                L = IntToBoolArray(A);
                WriteFile(outputPath, L);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
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