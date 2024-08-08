using System.Diagnostics;
using System.Text;

namespace Week05CSC205
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string hello = CptCrunch("Hello, World!", 13);
            string olleh = CptCrunch(hello, -13);
            Console.WriteLine(hello);
            Console.WriteLine(olleh);
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine();

            string fileName = "numbers.txt"; // Path = "Week05CSC205\bin\Debug\net8.0\numbers.txt"
            Stopwatch stopwatch = new Stopwatch();
            Method01(fileName, 1000, 1, 1001);
            string[] lines = File.ReadAllLines(fileName); //  reads all the lines from a file specified by fileName and stores each line as a string in the lines array.
            int[] values = new int[lines.Length]; // initializes an integer array values with the same length as the lines array. This array will store the converted integer values.
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = Convert.ToInt32(lines[i]); // converts the string at index i in the lines array to an integer and stores it in the corresponding index of the values array.
            }
            stopwatch.Start();
            Console.WriteLine("starting ... ");
            Method02(values);
            Console.WriteLine("done! ... ");
            stopwatch.Stop();
            Console.WriteLine("time measured: {0} ms", stopwatch.ElapsedMilliseconds);
            foreach (int value in values)
                Console.Write(value + " ");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine();


        }

        // EX 7.12
        static string CptCrunch(string line, int n)
        {
            StringBuilder encoded = new StringBuilder();
            foreach (char c in line)
            {
                if (char.IsLetter(c))
                {
                    // Check if character is uppercase or lowercase
                    char offset = char.IsUpper(c) ? 'A' : 'a';
                    // Normalize to 0-25 range and shift, then re-normalize
                    char newChar = (char)(((c + n - offset + 26) % 26) + offset);
                    encoded.Append(newChar);
                }
                else
                {
                    // Append non-letter characters unchanged
                    encoded.Append(c);
                }
            }
            return encoded.ToString();
        }

        /// <summary>
        /// Writes a specified number of random integers within a given range to a file.
        /// </summary>
        /// <param name="fileName">The name of the file to write the random integers to.</param>
        /// <param name="total">The total number of random integers to generate and write.</param>
        /// <param name="lowerRange">The inclusive lower bound of the random number range.</param>
        /// <param name="upperRange">The exclusive upper bound of the random number range.</param>
        static void Method01(string fileName, int total, int lowerRange, int upperRange)
        {
            using (var writer = new StreamWriter(fileName))
            {
                Random r = new Random();
                int number = 0;
                {
                    for (int i = 1; i < total; i++)
                    {
                        number = r.Next(lowerRange, upperRange);
                        writer.WriteLine(number);
                    }
                }
            }
        }

        /// <summary>
        /// Sorts an array of integers in ascending order using the selection sort algorithm.
        /// </summary>
        /// <param name="arr">The array of integers to sort.</param>
        static void Method02(int[] arr)
        {
            for (int start = 0; start < arr.Length - 1; start++)
            {
                int posMin = start;
                for (int i = start + 1; i < arr.Length; i++)
                {
                    if (arr[i] < arr[posMin])
                    {
                        posMin = i;
                    }
                }
                int tmp = arr[start];
                arr[start] = arr[posMin];
                arr[posMin] = tmp;
            }
        }
    }
}

