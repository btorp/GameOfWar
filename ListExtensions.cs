using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfWar
{
    public static class ListExtensions
    {
        private static Random rand = new Random();

        public static void ShuffleList<T>(this IList<T> list)
        {            
            for (int i = 0; i < list.Count; i++)
            {
                int randIndex = rand.Next(i, list.Count);
                T tmp = list[randIndex];
                list[randIndex] = list[i];
                list[i] = tmp;
            }
            
        }
    }
}
