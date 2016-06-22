using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleOvningar
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = new List<int>() { 1, 5, -5, 9, 78, 4, 1, 4, 5, 1 };

            //PrintAList(ReturnOddNumbers(ints), "This is the oddnumbers");
            //PrintAList(ReturnDistinctIntList(ints));
            //FindHighestIntInList(ints);
            FindLowestIntInList(ints);
            //GenerateLottoNumbers();
            

            //ReplaceSwedishLetters();
        }

        private static void ReplaceSwedishLetters()
        {
            StringBuilder stringBuilder = new StringBuilder("Kåälöllla");
            StringBuilder translatedBuilder = new StringBuilder();
            Console.WriteLine(stringBuilder);
            for (int i = 0; i < stringBuilder.Length; i++)
            {
                if (stringBuilder[i] == 'å')
                {
                    translatedBuilder.Append("aa");
                }
                else if (stringBuilder[i] == 'ä')
                {
                    translatedBuilder.Append("ae");
                }
                else if (stringBuilder[i] == 'ö')
                {
                    translatedBuilder.Append("oo");
                }
                else
                {
                    translatedBuilder.Append(stringBuilder[i]);
                }
                
            }
            Console.WriteLine(translatedBuilder);
        }

        private static void PrintAList(List<int> ints, string clarificationText = "This is a list")
        {
            Console.WriteLine($"***{clarificationText}***");
            foreach (var i in ints)
            {
                Console.WriteLine(i);

            }
        }

        private static void GenerateLottoNumbers()
        {
            List<int> randomLottoNumbers = new List<int>();
            Random random = new Random();
            do
            {
                randomLottoNumbers.Add(random.Next(1, 35));
                randomLottoNumbers = ReturnDistinctIntList(randomLottoNumbers);
            } while (randomLottoNumbers.Count < 7);
            PrintAList(randomLottoNumbers, "These are the Lottonumbers");

        }

        private static void FindLowestIntInList(List<int> ints)
        {

            Console.WriteLine(ints.Aggregate((current, next) => current > next ? current : next));
            //ints.Aggregate((current, next) => current > next ? current : next);


            //int lowest = ints[0];
            //foreach (var i in ints)
            //{
            //    if (i < lowest)
            //    {
            //        lowest = i;
            //    }

            //}
            //Console.WriteLine($"Lowest number is {lowest}");
        }

        private static void FindHighestIntInList(List<int> ints)
        {
            int highest = ints[0];
            foreach (var i in ints)
            {
                if (i >= highest)
                {
                    highest = i;
                }
            }
            Console.WriteLine($"The highest numnber is {highest}");

        }

        private static List<int> ReturnOddNumbers(List<int> ints)
        {
            List<int> tempOddNumbers = new List<int>();
            foreach (var i in ints)
            {
                if (i % 2 == 1)
                {
                    tempOddNumbers.Add(i);
                }
            }
            return tempOddNumbers;
        }


        private static List<int> ReturnDistinctIntList(List<int> ints)
        {
            List<int> tempNumbers = new List<int>();
            ints.Sort();
            for (int i = 0; i < ints.Count; i++)
            {
                if (i >= 1 && ints[i] > ints[i - 1])
                    tempNumbers.Add(ints[i]);
                else if (i == 0)
                {
                    tempNumbers.Add(ints[i]);
                }
            }
            return tempNumbers;

        }
    }
}
