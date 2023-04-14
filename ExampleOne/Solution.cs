using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ExampleOne
{
    public class Solution
    {
        public static int[] solution(string[] A, string[] B)
        {
            var res = new List<Tuple<int,string>>();
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = 0; j < B.Length; j++)
                {
                    if (A[i].EndsWith(B[j]))
                        break;
                    if (j == B.Length - 1)
                    {
                        res.Add(new Tuple<int, string>(i, A[i]));
                    }
                }
            }
            
            return res.Select(q=>q.Item1).ToArray();
        }
        
        public static int[] solutionOnLINQ(string[] A, string[] B)
        {
            var busyHosts = new List<int>();
            var array = A.Select((v, i) => new {Index = i, Value = v}).ToList();
            foreach (var val in B)
            {
                busyHosts.AddRange(array.Where(q => q.Value.EndsWith(val)).Select(q=>q.Index).ToList());
            }
            return array.Select(q=>q.Index).Except(busyHosts).ToArray(); // возвращаем индексы разрешенных хостов
        }
    }
}