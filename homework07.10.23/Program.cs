using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace homework07._10._23
{
    internal class Program
    {
        static void PrintMatrix(int[,] matrix)
        {
            int rows  = matrix.GetLength(0);
            int columns = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static int[,] Multiplication(int[,] matrix1, int[,] matrix2)
        {
            int rows1 = matrix1.GetLength(0);
            int columns1 = matrix1.GetLength(1);
            int rows2 = matrix2.GetLength(0);
            int columns2 = matrix2.GetLength(1);
            if ( matrix1.GetLength(1) != matrix2.GetLength(0))
            {
                Console.WriteLine("Multiplication is not available.");
            }
            
            int[,] matrix3 = new int[rows1, columns2];
            for (int a = 0; a < rows1; a++)
            {
               for (int b = 0; b < columns2; b++)
               {
                    matrix3[a, b] = 0;

                    for (int c = 0; c < columns1; c++)
                    {
                     
                        matrix3[a, b] += matrix1[a, c] * matrix2[c, b];
                       
                    }
               }
            }
            return matrix3;
         }

        static int[,] Temperature()
        {
            Random random = new Random();
            int[,] temperature = new int[12, 30];
            for (int month = 0; month < 12; month++)
            {
                for (int day = 0; day < 30; day++)
                {
                    temperature[month, day] = random.Next(-40, +35);

                }
            }
            return temperature;
        }

        static int[] CountAverageTemperature(int[,] temperature)
        {
            int[] average_temp = new int[12];

            for (int month = 0; month < 12; month++)
            {
                int sum = 0;
                for (int day = 0; day < 30; day++)
                {
                    sum += temperature[month, day];

                }
                average_temp[month] = sum / 30;

            }
            return average_temp;
        }
        static void CountOfVowelsAndConsonants(char[] file_array, out int vowels, out int consonants)
        {
            List<char> vowels_ENG = new List<char>() { 'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'O', 'U', 'Y' };
            List<char> vowels_RUS = new List<char>() { 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'ю', 'э', 'я', 'А', 'Е', 'Ё', 'И', 'О', 'У', 'Ы', 'Ю', 'Э', 'Я' };
            vowels = 0;
            consonants = 0;

            foreach (char letter in file_array)
            {
                if (char.IsLetter(letter))
                {

                    if (vowels_ENG.Contains(letter))
                    {
                        vowels++;
                    }
                    else if (vowels_RUS.Contains(letter))
                    {
                        vowels += 1;
                    }
                    else
                    {
                        consonants++;
                    }
                }
            }
            Console.WriteLine($"The amount of vowels: {vowels}" + $"\nThe amount of consonants: {consonants}");

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Task 6.1");
            Console.WriteLine("Enter a name of file:");
            string path = Console.ReadLine();
            if (!File.Exists(path))
            {
                Console.WriteLine("The name of file is invalid.");
            }
            string file = File.ReadAllText(path);
            char[] file_array = file.ToCharArray();
            int vowels, consonants;
            CountOfVowelsAndConsonants(file_array, out vowels, out consonants);

            Console.WriteLine("Task 6.2");
            int[,] matrix1 = { { 5, 2, 3 }, { 8, 1, 9 } };
            int[,] matrix2 = { { 5, 8 }, { 7, 7 }, { 0, 1 } };
            Console.WriteLine("Matrix 1:");
            PrintMatrix(matrix1);
            Console.WriteLine("Matrix 2:");
            PrintMatrix(matrix2);
            int[,] matrix3 = Multiplication(matrix1, matrix2);
            Console.WriteLine("Matrix 3:");
            PrintMatrix(matrix3);

            Console.WriteLine("\nTask 6.3");
            int[,] temperature = Temperature();
            int[] average_temp = CountAverageTemperature(temperature);
            Array.Sort(average_temp);
            Console.WriteLine("Average temperature for each month:");
            for (int i = 0; i < average_temp.Length; i++)
            {
                Console.WriteLine("Month: {0}: {1}", i + 1, average_temp[i]);
            }


            Console.WriteLine("(Press any key to continue work)");
            Console.ReadKey();

        }
    }
}
