using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace PingPong
{
    //    2 класса Ping и Pong
    //один уведомляет другого, о том, что "произошёл пинг", другой - о том, что "произошёл понг",
    //одна пара объектов "играют" между собой, другая пара - между собой и т.д.
    //и выводить на консоль соответсвующие сообщения, что-то вроди такого:

    //Ping received Pong.
    //Pong received Ping.
    //Ping received Pong.
    //Pong received Ping.
    //Ping received Pong.

    //    1. Определить условие возникновения события и методы которые должны сработать.
    //    2. Определить сигнатуру этих методов и создать делегат на основе этой сигнатуры.
    //    3. Создать общедоступное событие на основе этого делегата и вызовать, когда условие сработает.
    //    4. Обязательно(где-угодно) подписаться на это событие теми методами, которые должны сработать и сигнатуры которых подходят к делегату.


    class Game
    {
        public delegate void PingPong();                                             // Д Е Л Е Г А Т 

        public event PingPong Play;                                                  // С О Б Ы Т И Е 
        public event PingPong Play1;

        public void Gaming1()
        {
            Play1();
        }
        public void Gaming()
        {
            Play();
        }
    }

    class Ping
    {
        public void Message()
        {
            Console.WriteLine("Пинг получил мяч ");
        }
    }

    class Pong
    {
        public void Message()
        {
            Console.WriteLine(" \n\t\t\t Понг получил мяч  \n\t\t\t ");
        }
    }

    class Start
    {

        Game G = new Game();
        Ping Pi = new Ping();
        Pong Po = new Pong();

        public void PingBeat()
        {
            G.Gaming();
            int a;
            int b;
            do
            {
                a = int.Parse(Console.ReadLine());

                if (a == 2)
                {
                    G.Gaming1();
                }

                else
                {
                    Console.WriteLine("\tOut");
                    break;
                }

                b = int.Parse(Console.ReadLine());
                if (b == 1)
                {
                    G.Gaming();
                }
                else
                {
                    Console.WriteLine("\tOut");
                    break;
                }



            } while (true);
        }
        public void PongBeat()
        {
            G.Gaming1();
            int a;
            int b;
            do
            {

                a = int.Parse(Console.ReadLine());
                if (a == 1)
                {
                    G.Gaming();
                }
                else
                {
                    Console.WriteLine("\tOut");
                    break;
                }

                b = int.Parse(Console.ReadLine());
                if (b == 2)
                {
                    G.Gaming1();
                }

                else
                {
                    Console.WriteLine("\tOut");
                    break;
                }
            } while (true);
        }
        public void StartTheGame()
        {

            G.Play += Po.Message;
            G.Play1 += Pi.Message;
            
            do
              {

                 Console.WriteLine("\n\t\tП О И Г Р А Е М ?\n\t\tКТО ПОДАЕТ МЯЧ ? \n\n1 : Ping \t\t\t\t2: Pong \t\t\t\t Для явыхода нажмите 5  \nПинг нажимает 1 для отбивания  \t\tПонг нажимает 2 для отбивания  ");
                 int switch_on = int.Parse(Console.ReadLine());

              
                 switch (switch_on)

                 {
                     case 1:
                             PingBeat();
                             break;

                     case 2:
                             PongBeat();
                             break;
                 }
              
                  if (switch_on==5)
                  {
                      break;
                  }
                              
            }  while (true);
        }
    }

    class Program

    {
        static void Main(string[] args)
        {

            Start S = new Start();
            S.StartTheGame();
        }

    }

}
