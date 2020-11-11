using System;
using System.IO;
using System.Text;

/*
 * По массиву A целых чисел со значениями из диапазона (1; 10000] создать массив целых чисел B,
 * в котором на каждой позиции стоит ближайшая степень двойки меньшая значения из массива A у той же позиции.
 * Например, A = {30, 100, 300} B = {16, 64, 256}.
 * Если хотя бы один из элементов массива А находится вне заданного диапазона - выводить Incorrect Input
 * в консоль. Гарантируется, что на вход подается N целых чисел.
 *
 * Пример входных данных:
 * 3 10 20
 *
 * Пример выходных данных:
 * 2 8 16
 */

namespace Task02
{
    class Program
    {
        private const string inputPath = "input.txt";
        private const string outputPath = "output.txt";

        private static readonly int[] powers = { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384 };
        
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
                if (array[i] > 10000 || array[i] <= 1)
                {
                    return false;
                }
            }
            return true;
        }
        
        static int[] ConvertArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 1; j < powers.Length; j++)
                {
                    if (array[i] <= powers[j])
                    {
                        array[i] = powers[j - 1];
                        break;
                    }
                }
            }
            return array;
        }

        static void WriteFile(string path, int[] array)
        {
            StringBuilder ans = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                ans.Append(array[i].ToString().ToLower()).Append(" ");
            }
            File.WriteAllText(outputPath, ans.ToString());
        }

        // you do not need to fill your file manually, you can work with console input
        static void Main(string[] args)
        {
            // do not touch
            FillFile();
            
            int[] A;
            int[] B;
            
            try
            {
                A = ReadFile(inputPath);
                if (!CheckArray(A))
                {
                    Console.WriteLine("Incorrect Input");
                    return;
                }
                B = ConvertArray(A);
                WriteFile(outputPath, B);
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