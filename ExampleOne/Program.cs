using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ExampleOne
{
    class Program
    {
        static void Main(string[] args)
        {
            // N и M - кол-во элементов в массивах A и B - string[1..100000]
            // L - кол-во элементов в массиве результатов - int[0..100000]
            
            //A - массив хостов с длиной каждого элемента [2..256]
            var A = new string[]
            {
                "unlock.microvirus.md",
                "visitwar.com",
                "visitwar.de",
                "fruonline.co.uk",
                "australia.open.com",
                "credit.card.us",
                "list.stolen.credit.card.us"
            };
            // B - массив запрещенных хостов с длиной каждого элемента [2..256]
            var B = new string[]
            {
                "microvirus.md",
                "visitwar.de",
                "piratebay.co.uk",
                "list.stolen.credit.card.us"
            };
            
            var N = 10000;
            var M = 10000;
            var len = 256;
            var ATest = GenerationStringArray(N, len);
            var BTest = GenerationStringArray(M,len);
            

            Stopwatch stopwatch = Stopwatch.StartNew();// создаем и запускаем таймер
            
            //var result = Solution.solution(ATest, BTest);
            var result = Solution.solution(A, B);
            
            stopwatch.Stop(); // смотрим сколько миллисекунд было затрачено на выполнение 
            
            foreach (var index in result) // выводим массив индексов свободных хостов
                Console.Write(index);
            
            Console.WriteLine($"\nTime worked method 1: {stopwatch.ElapsedMilliseconds}");
            stopwatch.Restart();

            //var resultLinq = Solution.solutionOnLINQ(ATest, BTest);
            var resultLinq = Solution.solutionOnLINQ(A, B);

            stopwatch.Stop(); // смотрим сколько миллисекунд было затрачено на выполнение 
            // resultLinq.ToList().ForEach(q=>Console.Write(q)); // выводим массив индексов свободных хостов
            Console.WriteLine($"\nTime worked method 2: {stopwatch.ElapsedMilliseconds}");
        }

        static string[] GenerationStringArray(int num, int lenghtStr)
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789.-";
            var ends = new string[]{".com",".ru",".us",".uk",".de"};
            var random = new Random();
            var array = new string[num];
            for (int i = 0; i < num; i++)
            {
                var list = Enumerable.Repeat(0, lenghtStr).Select(x=>chars[random.Next(chars.Length)]).ToList();
                var str = string.Join("", list) + ends[random.Next(ends.Length)];
                array[i] = str.Trim(new char[] {'.', '-'});
            }
            return array;
        }
        
    }
    
}