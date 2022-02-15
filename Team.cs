using System;
using Workers;
using House;

namespace Teams
{
    class Team //решил сделать его главным циклом
    {
        Worker worker = new Worker();
        TeamLeader brigadir = new TeamLeader();

        public Team(int value = 1) //количество строителей(от этого зависит скорость строительства)
        {
            if (value > 0)
            {
                worker.quant = value;
            }
        }

        public void Start()
        {
            while (brigadir.parts.Count > 0) //пока есть задачи
            {
                worker.Do_Work(brigadir.parts[0]); //работает работу работника

                brigadir.Do_Work(brigadir.parts[0]); //работает работу бригадира
            }
        }
    }
}
