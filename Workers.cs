using System;
using System.Collections.Generic;
using System.Threading;
using House;



namespace Workers
{
    public interface IWorker
    {
        void Do_Work(Home part);
    }

    class Worker : IWorker
    {
        public int quant { get; set; } //количество рабочих

        public void Do_Work(Home part)
        {
            for(int i = 1; i <= (int)Enum.Parse(typeof(Home), part.ToString()); i++) {
                Console.Write($" {part} {i} building "); //пишет что строится

                for (int j = 0; j < 3; j++)
                {
                    Thread.Sleep(2500 / quant); //время ожидания в миллисекундах(типо строится)
                    Console.Write(". ");
                }

                Thread.Sleep(2500 / quant);
                Console.WriteLine();
            }  
        }
    }

    class TeamLeader : IWorker
    {
        public List<Home> parts = new List<Home>(); 

        public TeamLeader() //так как теперь класса/интерфейса дом нету, заполняю в конструкторе
        {
            parts.Add(Home.Basement);
            parts.Add(Home.Wall);
            parts.Add(Home.Door);
            parts.Add(Home.Window);
            parts.Add(Home.Roof);
        }

        public void Do_Work(Home part) //печатает результат работы строителей и
                                        //фиксирует результаты в списке
        {
            Console.WriteLine($" {part} building ended successful!\n");
            parts.Remove(part);
        }
    }
}
