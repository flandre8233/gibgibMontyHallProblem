using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MontyHallProblem {
    class Program {
        static void Main(string[] args) {
            //Monty Hall problem
            Console.WriteLine("Monty Hall problem 三門問題");
            Console.WriteLine();
            Console.WriteLine("在這模型上，玩家初始只會選擇第0號門，之後會跟據主持打開了什麼門而改變選擇");
            Console.WriteLine();

            do {
                Console.WriteLine();
                Console.WriteLine("按Q開始會更改選擇的三門問題 按W開始不會更改選擇的三門問題 按Enter離開 ");
                ConsoleKeyInfo cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.Q) {
                    Console.WriteLine();
                    Console.WriteLine();

                    function(true);


                }
                if (cki.Key == ConsoleKey.W) {
                    Console.WriteLine();
                    Console.WriteLine();

                    function(false);

                }

            }
            while (Console.ReadKey().Key != ConsoleKey.Enter);
        }
        static void function(bool willSwitchDoor) {
            int notHitNumberCounter = 0;
            float SuccessRate = 0;
            Random doorRandom = new Random();
            int totalTestNubmer = 1000;
            for (int i = 0; i < totalTestNubmer; i++) {
                int realdoor = doorRandom.Next(0, 3);
                int chooseDoor = 0;
                int openFakeDoor = 0;
                if (realdoor == chooseDoor) {
                    openFakeDoor = doorRandom.Next(1, 3);
                    if (realdoor == 1) {
                        openFakeDoor = 2;
                        if (willSwitchDoor) {
                            chooseDoor = 1;
                        }
                    } else {
                        openFakeDoor = 1;
                        if (willSwitchDoor) {
                            chooseDoor = 2;
                        }
                    }
                } else {
                    if (realdoor == 1) {
                        openFakeDoor = 2;
                        if (willSwitchDoor) {
                            chooseDoor = 1;
                        }
                    } else {
                        openFakeDoor = 1;
                        if (willSwitchDoor) {
                            chooseDoor = 1;
                            chooseDoor = 2;

                        }
                    }
                }
                if (realdoor == chooseDoor) {
                    SuccessRate = 100 - ((float)notHitNumberCounter / (i + 1)) * 100;
                    Console.WriteLine("答案在" + realdoor + "號門 " + "玩家選擇了" + chooseDoor + "號門 " + "主持開了" + openFakeDoor + "號門 " + "玩家中了 " + "成功率是：" + SuccessRate + "%");
                } else {
                    notHitNumberCounter++;
                    SuccessRate = 100 - ((float)notHitNumberCounter / (i + 1)) * 100;
                    Console.WriteLine("答案在" + realdoor + "號門 " + "玩家選擇了" + chooseDoor + "號門 " + "主持開了" + openFakeDoor + "號門 " + "玩家不中 " + "成功率是：" + SuccessRate + "%");
                }
            }
            Console.WriteLine();

            Console.WriteLine("測試了" + totalTestNubmer + "次 " + "成功中了" + (totalTestNubmer - notHitNumberCounter) + "次 " + "失敗了" + notHitNumberCounter + "次 " + "成功率是：" + SuccessRate + "%");
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("按任以鍵繼續");
        }
    }
}
