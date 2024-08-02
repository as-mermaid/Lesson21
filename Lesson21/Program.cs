using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lesson21
{
    internal class Program
    {
        static int n;
        static int[,] garden;

        static void Main(string[] args)
        {
            //Создаем сад
            Console.WriteLine("Введите размер сада");
            n = Convert.ToInt32(Console.ReadLine());
            Random random = new Random();
            
            garden = new int[n,n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    garden[i, j] = random.Next(0, 50);
                }
            }
            PrintGarden();
            Console.WriteLine();


            //Запускаем садовников
            ThreadStart threadStart = new ThreadStart(Gardener1);
            Thread thread = new Thread(threadStart);  
            thread.Start();
            Gardener2();

            //Выводим результат их работы
            PrintGarden();
            Console.ReadKey();  
        }

        static void Gardener1 ()
        {
            for(int i = 0;i < n; i++)
            {
                for (int j=0; j < n; j++)
                {
                    if (garden[i, j] >= 0)
                    {
                        int delay = garden[i, j];
                        garden[i, j] = -1;
                        Thread.Sleep(delay);
                    }
                }
            }
        }

        static void Gardener2()
        {
            for (int i = n-1; i >= 0; i--)
            {
                for (int j = n-1; j >= 0; j--)
                {
                    if (garden[i, j] >= 0)
                    {
                        int delay = garden[i, j];
                        garden[i, j] = -2;
                        Thread.Sleep(delay);
                    }
                }
            }
        }

        static void PrintGarden()
        {
            for (int i =0; i < n; i++)
            {
                for (int j = 0; j < n;j++)
                    {
                    Console.Write($"{garden[i, j]:00}   ");
                    }
                Console.WriteLine();
            }
        }
    }
}
