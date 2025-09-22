using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] numbers = new int[10];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(-20, 21);
            }
            //IEnumerable<int> query = from num in numbers where num > 0 orderby num select num;

            //1
            var num = numbers.Where(n => n > 0).OrderBy(n => n).Select(n => n);
            //2
            var num1 = numbers.Where(n => n > 9).OrderBy(n => n).ToArray();
            num1.Count();
            //3
            int[] years = { 1990, 1995, 2000, 2005, 2010, 2015, 2020 };

            var leapYears = years.Where(y => y%4==0).ToArray();
            //4
            var num2 = numbers.Where(n=>n%2==0).OrderByDescending(n => n).Take(1);
            //5
            string[] words = { "apple", "banana", "cherry", "date", "fig", "grape" };
            var NewWords = words.Select(w => w + "!!!").ToArray();
            //6
            char symbol = 'a';
            var count = words.Select(w => w.Contains(symbol)).ToArray();
            //7
            var group = words.GroupBy(w => w.Length);







        }
    }
}