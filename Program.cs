using System;
using System.Threading;

namespace Function4
{
//    Сделать игровую карту с помощью двумерного массива.
//    Сделать функцию рисования карты.Помимо этого,
//    дать пользователю возможность перемещаться по карте и взаимодействовать с элементами
//    (например пользователь не может пройти сквозь стену)

//Все элементы являются обычными символами
    class Program
    {
        static void Main(string[] args)
        {
            string[,] map = { {"###################################" },
                              {"#                                 #" },
                              {"#    #####              #####     #" },
                              {"#     ###                ###      #" },
                              {"#                #                #" },
                              {"#                #                #" },
                              {"#                #                #" },
                              {"#                #                #" },
                              {"#                #                #" },
                              {"#       ####################      #" },
                              {"#                                 #" },
                              {"###################################" }};

            char[,] CharMap = CreateCharMap(map);
           
            MapVisualization(CharMap);

            int positionX = 1;//горизонт
            int positionY = 1;//вертикал
            int movX = 0;
            int movY = 0;
            int sleep = 100;

            char plaer = '@';

            Console.CursorVisible = false;
            PlaerMovement(ref positionX, ref  positionY, movX, movY,plaer, CharMap);

            while (true)
            {
                if(Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:

                            movY = -1; movX = 0;
                            PlaerMovement(ref positionX, ref positionY, movX, movY, plaer, CharMap);

                            break;
                        case ConsoleKey.DownArrow:

                            movY = 1;movX = 0;
                            PlaerMovement(ref positionX, ref positionY, movX, movY, plaer, CharMap);

                            break;
                        case ConsoleKey.LeftArrow:

                            movX = -1;movY = 0;
                            PlaerMovement(ref positionX, ref positionY, movX, movY, plaer, CharMap);

                            break;
                        case ConsoleKey.RightArrow:

                            movX = 1;movY = 0;
                            PlaerMovement(ref positionX, ref positionY, movX, movY, plaer, CharMap);

                            break;
                    }

                }
               Thread.Sleep(sleep);
              // Console.ReadKey();
            }
        }

        static void PlaerMovement(ref int X, ref int Y, int movX, int movY, char plaer, char[,] map)
        {


            Console.SetCursorPosition(X, Y);
            Console.Write(" ");

            X += movX;
            Y += movY;

            char stopMovement = '#';
            if(X<1)
            { X = 1; }

            if(Y<1)
            { Y = 1; }

            Console.SetCursorPosition(1, 13);///////
            Console.Write("X=" + X + " Y=" + Y+" map="+"["+map[X,Y]+"]");//////

            if (map[X,Y]!=stopMovement)
            {
                Console.SetCursorPosition(X, Y);
                Console.Write(Y);
            }else
            {
               
                Console.SetCursorPosition(X-movX, Y-movY);
                Console.Write(plaer);
            }

        }

        static void MapVisualization(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {

                    Console.Write(map[i, j]);
                }
                Console.Write("\n");
            }
        }

        static char[,] CreateCharMap(string[,] map)
        {
            char[,] charMap= new char[map.GetLength(0), map[0, 0].Length];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                string tt = map[i, 0];

                for (int j = 0; j < tt.Length; j++)
                {
                    charMap[i, j] = tt[j];
                }
            }

            return charMap;
        }

    }
}
