using System;
using System.Threading;

namespace Function4
{
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

            char[,] сharMap = CreateCharMap(map);
           
            VisualizeMap(сharMap);

            int positionX = 1;
            int positionY = 1;
            char plaer = '@';
           // int startPosition = 0;

            Console.CursorVisible = false;

            //  MovePlaer(ref positionX, ref  positionY, startPosition, startPosition,plaer, сharMap);
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(plaer);
            ControlOfGame(ref positionX, ref positionY, plaer, сharMap);
            
        }

        static void ControlOfGame(ref int positionX, ref int positionY, char plaer, char[,] map)
        {
            int movementX ;
            int movementY ;
            int sleep = 300;
            bool isContinuedGame = true;

            while (isContinuedGame)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        case ConsoleKey.UpArrow:

                            movementY = -1; movementX = 0;
                            MovePlaer(ref positionX, ref positionY, movementX, movementY, plaer, map);

                            break;
                        case ConsoleKey.DownArrow:

                            movementY = 1; movementX = 0;
                            MovePlaer(ref positionX, ref positionY, movementX, movementY, plaer, map);

                            break;
                        case ConsoleKey.LeftArrow:

                            movementX = -1; movementY = 0;
                            MovePlaer(ref positionX, ref positionY, movementX, movementY, plaer, map);

                            break;
                        case ConsoleKey.RightArrow:

                            movementX = 1; movementY = 0;
                            MovePlaer(ref positionX, ref positionY, movementX, movementY, plaer, map);

                            break;
                        case ConsoleKey.Escape:

                            isContinuedGame = false;

                            break;
                    }
                }
                Thread.Sleep(sleep);
            }
        }

        static void MovePlaer(ref int positionX, ref int positionY, int movementX, int movementY, char plaer, char[,] map)
        {
           
            char stopMovement = '#';

            if (map[positionY+ movementY, positionX+ movementX] !=stopMovement)
            {
                positionX += movementX;
                positionY += movementY;
                Console.SetCursorPosition(positionX, positionY);
                Console.Write(plaer);
                Console.SetCursorPosition(positionX - movementX, positionY - movementY);
                Console.Write(" ");
            }
        }

        static void VisualizeMap(char[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.Write("\n");
            }

            Console.WindowHeight = map.GetLength(0);
            Console.WindowWidth = map.GetLength(1);

            int bufferLimit = 1;
            Console.BufferHeight = Console.WindowHeight+bufferLimit;
            Console.BufferWidth = Console.WindowWidth+bufferLimit;

        }

        static char[,] CreateCharMap(string[,] map)
        {
            char[,] charMap= new char[map.GetLength(0), map[0, 0].Length];
            for (int i = 0; i < map.GetLength(0); i++)
            {
                string tempString = map[i, 0];

                for (int j = 0; j < tempString.Length; j++)
                {
                    charMap[i, j] = tempString[j];
                }
            }

            return charMap;
        }

    }
}
